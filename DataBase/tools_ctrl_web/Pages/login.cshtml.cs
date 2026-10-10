using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tools_ctrl_web.Data;

namespace tools_ctrl_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Account { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Error { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password))
            {
                Error = "账号或密码不能为空！";
                return Page();
            }

            // 去数据库验证真实密码
            bool ok = passwordclass.VerifyLogin("用户名", Account, Password);

            if (ok)
            {
                // 验证通过，把用户名存进 Session
                HttpContext.Session.SetString("user", Account);
                // 跳到主页
                return RedirectToPage("/Index");
            }

            Error = "账号或密码错误！";
            return Page();
        }
    }
}