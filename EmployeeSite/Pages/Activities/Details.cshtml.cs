using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeSite.Data;
using EmployeeSite.Models;

namespace EmployeeSite.Pages.Activities
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeSite.Data.EmployeeSiteContext _context;

        public DetailsModel(EmployeeSite.Data.EmployeeSiteContext context)
        {
            _context = context;
        }

      public EmployeeActivity EmployeeActivity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EmployeeActivities == null)
            {
                return NotFound();
            }

            var employeeactivity = await _context.EmployeeActivities.FirstOrDefaultAsync(m => m.Id == id);
            if (employeeactivity == null)
            {
                return NotFound();
            }
            else 
            {
                EmployeeActivity = employeeactivity;
            }
            return Page();
        }
    }
}
