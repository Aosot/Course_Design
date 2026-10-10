using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace tools_ctrl_web.Data
{
    public class passwordclass
    {
        public static string GenerateSalt()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
        }

        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.Unicode.GetBytes(password + salt));
                string result = "";
                foreach (byte b in bytes)
                    result += b.ToString("X2");
                return result;
            }
        }

        public static bool VerifyPassword(string inputPassword, string salt, string storedHash)
        {
            return HashPassword(inputPassword, salt) == storedHash;
        }

        public static bool VerifyLogin(string type, string account, string password)
        {
            string sql = $"select [密码],[盐] from AccountCtrl where [{type}]='{account}'";
            DataTable dt = linkclass.Query(sql);
            if (dt.Rows.Count == 0) return false;

            string storedHash = Convert.ToString(dt.Rows[0]["密码"]);
            string salt = Convert.ToString(dt.Rows[0]["盐"]);
            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(salt)) return false;

            return VerifyPassword(password, salt, storedHash);
        }
    }
}