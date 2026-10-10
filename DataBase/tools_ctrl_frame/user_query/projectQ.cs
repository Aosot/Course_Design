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
    public partial class projectQ : UserControl
    {
        public projectQ()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void projectQ_Load(object sender, EventArgs e)
        {
            string sql = "select * from Projects;";
            DataTable dt = new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }
    }
}
