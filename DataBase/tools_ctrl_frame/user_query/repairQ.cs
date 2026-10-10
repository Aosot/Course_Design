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
    public partial class repairQ : UserControl
    {
        public repairQ()
        {
            InitializeComponent();
            string sql = "select * from RepairRecords";
            DataTable dt = linkclass.Query(sql);
            dataGridView2.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void leibie_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from RepairRecords where 1=1 ";
            string bianhao = bianhaobox.Text.Trim();
            string fuzeren = xinghaobox.Text.Trim();
            string shenqingren = leibiebox.Text.Trim();
            string zhuangtai = mingchengbox.Text.Trim();
            string bumen = bumenbox.Text.Trim();

            if (!string.IsNullOrEmpty(bianhao))
            {
                if (int.TryParse(bianhao, out int id))
                    sql += $" and [工具编号] = {id}";
                else
                    MessageBox.Show("工具编号请输入数字");
            }
            if (!string.IsNullOrEmpty(fuzeren))
                sql += $" and [负责人] = '{fuzeren}'";
            if (!string.IsNullOrEmpty(shenqingren))
                sql += $" and [申请人] = '{shenqingren}'";
            if (!string.IsNullOrEmpty(zhuangtai))
            {
                if (zhuangtai == "完成")
                    sql += " and [完成日期] is not null";
                else if (zhuangtai == "未完成")
                    sql += " and [完成日期] is null";
                else
                    sql += $" and [情况概述] like '%{zhuangtai}%'";  
            }
            if (!string.IsNullOrEmpty(bumen))
            {
                if (int.TryParse(bumen, out int deptId))
                    sql += $" and [负责部门] = {deptId}";
                else
                    sql += $" and [负责部门] in (select [编号] from Department where [部门名称] like '%{bumen}%')";
            }

            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void bianhaobox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
