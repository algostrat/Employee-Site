using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeSite.Models;
using System.Globalization;
using System.Data;

namespace EmployeeSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeSite.Data.EmployeeSiteContext _context;
        public IndexModel(ILogger<IndexModel> logger, EmployeeSite.Data.EmployeeSiteContext context)
        {
            _context = context;
            _logger = logger;
        }

        string[] months = DateTimeFormatInfo.CurrentInfo.MonthNames;
        public IList<EmployeeActivity> EmployeeActivity { get; set; } = default!;
        public IList<Employee> Employees { get; set; } = default!;

        public DataTable Report = new DataTable();

        public async Task OnGetAsync()
        {

            if (_context.Employees != null)
            {
                Employees = await _context.Employees.ToListAsync();
            }


            if (_context.EmployeeActivities != null)
            {
                EmployeeActivity = await _context.EmployeeActivities
                .Include(e => e.Employee).ToListAsync();

                Report.Columns.Add("Employee", typeof(String));

                for (int i = 0; i < 12; i++)
                {
                    Report.Columns.Add(months[i]);
                }

                foreach (Employee emp in Employees)
                {
                    var row = Report.NewRow();
                    row["Employee"] = emp.FirstName +" "+ emp.LastName;


                    for (int i = 0; i < 12; i++)
                    {
                        int sum = EmployeeActivity.Where(x => x.EmployeeId == emp.Id).Where(x => x.DateTaskCompleted.Month == (i+1)).Sum(x => x.TaskDurationMinutes);
                        row[months[i]] = sum;
                    }
                    Report.Rows.Add(row);
                }
            }


        }
    }
}