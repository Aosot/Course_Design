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
    public partial class departmentQ : UserControl
    {
        public departmentQ()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void departmentQ_Load(object sender, EventArgs e)
        {
            string sql = "select * from Department;";
            DataTable dt = new DataTable();
            dt = linkclass.Query(sql);
            dataGridView1.DataSource = dt;
        }
    }
}
