using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pacman_v_1._00.Properties;

namespace pacman_v_1._00
{
    enum ghostYon
    {
        left, right, top, bottom
    }
    internal class ghost:pacman_model
    {
        public Image[] ghostimage = new Image[2]
        {
            Resources.redghost,
            Resources.redgost2
        };

        private List<string> yon = new List<string>() { "left", "right", "top", "bottom" };

        public void GhostYonTayin()
        {

        }
        public void ghostDegiyorMu(PictureBox pictureBox1, yon yon)
        {
            foreach (var item in Form1.labels)
            {
                if (new Rectangle(pictureBox1.Location, pictureBox1.Size).IntersectsWith(new Rectangle(item.Location, item.Size)))
                {
                    if (yon == yon.top && item.BackColor == Color.Red)
                    {
                        degenyon = pacmanDegenyon.top;
                        break;
                    }

                    if (yon == yon.left && item.BackColor == Color.Magenta)
                    {
                        degenyon = pacmanDegenyon.left;
                        break;
                    }
                    if (yon == yon.bottom && item.BackColor == Color.Yellow)
                    {
                        degenyon = pacmanDegenyon.bottom;
                        break;
                    }
                    if (yon == yon.right && item.BackColor == Color.ForestGreen)
                    {
                        degenyon = pacmanDegenyon.right;
                        break;
                    }

                }
                else
                    degenyon = pacmanDegenyon.none;



            }


        }
    }
}
