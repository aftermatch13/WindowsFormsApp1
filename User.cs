using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            search_grades();
        }
        
        private void label4_Click(object sender, EventArgs e)
        {
            User_03 user_3 = new User_03();
            user_3.Show();
            this.Hide();
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //删除模块
        private void button3_Click(object sender, EventArgs e)
        {
            int key = 0;
            if (Gname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(grades_list.SelectedRows[0].Cells[0].Value.ToString());
            }
            if (key==0)
            {
                MessageBox.Show("该商品不存在商品！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand insertGrades = new SqlCommand("delete from Grades where Gid="+key+"", Con);
                    insertGrades.ExecuteNonQuery();
                    MessageBox.Show("商品信息删除成功");
                    Con.Close();
                    reset();
                    search_grades();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //重置函数
        private void reset()
        {
            Gname.Text = "";
            Gprice.Text = "";
            Gtype.Text="全部分类";
     

        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-UD0T986Q;Initial Catalog=Second;Integrated Security=True");
       
        //商品列表显示
        private void search_grades()
        {
            Con.Open();
            SqlDataAdapter sql = new SqlDataAdapter("select Gid,Gname,Gprice,Gtype from Grades", Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sql);
            var da = new DataSet();
            sql.Fill(da);
            grades_list.DataSource = da.Tables[0];
            Con.Close();
           
        }
        
        
        /*添加按键的设计
         * 实现商品的添加功能
         * 未实现功能有：商品价格应当使其输入为数字
         *               商品类型应当为只读
         *               同名称商品不能重复输入
         *               商品拥有者未能自动添加
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string G_name = Gname.Text;
            string G_price = Gprice.Text;
            string G_type = Gtype.Text;
            if (G_name ==""||G_price == "" || G_type == "")
            {
                MessageBox.Show("内容不完整！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand insertGrades = new SqlCommand("insert into Grades(Gname,Gprice,Gtype) values ('" + G_name + "','" + G_price + "','"+G_type+"')", Con);
                    insertGrades.ExecuteNonQuery();
                    MessageBox.Show("商品信息保存完成");
                    Con.Close();
                    reset();
                    search_grades();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Gprice_TextChanged(object sender, EventArgs e)
        {

        }
        //商品信息更改
        private void button2_Click(object sender, EventArgs e)
        {
            int key = 0;
            if (Gname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(grades_list.SelectedRows[0].Cells[0].Value.ToString());
            }

            if (Gname.Text==""||Gprice.Text==""||Gtype.Text=="")
            {
                MessageBox.Show("信息缺失！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand insertGrades = new SqlCommand("update Grades set Gname='"+Gname.Text+"',Gprice="+Gprice.Text+",Gtype='"+Gtype.Text+"'where Gid ="+key+"", Con);
                    insertGrades.ExecuteNonQuery();
                    MessageBox.Show("商品信息更改成功");
                    Con.Close();
                    reset();
                    search_grades();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void label1_Click_1(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            search_grades();
        }

        private void grades_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Gname.Text = grades_list.SelectedRows[0].Cells[1].Value.ToString();
            Gprice.Text = grades_list.SelectedRows[0].Cells[2].Value.ToString();
            Gtype.Text = grades_list.SelectedRows[0].Cells[3].Value.ToString();

        }
        //过滤函数，实现对商品的筛选
        private void filter()
        {

            Con.Open();
            SqlDataAdapter sql = new SqlDataAdapter("select * from Grades where Gtype='"+ comboBox2.SelectedItem.ToString()+ "'", Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sql);
            var da = new DataSet();
            sql.Fill(da);
            grades_list.DataSource = da.Tables[0];
            Con.Close();
        }
        //下拉框过滤书籍信息
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void Gtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
