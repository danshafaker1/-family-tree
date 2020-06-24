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
using TreeGenerator;
using System.Xml;
namespace WindowsFormsApplication1
{
    public partial class 管理员录入界面 : Form
    {



        public 管理员录入界面()
        {
            InitializeComponent();



        }
        private TreeBuilder myTree = null;
        private void ShowTree()
        {
            picTree.Image = Image.FromStream(myTree.GenerateTree(800, -1, "1000", System.Drawing.Imaging.ImageFormat.Bmp));
        }



        private void 管理员录入界面_Load(object sender, EventArgs e)
        {
            TreeGenerator.TreeData.TreeDataTableDataTable dtTree = new TreeData.TreeDataTableDataTable();
            string id, fatherid;
            string name;

            using (
              SqlConnection con = new SqlConnection("server=localhost;database=FamliyTree;uid=sa;pwd=123456"))
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Close();
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @" Select  PERSON_NAME,PERSON_ID,FATHER_ID from PERSON_TABLE";//查询根节点
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    id = sdr["PERSON_ID"].ToString();
                    fatherid = sdr["FATHER_ID"].ToString();
                    name = sdr["PERSON_NAME"].ToString();
                    if (fatherid == "0")
                    {
                        dtTree.AddTreeDataTableRow(id, "", name, "");
                    }
                    else
                        dtTree.AddTreeDataTableRow(id, fatherid, name, "");

                }

                //instantiate the object
                //myOrgChart = new OrgChartGenerator.OrgChart(myOrgData);
                myTree = new TreeBuilder(dtTree);
                ShowTree();
            }
        }


        private void picTree_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle currentRect;
            //determine if the mouse clicked on a box, if so, show the  node description.
            string SelectedNode = "No Node";
            //find the node
            foreach (XmlNode oNode in myTree.xmlTree.SelectNodes("//Node"))
            {
                //iterate through all nodes until found.
                currentRect = myTree.getRectangleFromNode(oNode);
                if (e.X >= currentRect.Left &&
                    e.X <= currentRect.Right &&
                    e.Y >= currentRect.Top &&
                    e.Y <= currentRect.Bottom)
                {
                    SelectedNode = oNode.Attributes["nodeDescription"].InnerText;
                    break;
                }
            }
            MessageBox.Show(SelectedNode);
        }




    }

}
