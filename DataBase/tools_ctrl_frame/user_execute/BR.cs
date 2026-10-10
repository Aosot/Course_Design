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

namespace tools_ctrl_frame.user_execute
{
    public partial class BR : Form
    {
        public BR()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql="select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools;";
            DataTable dt = new DataTable();
            dt=linkclass.Query(sql);
            dataGridView1.DataSource = dt;
            comboBox2.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.Text;
            string sql;
            if (string.IsNullOrEmpty(s))
            {
                s = "全部";
            }
            if (s == "全部")
            {
                sql = $"select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools;";
            }
            else
            {
                sql = $"select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools where [资产状态]='{s}';";
            }
            DataTable dt = new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="借出")
            {
                button1.Text = "确认借出";
                label12.Text = "预归还日期：年：";
            }
            else
            {
                button1.Text = "确认归还";
                label12.Text = "归还日期：年：";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     /*   private void button1_Click(object sender, EventArgs e)
        {
            string bianhao= textBox1.Text;
            string gongqiju = textBox2.Text;
            string nian = textBox3.Text;
            string yue = textBox5.Text;
            string ri = textBox4.Text;
            string miaoshu = textBox6.Text;
            string xiangmu = textBox7.Text;
            if (string.IsNullOrEmpty(bianhao) || string.IsNullOrEmpty(gongqiju) ||
                string.IsNullOrEmpty(nian) || string.IsNullOrEmpty(yue) || string.IsNullOrEmpty(ri))
            {
                MessageBox.Show("请完整填写员工编号、工具编号、年、月、日！");
                return;
            }
            if (!int.TryParse(gongqiju, out int toolId))
            {
                MessageBox.Show("工具编号必须为数字！");
                return;
            }
            string dateStr = $"{nian}-{yue.PadLeft(2, '0')}-{ri.PadLeft(2, '0')}";
            if (!DateTime.TryParse(dateStr, out DateTime _))
            {
                MessageBox.Show("日期格式错误！");
                return;
            }

            string sqlStatus = $"select [资产状态] from Tools where [工器具编号] = {toolId}";
            DataTable dtStatus = linkclass.Query(sqlStatus);
            if (dtStatus.Rows.Count == 0)
            {
                MessageBox.Show("工具不存在！");
                return;
            }
            string status = dtStatus.Rows[0][0].ToString();

            if (comboBox2.Text == "借出")
            {
                if (status != "在库")
                {
                    MessageBox.Show($"该工具当前状态为“{status}”，无法借出！");
                    return;
                }
                if (string.IsNullOrEmpty(xiangmu) || !int.TryParse(xiangmu, out int projId))
                {
                    MessageBox.Show("请填写有效的项目编号（数字）！");
                    return;
                }
                string insert = $"insert into BorrowReturnRecords([项目编号],[员工编号],[工器具编号],[借出日期],[预归还日期],[归还日期],[设备去向])VALUES ({projId}, '{bianhao}', {toolId}, '{DateTime.Now:yyyy-MM-dd}', '{dateStr}', '9999-12-31', '{miaoshu}')";
                string update = $"update Tools set [资产状态] = '借出中' where [工器具编号] = {toolId}";

                linkclass.Execute(insert);
                linkclass.Execute(update);
                MessageBox.Show("借出成功！");
            }
            else if (comboBox2.Text == "归还")
            {
                if (status != "借出中")
                {
                    MessageBox.Show($"该工具当前状态为“{status}”，无法归还！");
                    return;
                }
                string check = $"select [记录编号] from BorrowReturnRecords where [工器具编号] = {toolId} and [归还日期] = '9999-12-31'";
                DataTable dtCheck = linkclass.Query(check);
                if (dtCheck.Rows.Count == 0)
                {
                    MessageBox.Show("该工具没有未归还记录，无法归还！");
                    return;
                }
                int recordId = Convert.ToInt32(dtCheck.Rows[0][0]);


                string update = $"update BorrowReturnRecords set [归还日期] = '{dateStr}' where [记录编号] = {recordId}";
                linkclass.Execute(update);

                linkclass.Execute($"UPDATE Tools SET [资产状态] = '在库' WHERE [工器具编号] = {toolId}");
                MessageBox.Show("归还成功！");

                
            }
            string refreshSql = "select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools;";
            DataTable dt = linkclass.Query(refreshSql);
            dataGridView1.DataSource = dt;

        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            string bianhao = textBox1.Text;
            string gongqiju = textBox2.Text;
            string nian = textBox3.Text;
            string yue = textBox5.Text;
            string ri = textBox4.Text;
            string miaoshu = textBox6.Text;
            string xiangmu = textBox7.Text;
            if (string.IsNullOrEmpty(bianhao) || string.IsNullOrEmpty(gongqiju) ||
                string.IsNullOrEmpty(nian) || string.IsNullOrEmpty(yue) || string.IsNullOrEmpty(ri))
            {
                MessageBox.Show("请完整填写员工编号、工具编号、年、月、日！");
                return;
            }
            if (!int.TryParse(gongqiju, out int toolId))
            {
                MessageBox.Show("工具编号必须为数字！");
                return;
            }
            string dateStr = $"{nian}-{yue.PadLeft(2, '0')}-{ri.PadLeft(2, '0')}";
            if (!DateTime.TryParse(dateStr, out DateTime _))
            {
                MessageBox.Show("日期格式错误！");
                return;
            }

            using (SqlConnection conn=new SqlConnection("Data Source=CHARLOTTE\\SQLEXPRESS;Initial Catalog =tools_ctrl;Integrated Security=True;TrustServerCertificate=true;"))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    string sqlStatus = $"select [资产状态] from Tools with (updlock) where [工器具编号] = {toolId}";


                    SqlCommand cmd = new SqlCommand(sqlStatus,conn,tran);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dtStatus = new DataTable();
                    ad.Fill(dtStatus);


                    //DataTable dtStatus = linkclass.Query(sqlStatus);


                    if (dtStatus.Rows.Count == 0)
                    {
                        MessageBox.Show("工具不存在！");
                        tran.Rollback();
                        return;
                    }
                    string status = dtStatus.Rows[0][0].ToString();

                    if (comboBox2.Text == "借出")
                    {
                        if (status != "在库")
                        {
                            MessageBox.Show($"该工具当前状态为“{status}”，无法借出！");
                            tran.Rollback();
                            return;
                        }
                        if (string.IsNullOrEmpty(xiangmu) || !int.TryParse(xiangmu, out int projId))
                        {
                            MessageBox.Show("请填写有效的项目编号（数字）！");
                            tran.Rollback();
                            return;
                        }
                        string insert = $"insert into BorrowReturnRecords([项目编号],[员工编号],[工器具编号],[借出日期],[预归还日期],[归还日期],[设备去向])VALUES ({projId}, '{bianhao}', {toolId}, '{DateTime.Now:yyyy-MM-dd}', '{dateStr}', '9999-12-31', '{miaoshu}')";
                        string update = $"update Tools set [资产状态] = '借出中' where [工器具编号] = {toolId}";

                        SqlCommand cmd1 = new SqlCommand(insert, conn, tran);
                        cmd1.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand(update, conn, tran);
                        cmd2.ExecuteNonQuery();

                        tran.Commit();
                        MessageBox.Show("借出成功！");
                    }
                    else if (comboBox2.Text == "归还")
                    {
                        if (status != "借出中")
                        {
                            MessageBox.Show($"该工具当前状态为“{status}”，无法归还！");
                            tran.Rollback();
                            return;
                        }
                        string check = $"select [记录编号] from BorrowReturnRecords where [工器具编号] = {toolId} and [归还日期] = '9999-12-31'";
                        SqlCommand cmd3 = new SqlCommand(check,conn,tran);
                        SqlDataAdapter ad3 = new SqlDataAdapter(cmd3);
                        DataTable dtCheck = new DataTable();

                        ad3.Fill(dtCheck);

                        if (dtCheck.Rows.Count == 0)
                        {
                            MessageBox.Show("该工具没有未归还记录，无法归还！");
                            tran.Rollback();
                            return;
                        }
                        int recordId = Convert.ToInt32(dtCheck.Rows[0][0]);


                        string update1 = $"update BorrowReturnRecords set [归还日期] = '{dateStr}' where [记录编号] = {recordId}";
                        string update2 = $"update Tools set [资产状态] = '在库' where [工器具编号] = {toolId}";
                        //linkclass.Execute(update1);
                        //linkclass.Execute(update2);
                        SqlCommand cmd4 = new SqlCommand(update1,conn,tran);
                        SqlCommand cmd5=new SqlCommand(update2, conn, tran);
                        cmd4.ExecuteNonQuery();
                        cmd5.ExecuteNonQuery();

                        MessageBox.Show("归还成功！");
                        tran.Commit();
                    }
                }
            }
            string refreshSql = "select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools;";
            DataTable dt = linkclass.Query(refreshSql);
            dataGridView1.DataSource = dt;
        }











        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
