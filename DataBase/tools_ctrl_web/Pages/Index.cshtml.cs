using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tools_ctrl_web.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentUser { get; set; }

        public IActionResult OnGet()
        {
            CurrentUser = HttpContext.Session.GetString("user");

            if (string.IsNullOrEmpty(CurrentUser))
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}