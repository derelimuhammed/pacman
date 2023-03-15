using pacman_v_1._00.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman_v_1._00
{
    public enum pacmanDegenyon
    {
        none, left, right, top, bottom
    }
    public enum yon
    {
        none, left, right, top, bottom
    }
    internal class pacman_model
    {
        public bool left = false, right = false, top = false, bottom = false
        public pacmanDegenyon degenyon;
        private int currentIndex = 0;
        public Image[] pacman = new Image[2]
        {
            Resources.pacman_agziKapali,
            Resources.pacman_Agzi_Acik
        };

        public int hız { get; set; } = 5;
        public void karakterHaraket(PictureBox pictureBox1, Image[] pacman)
        {
            currentIndex++;
            if (currentIndex >= pacman.Length)
                currentIndex = 0;
            pictureBox1.Image = pacman[currentIndex];
        }

        public void PacManDegiyorMu(PictureBox pictureBox1, yon yon)
        {
            List<Label> degenLabels = Form1.labels.FindAll(x => new Rectangle(pictureBox1.Location,pictureBox1.Size).IntersectsWith(new Rectangle(x.Location, x.Size)));
            top=degenLabels.Count(x => x.BackColor == Color.Red) > 0 ?  true :  false;
            left=degenLabels.Count(x => x.BackColor == Color.Magenta) > 0 ?  true :  false;
            bottom=degenLabels.Count(x => x.BackColor == Color.Yellow) > 0 ?  true :  false;
            right=degenLabels.Count(x => x.BackColor == Color.ForestGreen) > 0 ?  true :  false;
        }


    }


}

