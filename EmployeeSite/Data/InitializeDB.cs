using EmployeeSite.Models;
using System.Diagnostics;

namespace EmployeeSite.Data
{
    public class InitializeDB
    {
        public static void Initialize(EmployeeSiteContext context)
        {
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
                new Employee{FirstName="Tony", LastName="Stark ", HireDate=DateTime.Parse("2020-10-01")},
                new Employee{FirstName="Bruce", LastName="Banner", HireDate=DateTime.Parse("2019-10-15")},
                new Employee{FirstName="Thor", LastName="Odinson", HireDate=DateTime.Parse("2020-5-01")},
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var activities = new EmployeeActivity[]
            {
                new EmployeeActivity{ ActivityDecription="Fixed the gutter.",Customer="Sue", DateTaskCompleted=DateTime.Parse("2022-10-1"),TaskDurationMinutes=30, EmployeeId=1 },
                new EmployeeActivity{ ActivityDecription="Mowed the lawn.",Customer="Tim", DateTaskCompleted=DateTime.Parse("2022-11-1"),TaskDurationMinutes=120, EmployeeId=2 },
                new EmployeeActivity{ ActivityDecription="Raked the yard.",Customer="Alex", DateTaskCompleted=DateTime.Parse("2022-2-3"),TaskDurationMinutes=90, EmployeeId=3 },
                new EmployeeActivity{ ActivityDecription="Painted the door.",Customer="Wonder", DateTaskCompleted=DateTime.Parse("2022-10-3"),TaskDurationMinutes=60, EmployeeId=1 },
                new EmployeeActivity{ ActivityDecription="Mopped the floor.",Customer="Peter", DateTaskCompleted=DateTime.Parse("2022-04-3"),TaskDurationMinutes=100, EmployeeId=2 },
                new EmployeeActivity{ ActivityDecription="Painted the room.",Customer="Oscar", DateTaskCompleted=DateTime.Parse("2022-06-1"),TaskDurationMinutes=70, EmployeeId=3 },
                new EmployeeActivity{ ActivityDecription="Installed a light",Customer="Bravo", DateTaskCompleted=DateTime.Parse("2022-08-5"),TaskDurationMinutes=60, EmployeeId=1 },
                new EmployeeActivity{ ActivityDecription="Sweeped the floor.",Customer="Mike", DateTaskCompleted=DateTime.Parse("2022-02-4"),TaskDurationMinutes=40, EmployeeId=2 },
                new EmployeeActivity{ ActivityDecription="Fixed the garage door.",Customer="Jim", DateTaskCompleted=DateTime.Parse("2022-4-6"),TaskDurationMinutes=150, EmployeeId=3},
            };

            context.EmployeeActivities.AddRange(activities);
            context.SaveChanges();

        }
    }
}
