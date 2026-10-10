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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = "申报日期：" + DateTime.Now.ToString("yyyy年MM月dd日");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bianhao = textBox2.Text.Trim();
            string shenbaoren = textBox1.Text.Trim();
            string nian = textBox3.Text.Trim();
            string yue = textBox5.Text.Trim();
            string ri = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(bianhao) || !int.TryParse(bianhao, out int toolId))
            {
                MessageBox.Show("请输入有效的工器具编号（数字）！");
                return;
            }
            if (string.IsNullOrEmpty(shenbaoren))
            {
                MessageBox.Show("请输入申报人编号！");
                return;
            }
            if (string.IsNullOrEmpty(nian) || string.IsNullOrEmpty(yue) || string.IsNullOrEmpty(ri))
            {
                MessageBox.Show("请完整填写报废日期（年、月、日）！");
                return;
            }

            string dateStr = $"{nian}-{yue.PadLeft(2, '0')}-{ri.PadLeft(2, '0')}";
            if (!DateTime.TryParse(dateStr, out DateTime _))
            {
                MessageBox.Show("报废日期格式错误！");
                return;
            }

            string sqlStatus = $"select [资产状态], [名称] from Tools where [工器具编号] = {toolId}";
            DataTable dtStatus = linkclass.Query(sqlStatus);
            if (dtStatus.Rows.Count == 0)
            {
                MessageBox.Show("工器具编号不存在！");
                return;
            }
            string status = dtStatus.Rows[0]["资产状态"].ToString();
            string toolName = dtStatus.Rows[0]["名称"].ToString();

            if (status != "在库")
            {
                MessageBox.Show($"该工具当前状态为“{status}”，只有“在库”状态的工具才能申报报废！");
                return;
            }

            string checkEmp = $"select count(*) from Employees where [员工编号] = '{shenbaoren}'";
            DataTable dtEmp = linkclass.Query(checkEmp);
            if (Convert.ToInt32(dtEmp.Rows[0][0]) == 0)
            {
                MessageBox.Show("申报人编号不存在！");
                return;
            }

            string insertSql = $@"insert into ScrapRecords 
                ([名称], [工器具编号], [报废日期], [报废申报人], [申报日期])
                values ('{toolName}', {toolId}, '{dateStr}', '{shenbaoren}', '{DateTime.Now:yyyy-MM-dd}')";
            int rows = linkclass.Execute(insertSql);
            if (rows == 0)
            {
                MessageBox.Show("报废申报插入失败！");
                return;
            }

            linkclass.Execute($"update Tools set [资产状态] = '已报废' where [工器具编号] = {toolId}");

            MessageBox.Show("报废申报成功！");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
