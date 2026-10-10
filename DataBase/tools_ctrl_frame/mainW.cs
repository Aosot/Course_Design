using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tools_ctrl_frame.admin;
using tools_ctrl_frame.user_execute;
using tools_ctrl_frame.user_query;

namespace tools_ctrl_frame
{
    public partial class mainW : Form
    {
        public string account;
        public string type;
        public int permission = 3;
       
        public mainW()
        {
            InitializeComponent();
        }


        private bool CheckPermission(string name)
        {

            if (name == "我的") return true;


            if (permission == 0) return true;


            if (permission == 1)
            {
                if (name == "员工管理" || name == "工器具管理" || name == "表查询" || name == "条码生成")
                {
                    MessageBox.Show("权限不足：需要管理员权限。", "权限不足");
                    return false;
                }
                return true;
            }


            if (permission == 2)
            {
                string[] allow = new string[] { "借还工器具", "申请维修", "申报报废", "项目信息查询", "部门信息查询", "工器具信息查询", "工器具查询", "项目查询", "借还情况查询"};
                if (allow.Contains(name)) return true;
                MessageBox.Show("权限不足：该操作仅限员工或更高级别用户。", "权限不足");
                return false;
            }


            string[] guestAllow = new string[] { "工器具信息查询", "项目信息查询", "部门信息查询", "工器具查询", "项目查询", "借还情况查询" };
            if (guestAllow.Contains(name)) return true;
            MessageBox.Show("权限不足：游客只能进行有限的查询。", "权限不足");
            return false;
        }

        private void mainW_Load(object sender, EventArgs e)
        {
            if (account == "0")
            {
                label1.Text = "开发者模式";
                label1.ForeColor = Color.DarkRed;
                permission = 0;
            }
            else
            {
                string sql = $"select [用户名],[权限] from AccountCtrl where [{type}]='{account}'";
                DataTable dt = new DataTable();
                dt = linkclass.Query(sql);
                if (dt.Rows.Count > 0)
                {
                    string nickname = Convert.ToString(dt.Rows[0][0]);
                    label1.Text = "当前登录用户:  " + nickname;
                    string permStr = Convert.ToString(dt.Rows[0][1]);
                    if (!int.TryParse(permStr, out permission)) permission = 3;
                }
                else
                {
                    label1.Text = "未识别的用户";
                    permission = 3;
                }
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dasdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 项目查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("项目查询")) return;
            panel2.Controls.Clear();
            projectQ pq = new projectQ();
            pq.Dock = DockStyle.Fill;
            panel2.Controls.Add(pq);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node == null) return;
            if (e.Node.Nodes.Count > 0) return;

            if (!CheckPermission(e.Node.Text)) return;

            if(e.Node.Text=="工器具信息查询")
            {
                panel2.Controls.Clear();
                toolQ tq = new toolQ();
                tq.Dock= DockStyle.Fill;
                panel2.Controls.Add(tq);

            }
            else if (e.Node.Text == "员工信息查询")
            {
                panel2.Controls.Clear();
                employeeQ tq = new employeeQ();
                tq.Dock = DockStyle.Fill;
                panel2.Controls.Add(tq);
            }
            else if (e.Node.Text == "项目信息查询")
            {
                panel2.Controls.Clear();
                projectQ pq = new projectQ();
                pq.Dock = DockStyle.Fill;
                panel2.Controls.Add(pq);
            }
            else if (e.Node.Text == "部门信息查询")
            {
                panel2.Controls.Clear();
                departmentQ dq= new departmentQ();
                dq.Dock = DockStyle.Fill;
                panel2.Controls.Add(dq);
            }
            else if (e.Node.Text == "维修查询")
            {
                panel2.Controls.Clear();
                repairQ rq = new repairQ();
                rq.Dock = DockStyle.Fill;
                panel2.Controls.Add(rq);
            }
            else if (e.Node.Text == "报废查询")
            {
                panel2.Controls.Clear();
                scrapQ sq= new scrapQ();
                sq.Dock= DockStyle.Fill;
                panel2.Controls.Add(sq);
            }
            else if (e.Node.Text == "借还情况查询")
            {
                panel2.Controls.Clear();
                BRQ bq = new BRQ();
                bq.Dock = DockStyle.Fill;
                panel2.Controls.Add(bq);
            }
            else if (e.Node.Text == "借还工器具")
            {
                BR br= new BR();
                br.ShowDialog();
            }
            else if (e.Node.Text == "申请维修")
            {
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else if (e.Node.Text == "申报报废")
            {
                Form2 f1 = new Form2();
                f1.ShowDialog();
            }
            else if(e.Node.Text=="设置")
            {
                panel2.Controls.Clear();
                settings ss = new settings();
                ss.Dock = DockStyle.Fill;
                panel2.Controls.Add(ss);
            }
            else if(e.Node.Text=="员工管理")
            {
                emp_audit ea= new emp_audit();
                ea.ShowDialog();
            }
            else if (e.Node.Text == "工器具管理")
            {
                tool_add ta = new tool_add();
                ta.ShowDialog();
            }
            else if (e.Node.Text == "我的")
            {
                panel2.Controls.Clear();
                own my = new own();
                my.CurrentUser = account;
                my.Dock = DockStyle.Fill;
                panel2.Controls.Add(my);
            }
            else if (e.Node.Text == "表查询")
            {
                table t= new table();
                t.ShowDialog();
            }
            else if(e.Node.Text=="条码生成")
            {
                QR qr = new QR();
                qr.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void 工器具操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 工器具查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            toolQ tq = new toolQ();
            tq.Dock = DockStyle.Fill;
            panel2.Controls.Add(tq);
        }

        private void 员工信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("员工信息查询")) return;
            panel2.Controls.Clear();
            employeeQ tq = new employeeQ();
            tq.Dock = DockStyle.Fill;
            panel2.Controls.Add(tq);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 部门信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("部门信息查询")) return;
            panel2.Controls.Clear();
            departmentQ dq = new departmentQ();
            dq.Dock = DockStyle.Fill;
            panel2.Controls.Add(dq);
        }

        private void 借还工器具ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("借还工器具")) return;
            BR br = new BR();
            br.ShowDialog();
        }

        private void 数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 报废查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("报废查询")) return;
            panel2.Controls.Clear();
            scrapQ sq=new scrapQ();
            sq.Dock= DockStyle.Fill;
            panel2.Controls.Add(sq);
        }

        private void 借还情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("借还情况查询")) return;
            panel2.Controls.Clear();
            BRQ bq = new BRQ();
            bq.Dock = DockStyle.Fill;
            panel2.Controls.Add(bq);
        }

        private void 维修查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("维修查询")) return;
            panel2.Controls.Clear();
            repairQ rq = new repairQ();
            rq.Dock = DockStyle.Fill;
            panel2.Controls.Add(rq);
        }

        private void 我的ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            own my = new own();
            my.CurrentUser = account; 
            my.Dock = DockStyle.Fill;
            panel2.Controls.Add(my);
        }

        private void 申请维修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("申请维修")) return;
            Form1 f1=new Form1();
            f1.ShowDialog();
        }

        private void 申报报废ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("申报报废")) return;
            Form2 f1 = new Form2();
            f1.ShowDialog();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            settings ss = new settings();
            ss.Dock = DockStyle.Fill;
            panel2.Controls.Add(ss);
        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("员工管理")) return;
            emp_audit ea = new emp_audit();
            ea.ShowDialog();
        }

        private void 工器具管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("工器具管理")) return;
            tool_add ta = new tool_add();
            ta.ShowDialog();
        }

        private void 表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("表查询")) return;
            table t = new table();
            t.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AIhelp ai=new AIhelp();
            ai.ShowDialog();
        }

        private void 条码生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckPermission("条码生成")) return;
            QR qr=new QR();
            qr.ShowDialog();
        }
    }
}
