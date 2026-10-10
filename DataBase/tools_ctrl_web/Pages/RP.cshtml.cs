using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using tools_ctrl_web.Data;

namespace tools_ctrl_web.Pages
{
    public class RPModel : PageModel
    {
        [BindProperty] public string Action { get; set; }
        [BindProperty] public string ToolId { get; set; }
        [BindProperty] public string Applicant { get; set; }
        [BindProperty] public string Year { get; set; }
        [BindProperty] public string Month { get; set; }
        [BindProperty] public string Day { get; set; }
        [BindProperty] public string Description { get; set; }

        public string Message { get; set; }
        public string Error { get; set; }
        public DataTable RepairingTools { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToPage("/Login");

            RefreshRepairingTools();
            return Page();
        }

        public IActionResult OnPost()
        {
            // 1. 工具编号校验
            if (string.IsNullOrEmpty(ToolId) || !int.TryParse(ToolId, out int toolId))
            {
                Error = "请输入有效的工器具编号（数字）！";
                RefreshRepairingTools();
                return Page();
            }
            if (string.IsNullOrEmpty(Applicant))
            {
                Error = "请输入申请人编号！";
                RefreshRepairingTools();
                return Page();
            }

            // 2. 查工具状态
            DataTable dtStatus = linkclass.Query($"select [资产状态] from Tools where [工器具编号] = {toolId}");
            if (dtStatus.Rows.Count == 0)
            {
                Error = "工器具编号不存在！";
                RefreshRepairingTools();
                return Page();
            }
            string status = Convert.ToString(dtStatus.Rows[0]["资产状态"]);

            // 3. 申请人必须存在
            DataTable dtEmp = linkclass.Query($"select count(*) from Employees where [员工编号] = '{Applicant}'");
            if (Convert.ToInt32(dtEmp.Rows[0][0]) == 0)
            {
                Error = "申请人编号不存在！";
                RefreshRepairingTools();
                return Page();
            }

            if (Action == "维修完成")
            {
                if (status != "维修中")
                {
                    Error = $"该工具当前状态为“{status}”，无法完成维修！";
                    RefreshRepairingTools();
                    return Page();
                }
                DataTable dtFind = linkclass.Query($"select top 1 [编号] from RepairRecords where [工具编号] = {toolId} and [完成日期] is null");
                if (dtFind.Rows.Count == 0)
                {
                    Error = "该工具没有未完成的维修记录！";
                    RefreshRepairingTools();
                    return Page();
                }
                int recordId = Convert.ToInt32(dtFind.Rows[0]["编号"]);

                linkclass.Execute($"update RepairRecords set [完成日期] = '{DateTime.Now:yyyy-MM-dd}' where [编号] = {recordId}");
                linkclass.Execute($"update Tools set [资产状态] = '在库', [维修次数] = [维修次数] + 1 where [工器具编号] = {toolId}");
                Message = "维修完成！";
            }
            else
            {
                if (status != "在库")
                {
                    Error = $"该工具当前状态为“{status}”，无法申请维修！";
                    RefreshRepairingTools();
                    return Page();
                }
                if (string.IsNullOrEmpty(Year) || string.IsNullOrEmpty(Month) || string.IsNullOrEmpty(Day))
                {
                    Error = "请完整填写维修日期（年、月、日）！";
                    RefreshRepairingTools();
                    return Page();
                }
                string dateStr = $"{Year}-{Month.PadLeft(2, '0')}-{Day.PadLeft(2, '0')}";
                if (!DateTime.TryParse(dateStr, out DateTime _))
                {
                    Error = "维修日期格式错误！";
                    RefreshRepairingTools();
                    return Page();
                }

                string insertSql = $@"insert into RepairRecords 
                    ([工具编号], [维修日期], [完成日期], [负责部门], [负责人], [申请人], [情况概述])
                    values ({toolId}, '{dateStr}', null, 2, 'CG041', '{Applicant}', '{Description}')";
                linkclass.Execute(insertSql);
                linkclass.Execute($"update Tools set [资产状态] = '维修中' where [工器具编号] = {toolId}");

                Message = "维修申请成功！";
            }

            RefreshRepairingTools();
            return Page();
        }

        private void RefreshRepairingTools()
        {
            RepairingTools = linkclass.Query("select [工器具编号],[名称],[类别],[资产状态] from Tools where [资产状态] = '维修中'");
        }
    }
}