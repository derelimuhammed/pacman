using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman_v_1._00.Ortakis
{
    internal class OrtakIs
    {
        private static int currentIndex = 0;
        public static void karakterHaraket(PictureBox pictureBox1, Image[] resim)
        {
            currentIndex++;
            if (currentIndex >= resim.Length)
                currentIndex = 0;
            pictureBox1.Image = resim[currentIndex];
        }
    }
}
