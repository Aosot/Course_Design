using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using tools_ctrl_web.Data;

namespace tools_ctrl_web.Pages
{
    public class BorrowReturnModel : PageModel
    {
        [BindProperty] public string Action { get; set; }
        [BindProperty] public string EmployeeId { get; set; }
        [BindProperty] public string ToolId { get; set; }
        [BindProperty] public string Year { get; set; }
        [BindProperty] public string Month { get; set; }
        [BindProperty] public string Day { get; set; }
        [BindProperty] public string ProjectId { get; set; }
        [BindProperty] public string Description { get; set; }

        public string Message { get; set; }
        public string Error { get; set; }

        public DataTable Tools { get; set; }
        public string FilterStatus { get; set; } = "全部";

        public IActionResult OnGet(string filterStatus)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return RedirectToPage("/Login");

            if (!string.IsNullOrEmpty(filterStatus))
                FilterStatus = filterStatus;

            RefreshTools();
            return Page();
        }

        public IActionResult OnPost()
        {
            string bianhao = EmployeeId;
            string gongqiju = ToolId;
            string nian = Year;
            string yue = Month;
            string ri = Day;
            string miaoshu = Description;
            string xiangmu = ProjectId;

            if (string.IsNullOrEmpty(bianhao) || string.IsNullOrEmpty(gongqiju) ||
                string.IsNullOrEmpty(nian) || string.IsNullOrEmpty(yue) || string.IsNullOrEmpty(ri))
            {
                Error = "请完整填写员工编号、工具编号、年、月、日！";
                RefreshTools();
                return Page();
            }

            if (!int.TryParse(gongqiju, out int toolId))
            {
                Error = "工具编号必须为数字！";
                RefreshTools();
                return Page();
            }

            string dateStr = $"{nian}-{yue.PadLeft(2, '0')}-{ri.PadLeft(2, '0')}";
            if (!DateTime.TryParse(dateStr, out DateTime _))
            {
                Error = "日期格式错误！";
                RefreshTools();
                return Page();
            }

            DataTable dtStatus = linkclass.Query($"select [资产状态] from Tools where [工器具编号] = {toolId}");
            if (dtStatus.Rows.Count == 0)
            {
                Error = "工具不存在！";
                RefreshTools();
                return Page();
            }
            string status = Convert.ToString(dtStatus.Rows[0][0]);

            if (Action == "借出")
            {
                if (status != "在库")
                {
                    Error = $"该工具当前状态为“{status}”，无法借出！";
                    RefreshTools();
                    return Page();
                }
                if (string.IsNullOrEmpty(xiangmu) || !int.TryParse(xiangmu, out int projId))
                {
                    Error = "请填写有效的项目编号（数字）！";
                    RefreshTools();
                    return Page();
                }

                string insert = $"insert into BorrowReturnRecords([项目编号],[员工编号],[工器具编号],[借出日期],[预归还日期],[归还日期],[设备去向]) values ({projId}, '{bianhao}', {toolId}, '{DateTime.Now:yyyy-MM-dd}', '{dateStr}', '9999-12-31', '{miaoshu}')";
                linkclass.Execute(insert);
                linkclass.Execute($"update Tools set [资产状态] = '借出中' where [工器具编号] = {toolId}");
                Message = "借出成功！";
            }
            else if (Action == "归还")
            {
                if (status != "借出中")
                {
                    Error = $"该工具当前状态为“{status}”，无法归还！";
                    RefreshTools();
                    return Page();
                }
                DataTable dtCheck = linkclass.Query($"select [记录编号] from BorrowReturnRecords where [工器具编号] = {toolId} and [归还日期] = '9999-12-31'");
                if (dtCheck.Rows.Count == 0)
                {
                    Error = "该工具没有未归还记录，无法归还！";
                    RefreshTools();
                    return Page();
                }
                int recordId = Convert.ToInt32(dtCheck.Rows[0]["记录编号"]);

                linkclass.Execute($"update BorrowReturnRecords set [归还日期] = '{dateStr}' where [记录编号] = {recordId}");
                linkclass.Execute($"update Tools set [资产状态] = '在库' where [工器具编号] = {toolId}");
                Message = "归还成功！";
            }

            RefreshTools();
            return Page();
        }

        private void RefreshTools()
        {
            string sql;
            if (FilterStatus == "全部")
                sql = "select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools";
            else
                sql = $"select [工器具编号],[名称],[类别],[所属部门],[资产状态] from Tools where [资产状态]='{FilterStatus}'";
            Tools = linkclass.Query(sql);
        }
    }
}