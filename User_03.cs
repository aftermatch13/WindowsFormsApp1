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
    public partial class User_03 : Form
    {
        public User_03()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            User_01 user_1 = new User_01();
            user_1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            User_02 user_2 = new User_02();
            user_2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            User_03 user_3 = new User_03();
            user_3.Show();
            this.Hide();
        }
    }
}
