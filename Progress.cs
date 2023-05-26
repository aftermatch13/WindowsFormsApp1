using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int starttime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            starttime = starttime + 1;
            Myprogress.Value = starttime;
            precent.Text = starttime + "%";
            if(Myprogress.Value ==100)
            {
              
                Myprogress.Value = 0;
                timer1.Stop();
                Sign_in sign_in = new Sign_in();
                sign_in.Show();
                this.Hide();
             
            }

        }
    }
}
