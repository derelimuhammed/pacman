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

    public partial class Form1 : Form
    {
        
        private ghost ghost { get; set; }

        private pacman_model pacman_Model { get; }
        public static List<Label> labels { get; set; }
        public Form1()
        {
            
            pacman_Model = new pacman_model(this);
            ghost = new ghost(this);
            InitializeComponent();
            KeyDown += pacHaraketEt;
            labels = this.Controls.OfType<Label>().ToList();
        }
        void pacHaraketEt(object sender, KeyEventArgs e)
        {
            pacman_Model.pacHaraketEt = e;
            //label78.Text = pacman_model.oyuncuPuan.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         pacman_Model.getircoin();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ghost.oyun)
            {

                ghost = new ghost(this);
                timer1.Enabled = false;
                timer2.Enabled = true;

            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ghost.oyun)
            {
                ghost = new ghost(this);
                timer2.Enabled = false;
            }
        }
        
    }
}
