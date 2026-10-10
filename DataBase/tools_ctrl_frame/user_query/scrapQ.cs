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
    public partial class scrapQ : UserControl
    {
        public scrapQ()
        {
            InitializeComponent();
        }

        private void scrapQ_Load(object sender, EventArgs e)
        {
            string sql = "select * from ScrapRecords;";
            DataTable dt = new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s=bianhaobox.Text;
            string sql = $"select * from ScrapRecords where 1=1 and [工器具编号] = {s}";
            DataTable dt= new DataTable();
            dt = linkclass.Query(sql);
            dataGridView3.DataSource = dt;
        }
    }
}
