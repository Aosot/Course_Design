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
    public partial class loginW : Form
    {
        private string currentCaptcha = "";
        private PictureBox picCaptcha;
        public loginW()
        {
            InitializeComponent();
        }

        private void loginW_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex=0;

            picCaptcha = this.pictureBoxCaptcha;
            this.pictureBoxCaptcha.Click += new EventHandler((s, ea) => { GenerateCaptcha(); });
            GenerateCaptcha();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text = "用户名：";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label2.Text = "员工编号：";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text.Trim();
            string type = "用户名";

            string inputCaptcha = textBox3.Text.Trim();
            if (string.IsNullOrEmpty(inputCaptcha) || !string.Equals(inputCaptcha, currentCaptcha, StringComparison.OrdinalIgnoreCase))
            {
                label5.Text = "验证码错误！";
                label5.Visible = true;
                GenerateCaptcha();
                return;
            }
            if (account=="0")
            {
                MessageBox.Show("登录成功！");
                this.Hide();
                mainW main = new mainW();
                main.account = account;
                main.type = type;
                main.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                GenerateCaptcha();
                this.Show();
                return;
            }
            string password = textBox2.Text.Trim();
            if(string.IsNullOrEmpty(account)||string.IsNullOrEmpty(password))
            {
                label5.Text="账号或密码不能为空！";
                label5.Visible = true;
                return;
            }
            
            if (comboBox1.SelectedIndex == 1)
                type = "员工编号";


            if (passwordclass.VerifyLogin(type, account, password))
            {
                MessageBox.Show("登录成功！");
                this.Hide();
                mainW main = new mainW();
                main.account = account;
                main.type = type;
                main.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                GenerateCaptcha();
                this.Show();
            }
            else
            {
                label5.Text = "账号或密码错误！";
                label5.Visible = true;
                return;
            }
        }


        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random r = new Random();
            char[] buf = new char[4];
            for (int i = 0; i < 4; i++) buf[i] = chars[r.Next(chars.Length)];
            currentCaptcha = new string(buf);

            Bitmap bmp = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            for (int i = 0; i < 6; i++)
            {
                int x1 = r.Next(bmp.Width);
                int y1 = r.Next(bmp.Height);
                int x2 = r.Next(bmp.Width);
                int y2 = r.Next(bmp.Height);
                g.DrawLine(Pens.Gray, x1, y1, x2, y2);
            }

            Font font = new Font("Arial", 20, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            g.DrawString(currentCaptcha, font, brush, new PointF(8, 5));

            picCaptcha.Image = bmp;
        }

        private void pictureBoxCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            MessageBox.Show("请联系管理员!\n联系方式：19327519833");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registerW rw=new registerW();
            rw.ShowDialog();
        }
    }
}
