using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pacman_v_1._00.Ortakis;
using pacman_v_1._00.Properties;

namespace pacman_v_1._00
{
    enum ghostYon
    {
        left, right, top, bottom
    }
    internal class ghost : PictureBox
    {

        public ghost(Form akatarılacakForm)
        {
            alınanForm = akatarılacakForm;
            ghostAyarlar();
            ghosttimer = new Timer();
            ghosttimer2 = new Timer();
            ghosttimerAyarla();
            ghosttimer2Ayarla();
        }

        public Image[] ghostimage = new Image[2]
        {
            Resources.redghost,
            Resources.redgost2
        };
        private Timer ghosttimer2 { get; }
        private Timer ghosttimer { get; }
        private Form alınanForm;
        private List<ghostYon> yon = new List<ghostYon>() { ghostYon.left };
        private List<double> mesafeler { get; set; }
        void ghosttimerAyarla()
        {
            ghosttimer.Interval = 50;
            ghosttimer.Enabled = true;
            ghosttimer.Tick += ghosttimer_Tick;
        }
        void ghosttimer2Ayarla()
        {
            ghosttimer2.Interval = 500;
            ghosttimer2.Enabled = true;
            ghosttimer2.Tick += ghosttimer2_Tick;
        }
        private void ghosttimer2_Tick(object sender, EventArgs e)
        {
            GhostYonTayin(pacman_model.locasyonu);
            OrtakIs.karakterHaraket(this, ghostimage);
        }
        private void ghosttimer_Tick(object sender, EventArgs e)
        {
            GhostHaraketET();

        }
        private void ghostAyarlar()
        {
            this.Image = Resources.redgost2;
            this.Location = new Point(703, 110);
            this.Size = new Size(50, 50);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.TabIndex = 80;
            this.TabStop = false;
            alınanForm.Controls.Add(this);
        }
        public void GhostYonTayin(Point pcBox)
        {
            double mesafeRight = Math.Pow((pcBox.X + 5 - this.Location.X + 5), 2) + Math.Pow((pcBox.Y - this.Location.Y), 2);
            double mesafeLeft = Math.Pow((pcBox.X - 5 - this.Location.X - 5), 2) + Math.Pow((pcBox.Y - this.Location.Y), 2);
            double mesafeTop = Math.Pow((pcBox.X - this.Location.X), 2) + Math.Pow((pcBox.Y - 5 - this.Location.Y - 5), 2);
            double mesafeBottom = Math.Pow((pcBox.X - this.Location.X), 2) + Math.Pow((pcBox.Y + 5 - this.Location.Y + 5), 2);
            mesafeler = new List<double>()
            {
                mesafeRight,
                mesafeLeft,
                mesafeTop,
                mesafeBottom
            };
            yon = mesafeler.OrderByDescending(x =>
                x).Select(x => x == mesafeRight ? ghostYon.right : x == mesafeLeft ? ghostYon.left : x == mesafeBottom ? ghostYon.bottom : ghostYon.top).ToList();
        }
        public void GhostHaraketET()
        {
            Random rnd = new Random();
            Point a = this.Location;
            List<Label> degenLabels = Form1.labels.FindAll(x => new Rectangle(this.Location, this.Size).IntersectsWith(new Rectangle(x.Location, x.Size)));
            int index = 0;
            do
            {
                if (yon.Count > 3)
                    if (yon[2] == ghostYon.left && yon[1] == ghostYon.right || yon[1] == ghostYon.left && yon[2] == ghostYon.right)
                        yon[1] = yon[2] = (ghostYon)rnd.Next(0, 2);
                if (yon[index % 4] == ghostYon.bottom && degenLabels.Count(x => x.BackColor == Color.Yellow) <= 0)
                    this.Top += 5;
                else if (yon[index % 4] == ghostYon.bottom && degenLabels.Count(x => x.BackColor == Color.Yellow) > 0)
                    index++;
                if (yon[index % 4] == ghostYon.top && degenLabels.Count(x => x.BackColor == Color.Red) <= 0)
                    this.Top -= 5;
                else if (yon[index % 4] == ghostYon.top && degenLabels.Count(x => x.BackColor == Color.Red) > 0)
                    index++;
                if (yon[index % 4] == ghostYon.right && degenLabels.Count(x => x.BackColor == Color.ForestGreen) <= 0)
                    this.Left += 5;
                else if (yon[index % 4] == ghostYon.right && degenLabels.Count(x => x.BackColor == Color.ForestGreen) > 0)
                    index++;
                if (yon[index % 4] == ghostYon.left && degenLabels.Count(x => x.BackColor == Color.Magenta) <= 0)
                    this.Left -= 5;
                else if (yon[index % 4] == ghostYon.left && degenLabels.Count(x => x.BackColor == Color.Magenta) > 0)
                    index++;
            } while (a == this.Location);
        }
    }
}
