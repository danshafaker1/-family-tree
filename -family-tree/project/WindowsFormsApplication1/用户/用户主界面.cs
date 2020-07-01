using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class 用户主界面 : Form
    {
        public 用户主界面()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            族谱图 a = new 族谱图();

            a.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            族谱简介 a = new 族谱简介();
            a.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            家训 a = new 家训();
            a.Show();
        }

        private void 用户主界面_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            查找成员 a = new 查找成员();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            查找近亲 a = new 查找近亲();
            a.Show();
        }
    }
}
