using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tools_ctrl_frame.user_query
{
    public partial class toolQ : UserControl
    {
        public toolQ()
        {
            InitializeComponent();
            string sql = "select * from Tools;";
            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bianhao_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bianhao = bianhaobox.Text;
            string xinghao = xinghaobox.Text;
            string leibie = leibiebox.Text;
            string mingcheng = mingchengbox.Text;
            string bumen = bumenbox.Text;
            string zhuangtai=zhuangtaibox.Text;
            string sql = $"select * from Tools where 1=1";
            if(!string.IsNullOrEmpty(bianhao))
            {
                sql += $" and [工器具编号]={bianhao}";
            }
            if (!string.IsNullOrEmpty(xinghao))
            {
                sql += $" and [型号]='{xinghao}'";
            }
            if (!string.IsNullOrEmpty(leibie))
            {
                sql += $" and [类别]='{leibie}'";
            }
            if (!string.IsNullOrEmpty(mingcheng))
            {
                sql += $" and [名称]='{mingcheng}'";
            }
            if (!string.IsNullOrEmpty(bumen))
            {
                sql += $" and [所属部门]={bumen}";
            }
            if (!string.IsNullOrEmpty(zhuangtai))
            {
                sql += $" and [资产状态]='{zhuangtai}'";
            }
            DataTable dt= new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
