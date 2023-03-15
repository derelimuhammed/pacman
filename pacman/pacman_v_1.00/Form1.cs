using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pacman_v_1._00.Properties;

namespace pacman_v_1._00
{
    //123
    public partial class Form1 : Form
    {
        private ghost ghost = new ghost();
        private pacman_model pacman_Model = new pacman_model();
        private yon yon;
        public static List<Label> labels = new List<Label>();

        public Form1()
        {
            InitializeComponent();
            KeyDown += pacHaraketEt;
            labels = this.Controls.OfType<Label>().ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pacman_Model.karakterHaraket(pictureBox1,pacman_Model.pacman);
            ghost.karakterHaraket(pictureBox2, ghost.ghostimage);
            
        }
        void pacHaraketEt(object sender, KeyEventArgs e)
        {
            pacman_Model.PacManDegiyorMu(pictureBox1, yon);
            Image g = Resources.pacman_Agzi_Acik;
            if (e.KeyData == Keys.A  )
            {
                if (!(pacman_Model.left && yon == yon.left) && !(pacman_Model.bottom && pacman_Model.left) && !(pacman_Model.top && pacman_Model.left))
                {
                    pictureBox1.Left += -pacman_Model.hız;
                    g.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    pacman_Model.pacman[1] = g; 
                }
                yon = yon.left;
            }
            if (e.KeyData == Keys.D  )
            {
                if (!(pacman_Model.right && yon == yon.right)&&!(pacman_Model.bottom && pacman_Model.right) && !(pacman_Model.top && pacman_Model.right))
                {
                    pictureBox1.Left += pacman_Model.hız;
                    pacman_Model.pacman[1] = g;
                }
                yon = yon.right;
            }
            if (e.KeyData == Keys.W  )
            {
                if (!(pacman_Model.top && yon == yon.top) && !(pacman_Model.top && pacman_Model.left) && !(pacman_Model.top && pacman_Model.right))
                {
                    pictureBox1.Top += -pacman_Model.hız;
                    g.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    pacman_Model.pacman[1] = g;
                }
                yon = yon.top;
            }
            if (e.KeyData == Keys.S)
            {
                if (!(pacman_Model.bottom && yon == yon.bottom)&& !(pacman_Model.bottom&& pacman_Model.right) && !(pacman_Model.bottom && pacman_Model.left))
                {
                    pictureBox1.Top += pacman_Model.hız;
                    g.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pacman_Model.pacman[1] = g;
                }
                yon = yon.bottom;
            }
        }
    }
}
