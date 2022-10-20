using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeSite.Data;
using EmployeeSite.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSite.Pages.Activities
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeSite.Data.EmployeeSiteContext _context;

        public CreateModel(EmployeeSite.Data.EmployeeSiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public EmployeeActivity EmployeeActivity { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (EmployeeActivity.Employee == null)
            {
                Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == EmployeeActivity.EmployeeId);
                EmployeeActivity.Employee = employee;
                ModelState.ClearValidationState(nameof(EmployeeActivity));
            }

            if (!TryValidateModel(EmployeeActivity, nameof(EmployeeActivity)))
            {
                return Page();
            }

            _context.EmployeeActivities.Add(EmployeeActivity);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
