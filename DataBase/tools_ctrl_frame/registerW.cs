using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tools_ctrl_frame
{
    public partial class registerW : Form
    {
        private string currentCaptcha = "";
        private PictureBox picCaptcha;
        public registerW()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string nickname = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            string contact = textBox5.Text.Trim();
            string reason = textBox6.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(nickname))
            {
                MessageBox.Show("用户昵称不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            string checkqql = $"select count(*) from Registers where [用户名] = '{username}'";
            DataTable dt = linkclass.Query(checkqql);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            string checkExist = $"select count(*) from AccountCtrl where [用户名] = '{username}'";
            DataTable dtExist = linkclass.Query(checkExist);
            int ecount = Convert.ToInt32(dtExist.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("该用户名已提交申请，请等待管理员审核！");
                return;
            }
            if (ecount > 0)
            {
                MessageBox.Show("该用户名已被正式注册，请更换！");
                return;
            }

            string inputCaptcha = textBox4.Text.Trim();
            if (string.IsNullOrEmpty(inputCaptcha) || !string.Equals(inputCaptcha, currentCaptcha, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("验证码错误！");
                GenerateCaptcha();
                return;
            }

            string insertSql = $@"insert into Registers 
                                ([用户名], [用户昵称], [密码], [联系方式], [申请原因]) 
                                values 
                                ('{username}', '{nickname}', '{password}', '{contact}', '{reason}')";

            int rows = linkclass.Execute(insertSql);
            if (rows > 0)
            {
                MessageBox.Show("注册已提交，请等待管理员联系！");
            }
            else
            {
                MessageBox.Show("注册失败，请重试。");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerW_Load(object sender, EventArgs e)
        {
            
            picCaptcha = this.pictureBoxCaptcha;
            this.pictureBoxCaptcha.Click += new EventHandler((s, ea) => { GenerateCaptcha(); });
            GenerateCaptcha();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random r = new Random();
            char[] buf = new char[4];
            for (int i = 0; i < 4; i++) buf[i] = chars[r.Next(chars.Length)];
            currentCaptcha = new string(buf);

            Bitmap bmp = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                for (int i = 0; i < 6; i++)
                {
                    int x1 = r.Next(bmp.Width);
                    int y1 = r.Next(bmp.Height);
                    int x2 = r.Next(bmp.Width);
                    int y2 = r.Next(bmp.Height);
                    g.DrawLine(Pens.Gray, x1, y1, x2, y2);
                }
                using (Font font = new Font("Arial", 20, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.DrawString(currentCaptcha, font, brush, new PointF(8, 5));
                }
            }
            picCaptcha.Image = bmp;
        }

        private void pictureBoxCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
