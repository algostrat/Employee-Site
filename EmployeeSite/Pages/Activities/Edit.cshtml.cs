using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeSite.Data;
using EmployeeSite.Models;

namespace EmployeeSite.Pages.Activities
{
    public class EditModel : PageModel
    {
        private readonly EmployeeSite.Data.EmployeeSiteContext _context;

        public EditModel(EmployeeSite.Data.EmployeeSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeActivity EmployeeActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EmployeeActivities == null)
            {
                return NotFound();
            }

            var employeeactivity =  await _context.EmployeeActivities.FirstOrDefaultAsync(m => m.Id == id);
            if (employeeactivity == null)
            {
                return NotFound();
            }
            EmployeeActivity = employeeactivity;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            _context.Attach(EmployeeActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeActivityExists(EmployeeActivity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool EmployeeActivityExists(int id)
        {
          return _context.EmployeeActivities.Any(e => e.Id == id);
        }
    }
}
