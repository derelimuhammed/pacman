using pacman_v_1._00.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pacman_v_1._00.Ortakis;

namespace pacman_v_1._00
{

    public enum yon
    {
        none,
        left,
        right,
        top,
        bottom
    }

    public class pacman_model : PictureBox
    {
        public pacman_model(Form aktarilacakForm)
        {
            AlınankForm = aktarilacakForm;
            pacmanAyarlar();
            pacmanTimer = new Timer();
            pacmanTimerAyarla();
            locasyonu = this.Location;

        }

        public List<PictureBox> coinImages { get; set; }
        public static Point locasyonu;
        private yon yonu;
        public bool left = false, right = false, top = false, bottom = false;
        private Timer pacmanTimer;
        private Form AlınankForm;
        public static int oyuncuPuan=30;

        public Image[] pacman = new Image[2]
        {
            Resources.pacman_agziKapali,
            Resources.pacman_Agzi_Acik
        };

        public int hız { get; set; } = 5;

        public KeyEventArgs pacHaraketEt
        {
            set
            {
                KeyEventArgs e = value;
                PacManDegiyorMu(yonu);
                Image g = Resources.pacman_Agzi_Acik;
                if (e.KeyData == Keys.A)
                {
                    if (!(left && yonu == yon.left) && !(bottom && left) && !(top && left))
                    {
                        this.Left += -hız;
                        g.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        pacman[1] = g;
                    }

                    yonu = yon.left;
                }

                if (e.KeyData == Keys.D)
                {
                    if (!(right && yonu == yon.right) && !(bottom && right) && !(top && right))
                    {
                        this.Left += hız;
                        pacman[1] = g;
                    }

                    yonu = yon.right;
                }

                if (e.KeyData == Keys.W)
                {
                    if (!(top && yonu == yon.top) && !(top && left) && !(top && right))
                    {
                        this.Top += -this.hız;
                        g.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        pacman[1] = g;
                    }

                    yonu = yon.top;
                }

                if (e.KeyData == Keys.S)
                {
                    if (!(bottom && yonu == yon.bottom) && !(bottom && right) && !(bottom && left))
                    {
                        this.Top += hız;
                        g.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        pacman[1] = g;
                    }

                    yonu = yon.bottom;
                }
            }

        }

        void pacmanTimerAyarla()
        {
            pacmanTimer.Interval = 50;
            pacmanTimer.Enabled = true;
            pacmanTimer.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            OrtakIs.karakterHaraket(this, pacman);
            locasyonu = this.Location;
            pacmanCoinYe();
        }

        void pacmanAyarlar()
        {

            this.BackColor = Color.Transparent;
            this.Image = Resources.pacman_agziKapali;
            this.Location = new Point(410, 305);
            this.Name = "pictureBox1";
            this.Size = new Size(50, 50);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.TabIndex = 20;
            this.TabStop = false;
            AlınankForm.Controls.Add(this);
        }

        public void PacManDegiyorMu(yon yon)
        {
            List<Label> degenLabels = Form1.labels.FindAll(x =>
                new Rectangle(this.Location, this.Size).IntersectsWith(new Rectangle(x.Location, x.Size)));
            top = degenLabels.Count(x => x.BackColor == Color.Red) > 0 ? true : false;
            left = degenLabels.Count(x => x.BackColor == Color.Magenta) > 0 ? true : false;
            bottom = degenLabels.Count(x => x.BackColor == Color.Yellow) > 0 ? true : false;
            right = degenLabels.Count(x => x.BackColor == Color.ForestGreen) > 0 ? true : false;
        }

        public void getircoin()
        {
            coinImages = new List<PictureBox>();

            for (int i = 0; i < AlınankForm.Size.Height / 50; i++)
            {
                for (int j = 0; j < AlınankForm.Size.Width / 50; j++)
                {
                    coinImages.Add(new PictureBox()
                    {
                        Location = new Point(15 + (j % AlınankForm.Size.Width) * 50,
                            15 + (i % AlınankForm.Size.Height) * 50),
                        Image = Resources.pngwing_com,
                        Size = new Size(25, 25),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    });
                }
            }

            for (int i = 0; i < AlınankForm.ClientSize.Height / 50 * AlınankForm.ClientSize.Width / 50; i++)
            {
                AlınankForm.Controls.Add(coinImages[i]);
            }
        }

        void pacmanCoinYe()
        {
            foreach (var VARIABLE in coinImages)
            {
                if (this.Bounds.IntersectsWith(VARIABLE.Bounds)&&VARIABLE.Visible)
                {
                    VARIABLE.Visible = false;
                    oyuncuPuan += 10;
                }
            }
           
        }


    }
}
