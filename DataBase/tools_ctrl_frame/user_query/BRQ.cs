using System;
using System.Data;
using System.Windows.Forms;

namespace tools_ctrl_frame.user_query
{
    public partial class BRQ : UserControl
    {
        public BRQ()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string sql = "select * from View_test;";
            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void BRQ_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cols = "";

            if (checkBox1.Checked) cols += "[记录编号],";
            if (checkBox2.Checked) cols += "[员工编号],";
            if (checkBox3.Checked) cols += "[项目编号],";
            if (checkBox4.Checked) cols += "[工器具编号],";
            if (checkBox5.Checked) cols += "[资产状态],";
            if (checkBox6.Checked) cols += "[名称],";
            if (checkBox7.Checked) cols += "[计量单位],";
            if (checkBox8.Checked) cols += "[型号],";
            if (checkBox9.Checked) cols += "[项目名称],";
            if (checkBox10.Checked) cols += "[姓名],";
            if (checkBox11.Checked) cols += "[性别],";
            if (checkBox12.Checked) cols += "[借出日期],";
            if (checkBox13.Checked) cols += "[预归还日期],";
            if (checkBox14.Checked) cols += "[归还日期],";
            if (checkBox15.Checked) cols += "[设备去向],";
            if (checkBox16.Checked) cols += "[类别],";
            if (checkBox17.Checked) cols += "[电压等级],";
            if (checkBox18.Checked) cols += "[工器具所属部门],";
            if (checkBox19.Checked) cols += "[保管人],";
            if (checkBox20.Checked) cols += "[申请人所属部门],";
            if (checkBox21.Checked) cols += "[职务],";
            if (checkBox22.Checked) cols += "[联系电话],";
            if (checkBox23.Checked) cols += "[电子邮箱],";
            if (checkBox24.Checked) cols += "[身份证号],";
            if (checkBox25.Checked) cols += "[政治面貌],";

            if (cols.EndsWith(","))
                cols = cols.Substring(0, cols.Length - 1);

            if (string.IsNullOrEmpty(cols))
                cols = "[记录编号],[工器具编号]";

            string sql = "select " + cols + " from View_test where 1=1";

            string projId = xmbh.Text.Trim();
            string empId = ygbh.Text.Trim();
            string toolId = gqjbh.Text.Trim();
            string projName = xmmc.Text.Trim();
            string empName = ygmc.Text.Trim();
            string toolName = gqjmc.Text.Trim();
            string y = nian.Text.Trim();
            string m = yue.Text.Trim();
            string d = ri.Text.Trim();

            if (!string.IsNullOrEmpty(projId))
                sql += $" and cast([项目编号] as nvarchar(20)) like '%{projId}%'";

            if (!string.IsNullOrEmpty(toolId))
                sql += $" and cast([工器具编号] as nvarchar(20)) like '%{toolId}%'";

            if (!string.IsNullOrEmpty(empId))
                sql += $" and [员工编号] like '%{empId}%'";

            if (!string.IsNullOrEmpty(projName))
                sql += $" and [项目名称] like '%{projName}%'";

            if (!string.IsNullOrEmpty(empName))
                sql += $" and [姓名] like '%{empName}%'";

            if (!string.IsNullOrEmpty(toolName))
                sql += $" and [名称] like '%{toolName}%'";

            if (!string.IsNullOrEmpty(y) && !string.IsNullOrEmpty(m) && !string.IsNullOrEmpty(d))
            {
                string dateStr = $"{y}-{m.PadLeft(2, '0')}-{d.PadLeft(2, '0')}";
                sql += $" and convert(varchar(10), [借出日期], 23) like '%{dateStr}%'";
            }

            DataTable dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}