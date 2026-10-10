using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using tools_ctrl_web.Data;

namespace tools_ctrl_web.Pages
{
    public class SCModel : PageModel
    {
        [BindProperty] public string ToolId { get; set; }
        [BindProperty] public string Applicant { get; set; }
        [BindProperty] public string Year { get; set; }
        [BindProperty] public string Month { get; set; }
        [BindProperty] public string Day { get; set; }

        public string Message { get; set; }
        public string Error { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToPage("/Login");
            return Page();
        }

        public IActionResult OnPost()
        {
            // 1. 工具编号校验
            if (string.IsNullOrEmpty(ToolId) || !int.TryParse(ToolId, out int toolId))
            {
                Error = "请输入有效的工器具编号（数字）！";
                return Page();
            }
            // 2. 申报人非空
            if (string.IsNullOrEmpty(Applicant))
            {
                Error = "请输入申报人编号！";
                return Page();
            }
            // 3. 日期完整
            if (string.IsNullOrEmpty(Year) || string.IsNullOrEmpty(Month) || string.IsNullOrEmpty(Day))
            {
                Error = "请完整填写报废日期（年、月、日）！";
                return Page();
            }

            string dateStr = $"{Year}-{Month.PadLeft(2, '0')}-{Day.PadLeft(2, '0')}";
            if (!DateTime.TryParse(dateStr, out DateTime _))
            {
                Error = "报废日期格式错误！";
                return Page();
            }

            // 4. 查工具状态和名称
            DataTable dtStatus = linkclass.Query($"select [资产状态], [名称] from Tools where [工器具编号] = {toolId}");
            if (dtStatus.Rows.Count == 0)
            {
                Error = "工器具编号不存在！";
                return Page();
            }
            string status = Convert.ToString(dtStatus.Rows[0]["资产状态"]);
            string toolName = Convert.ToString(dtStatus.Rows[0]["名称"]);

            if (status != "在库")
            {
                Error = $"该工具当前状态为“{status}”，只有“在库”状态的工具才能申报报废！";
                return Page();
            }

            // 5. 申报人必须存在
            DataTable dtEmp = linkclass.Query($"select count(*) from Employees where [员工编号] = '{Applicant}'");
            if (Convert.ToInt32(dtEmp.Rows[0][0]) == 0)
            {
                Error = "申报人编号不存在！";
                return Page();
            }

            // 6. 插入报废记录
            string insertSql = $@"insert into ScrapRecords 
                ([名称], [工器具编号], [报废日期], [报废申报人], [申报日期])
                values ('{toolName}', {toolId}, '{dateStr}', '{Applicant}', '{DateTime.Now:yyyy-MM-dd}')";
            linkclass.Execute(insertSql);

            // 7. 更新工具状态
            linkclass.Execute($"update Tools set [资产状态] = '已报废' where [工器具编号] = {toolId}");

            Message = "报废申报成功！";
            return Page();
        }
    }
}