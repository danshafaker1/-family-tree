using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class 添加界面 : Form
    {
         SqlDataReader dr;
        public string a = null;
        public 添加界面()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source =localhost; Initial Catalog = FamliyTree; User ID = sa; Password = 123456";

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sql1 = @"select count(*) from PERSON_TABLE";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            int count = (int)cmd.ExecuteScalar();
            count++;
            conn.Close();
 
      





            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=localhost;database=FamliyTree;uid=sa;pwd=123456";
            //con.ConnectionString = "server=192.168.30.7;database=AIS20170720100743;uid=sa;pwd=ABCabc123";
            con.Open();
            //创建文件流，path参数是文件路径
            FileStream file = new FileStream(a, FileMode.Open);
            int streamLength = (int)file.Length;
            byte[] image = new byte[streamLength];//声明字节数组，保存图片文件
            file.Read(image, 0, streamLength); //把图片文件转换成字节数组保存
            file.Close();







            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO PERSON_TABLE(PERSON_NAME,PERSON_SURNAME,PERSON_RANK,PERSON_SEX,PERSON_ADDR,PERSON_BDATE,PERSON_SUM,PERSON_ID,PERSON_PIC) VALUES(");
            sb.Append("'" + textBox1.Text + "',");
            sb.Append("'" + textBox2.Text + "',");
            sb.Append("'" + textBox3.Text + "',");
          
           if (radioButton2.Checked)
                sb.Append("'" + radioButton2.Text + "',");
            else if (radioButton1.Checked)
                sb.Append("'" + radioButton1.Text + "',");
            sb.Append("'" + textBox4.Text + "',");
            sb.Append("'" + textBox5.Text + "',");
            sb.Append("'" + textBox6.Text + "',");
            sb.Append("'" + count+ "',");


            sb.Append("@image)");






            string sql = sb.ToString();


            //string sql = string.Format("update ");
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.Add(new SqlParameter("image", SqlDbType.Binary, image.Length, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Default, image));

            try
            {
                dr = com.ExecuteReader();
                MessageBox.Show("已存入！");
            }
            catch (Exception msg)
            {
                MessageBox.Show("出问题了！\n 出错原因：" + msg.Message);
            }
            dr.Close();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();   //创建打开文件对话框对象
            pic.Filter = "*.jpg;*.bmp;*.*|*.jpg;*.bmp;*.*";  //设置只显示jpg和bmp两种图像文件
            if (pic.ShowDialog() == DialogResult.OK)    //显示打开文件对话框
            {
                a = System.IO.Path.GetFullPath(pic.FileName);
            }
            pictureBox1.ImageLocation = a;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        }
    }
