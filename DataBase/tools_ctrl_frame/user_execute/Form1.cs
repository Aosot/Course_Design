using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tools_ctrl_frame.user_execute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string sql = "SELECT [工器具编号],[名称],[类别],[资产状态] FROM Tools WHERE [资产状态] = '维修中'";
            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void UpdateUI()
        {
            if (checkBox1.Checked)
            {
                label3.Visible = false;
                textBox3.Visible = false;
                label9.Visible = false;
                textBox5.Visible = false;
                label8.Visible = false;
                textBox4.Visible = false;
                label4.Visible = false;
                textBox6.Visible = false;
                button1.Text = "确认维修完成";
            }
            else
            {
                label3.Visible = true;
                textBox3.Visible = true;
                label9.Visible = true;
                textBox5.Visible = true;
                label8.Visible = true;
                textBox4.Visible = true;
                label4.Visible = true;
                textBox6.Visible = true;
                button1.Text = "确认维修申请";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string toolIdStr = xinghaobox.Text.Trim();
            string applicant = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(toolIdStr) || !int.TryParse(toolIdStr, out int toolId))
            {
                MessageBox.Show("请输入有效的工器具编号（数字）！");
                return;
            }
            if (string.IsNullOrEmpty(applicant))
            {
                MessageBox.Show("请输入申请人编号！");
                return;
            }

            string sqlStatus = $"SELECT [资产状态] FROM Tools WHERE [工器具编号] = {toolId}";
            DataTable dtStatus = linkclass.Query(sqlStatus);
            if (dtStatus.Rows.Count == 0)
            {
                MessageBox.Show("工器具编号不存在！");
                return;
            }
            string status = dtStatus.Rows[0][0].ToString();

            string checkEmp = $"SELECT COUNT(*) FROM Employees WHERE [员工编号] = '{applicant}'";
            DataTable dtEmp = linkclass.Query(checkEmp);
            if (Convert.ToInt32(dtEmp.Rows[0][0]) == 0)
            {
                MessageBox.Show("申请人编号不存在！");
                return;
            }

            if (checkBox1.Checked)
            {
                if (status != "维修中")
                {
                    MessageBox.Show($"该工具当前状态为“{status}”，无法完成维修！");
                    return;
                }
                string findSql = $"select top 1 [编号] from RepairRecords where [工具编号] = {toolId} and [完成日期] is null";
                DataTable dtFind = linkclass.Query(findSql);
                if (dtFind.Rows.Count == 0)
                {
                    MessageBox.Show("该工具没有未完成的维修记录！");
                    return;
                }
                int recordId = Convert.ToInt32(dtFind.Rows[0][0]);

                string updateSql = $"update RepairRecords set [完成日期] = '{DateTime.Now:yyyy-MM-dd}' where [编号] = {recordId}";
                linkclass.Execute(updateSql);
                linkclass.Execute($"update Tools set [资产状态] = '在库', [维修次数] = [维修次数] + 1 where [工器具编号] = {toolId}");

                MessageBox.Show("维修完成！");
            }
            else
            {
                if (status != "在库")
                {
                    MessageBox.Show($"该工具当前状态为“{status}”，无法申请维修！");
                    return;
                }
                string year = textBox3.Text.Trim();
                string month = textBox5.Text.Trim();
                string day = textBox4.Text.Trim();
                if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month) || string.IsNullOrEmpty(day))
                {
                    MessageBox.Show("请完整填写维修日期（年、月、日）！");
                    return;
                }
                string dateStr = $"{year}-{month.PadLeft(2, '0')}-{day.PadLeft(2, '0')}";
                if (!DateTime.TryParse(dateStr, out DateTime _))
                {
                    MessageBox.Show("维修日期格式错误！");
                    return;
                }

                string description = textBox6.Text.Trim();
                string insertSql = $@"insert into RepairRecords 
                        ([工具编号], [维修日期], [完成日期], [负责部门], [负责人], [申请人], [情况概述])
                        values ({toolId}, '{dateStr}', null, 2, 'CG041', '{applicant}', '{description}')";
                linkclass.Execute(insertSql);
                linkclass.Execute($"update Tools set [资产状态] = '维修中' where [工器具编号] = {toolId}");

                MessageBox.Show("维修申请成功！");
            }

            string sql = "select [工器具编号],[名称],[类别],[资产状态] from Tools where [资产状态] = '维修中'";
            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}