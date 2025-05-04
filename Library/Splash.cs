using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

        }



        private void Splash_Load(object sender, EventArgs e)
        {
            panel2.Width = 0;
            timer1.Start();
            

        }
       
     

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (panel2.Width < 500)
            {
                panel2.Width += 6;

            }
            else
            {
                timer1.Stop();
                Users user = new Users();
                this.Hide();
                user.ShowDialog();
            }
        }
    }
}
