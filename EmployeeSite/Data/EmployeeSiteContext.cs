using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeSite.Models;

namespace EmployeeSite.Data
{
    public class EmployeeSiteContext : DbContext
    {
        public EmployeeSiteContext (DbContextOptions<EmployeeSiteContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeActivity>().ToTable("Activity");
        }
    }
}
