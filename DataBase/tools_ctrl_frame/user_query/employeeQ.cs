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
    public partial class employeeQ : UserControl
    {
        public employeeQ()
        {
            InitializeComponent();
            string sql = "select * from Employees;";
            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bianhao_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bianhao = bianhaobox.Text;
            string zhiwu = xinghaobox.Text;
            string dianhua = leibiebox.Text;
            string xingming = mingchengbox.Text;
            string bumen = bumenbox.Text;
            string zhuangtai = zhuangtaibox.Text;
            string sql = $"select * from Employees where 1=1";
            if (!string.IsNullOrEmpty(bianhao))
            {
                sql += $" and [员工编号] like '%{bianhao}%'";
            }
            if (!string.IsNullOrEmpty(zhiwu))
            {
                sql += $" and [职务] like '%{zhiwu}%'";
            }
            if (!string.IsNullOrEmpty(dianhua))
            {
                sql += $" and [联系电话] like '%{dianhua}%'";
            }
            if (!string.IsNullOrEmpty(xingming))
            {
                sql += $" and [姓名] like '%{xingming}%'";
            }
            if (!string.IsNullOrEmpty(bumen))
            {
                sql += $" and [所属部门] like '%{bumen}%'";
            }
            if (!string.IsNullOrEmpty(zhuangtai))
            {
                sql += $" and [员工状态] like '%{zhuangtai}%'";
            }
            DataTable dt = new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xinghaobox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
