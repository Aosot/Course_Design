using Microsoft.Data.SqlClient;
using System.Data;

namespace tools_ctrl_web.Data
{
    public class linkclass
    {
        private static string connectkey = "Data Source=CHARLOTTE\\SQLEXPRESS;Initial Catalog=tools_ctrl;Integrated Security=True;TrustServerCertificate=true;";

        public static DataTable Query(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectkey))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            {
                conn.Open();
                ad.Fill(dt);
            }
            return dt;
        }

        public static int Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectkey))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}