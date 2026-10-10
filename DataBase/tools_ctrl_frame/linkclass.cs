using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace tools_ctrl_frame
{
    internal class linkclass
    {
        private static string connectkey = 
            "Data Source=CHARLOTTE\\SQLEXPRESS;Initial Catalog =tools_ctrl;Integrated Security=True;TrustServerCertificate=true;";
        public static DataTable Query(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=new SqlConnection(connectkey))
            using (SqlCommand cmd=new SqlCommand(sql,conn))
            using (SqlDataAdapter ad=new SqlDataAdapter(cmd))
            {
                conn.Open();
                ad.Fill(dt);
            }
            return dt;
        }
        public static DataTable Query(string sql,params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=new SqlConnection(connectkey))
            using (SqlCommand cmd=new SqlCommand(sql,conn))
            using (SqlDataAdapter ad=new SqlDataAdapter(cmd))
            {
                conn.Open();
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                ad.Fill(dt);
            }
            return dt;
        }
        public static int Execute(string sql)
        {
            using (SqlConnection conn=new SqlConnection(connectkey))
            using (SqlCommand cmd=new SqlCommand(sql,conn))
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
