using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-UD0T986Q;Initial Catalog=Second;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "" || Upassword.Text == "")
            {
                MessageBox.Show("用户名和密码不能为空！！！");
                Uname.Text = "";
                Upassword.Text = "";
            }
            else if(checkBox1.Checked ==true){
                Con.Open();
                SqlCommand manager_sda = new SqlCommand("select * from Manager where Mname='" + Uname.Text + "' and Mpassword = '" + Upassword.Text + "'", Con);
                int j = Convert.ToInt32(manager_sda.ExecuteScalar());
               
                if (j > 0)
                {
                    Manager manager = new Manager();
                    manager.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！！！");
                    Uname.Text = "";
                    Upassword.Text = "";
                    Con.Close();
                }

            }
            else
            {
                Con.Open();
                SqlCommand sda = new SqlCommand("select Uid from Users where Uname='" + Uname.Text + "' and Upassword = '" + Upassword.Text + "'", Con);
                int i = Convert.ToInt32(sda.ExecuteScalar());
                Class1.Userid = Convert.ToInt32(sda.ExecuteScalar());
                if (i > 0)
                {
                   
                    User user = new User();
                    
                    user.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！！！");
                    Uname.Text = "";
                    Upassword.Text = "";
                    Con.Close();
                }              

            }
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Sign_in_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign_up sign_up = new Sign_up();
            sign_up.Show();
            this.Hide();
       
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
