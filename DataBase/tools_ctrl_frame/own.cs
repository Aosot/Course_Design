using System;
using System.Data;
using System.Windows.Forms;

namespace tools_ctrl_frame
{
    public partial class own : UserControl
    {
        public string CurrentUser;
        private string currentEmpId = "";

        public own()
        {
            InitializeComponent();
        }

        private void own_Load(object sender, EventArgs e)
        {
            LoadMyInfo();
        }
            
        public void LoadMyInfo()
        {
            if (string.IsNullOrEmpty(CurrentUser))
            {
                MessageBox.Show("未获取到当前用户信息！");
                return;
            }

            string sqlAccount = $"select * from AccountCtrl where [用户名] = '{CurrentUser}'";
            DataTable dtAccount = linkclass.Query(sqlAccount);
            if (dtAccount.Rows.Count == 0)
            {
                MessageBox.Show("用户不存在！");
                return;
            }

            DataRow rowAccount = dtAccount.Rows[0];
            string empId = Convert.ToString(rowAccount["员工编号"]);
            string nick = Convert.ToString(rowAccount["用户昵称"]);
            string perm = Convert.ToString(rowAccount["权限"]);
            string sig = Convert.ToString(rowAccount["个性签名"]);

            if (string.IsNullOrEmpty(empId))
            {
                panel2.Visible = false;
                panel3.Visible = false;

                label2.Text = "账号：" + CurrentUser;
                label4.Text = "昵称：" + nick;
                label3.Text = "密码：******";
                label6.Text = "权限：" + perm;
                label7.Text = "个性签名：" + (string.IsNullOrEmpty(sig) ? "（未设置）" : sig);

                MessageBox.Show("您还不是正式员工，请先联系管理员注册！", "提示");
                return;
            }

            panel2.Visible = true;
            panel3.Visible = true;
            currentEmpId = empId;

            label2.Text = "账号：" + CurrentUser;
            label4.Text = "昵称：" + nick;
            label3.Text = "密码：******";
            label6.Text = "权限：" + perm; 
            label7.Text = "个性签名：" + (string.IsNullOrEmpty(sig) ? "（未设置）" : sig);

            string sqlEmp = $"select * from Employees where [员工编号] = '{empId}'";
            DataTable dtEmp = linkclass.Query(sqlEmp);
            if (dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("员工信息不存在！");
                return;
            }

            DataRow rowEmp = dtEmp.Rows[0];

            label24.Text = "员工编号：" + Convert.ToString(rowEmp["员工编号"]);
            label23.Text = "姓名：" + Convert.ToString(rowEmp["姓名"]);
            label22.Text = "性别：" + Convert.ToString(rowEmp["性别"]);
            label8.Text = "出生日：" + Convert.ToString(rowEmp["出生日"]);

            string deptId = Convert.ToString(rowEmp["所属部门"]);
            string deptName = "---";
            if (!string.IsNullOrEmpty(deptId))
            {
                string sqlDept = $"select * from Department where [编号] = {deptId}";
                DataTable dtDept = linkclass.Query(sqlDept);
                if (dtDept.Rows.Count > 0)
                    deptName = Convert.ToString(dtDept.Rows[0]["部门名称"]);
            }
            label21.Text = "所属部门：" + deptName;

            label5.Text = "职务：" + Convert.ToString(rowEmp["职务"]);
            label20.Text = "联系电话：" + Convert.ToString(rowEmp["联系电话"]);
            label19.Text = "电子邮箱：" + Convert.ToString(rowEmp["电子邮箱"]);
            label18.Text = "身份证号：" + Convert.ToString(rowEmp["身份证号"]);
            label10.Text = "政治面貌：" + Convert.ToString(rowEmp["政治面貌"]);
            label11.Text = "学历：" + Convert.ToString(rowEmp["学历"]);
            label9.Text = "员工状态：" + Convert.ToString(rowEmp["员工状态"]);
        }

       

        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUser))
            {
                MessageBox.Show("未获取到当前用户！");
                return;
            }

            string field = comboBox2.Text;
            string newValue = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("请完整填写信息！");
                return;
            }

            string sql = "";
            if (field == "昵称")
                sql = $"update AccountCtrl set [用户昵称] = '{newValue}' where [用户名] = '{CurrentUser}'";
            else if (field == "密码")
            {
                string salt = passwordclass.GenerateSalt();
                string hash = passwordclass.HashPassword(newValue, salt);
                sql = $"update AccountCtrl set [密码] = '{hash}', [盐] = '{salt}' where [用户名] = '{CurrentUser}'";
            }
            else if (field == "个性签名")
                sql = $"update AccountCtrl set [个性签名] = '{newValue}' where [用户名] = '{CurrentUser}'";
            else
            {
                MessageBox.Show("无效属性！");
                return;
            }

            linkclass.Execute(sql);
            MessageBox.Show("修改成功！");
            LoadMyInfo();
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentEmpId))
            {
                MessageBox.Show("无员工编号，无法修改！");
                return;
            }

            string field = comboBox1.Text;
            string newValue = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("请完整填写信息！");
                return;
            }

            string col = "";
            if (field == "员工编号") col = "员工编号";
            else if (field == "姓名") col = "姓名";
            else if (field == "性别") col = "性别";
            else if (field == "所属部门") col = "所属部门";
            else if (field == "联系电话") col = "联系电话";
            else if (field == "身份证号") col = "身份证号";
            else if (field == "电子邮箱") col = "电子邮箱";
            else if (field == "政治面貌") col = "政治面貌";
            else if (field == "学历") col = "学历";
            else if (field == "出生日") col = "出生日";
            else if (field == "职务") col = "职务";
            else { MessageBox.Show("无效属性！"); return; }

            string sql = $"update Employees set [{col}] = '{newValue}' where [员工编号] = '{currentEmpId}'";
            linkclass.Execute(sql);
            MessageBox.Show("修改成功！");
            LoadMyInfo();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}