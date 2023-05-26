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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp1
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Rusername = this.textBox1.Text;
            string Rpassword = this.textBox2.Text;
            string Rconfirmpwd = this.textBox3.Text;
            //数据库配置
            SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-UD0T986Q;Initial Catalog=Second;Integrated Security=True");

            Con.Open();
            
            SqlCommand checkcommand = new SqlCommand("select * from Users where Uname='" + textBox1.Text + "'", Con);
            checkcommand.CommandType = CommandType.Text;
            SqlDataReader reader;
            reader = checkcommand.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("该用户名已存在，请重新输入");
            }
            else if (Rusername.Equals("") || Rpassword.Equals("") || Rconfirmpwd.Equals(""))
            {
                MessageBox.Show("你输入的信息不完整，请重新输入");
            }
            else if (!Rpassword.Equals(Rconfirmpwd))
            {
                MessageBox.Show("你两次输入密码不一致，请重新输入");
            }
            else
            {
                //关闭DataReader,否则会影响insertCommand的执行
                reader.Close();
                //向数据库中插入用户数据
                
                SqlCommand insertCommand = new SqlCommand("insert into Users(Uname,Upassword) values ('" + Rusername + "','" + Rpassword + "')", Con); //初始化命令
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("注册成功");
                //关闭数据库的连接
                Con.Close();
                Sign_in sign_in1 = new Sign_in();
                sign_in1.Show();
                this.Hide();
            }
        }
    }
}
