namespace EmployeeSite.Models
{
    public class EmployeeActivity
    {

        public int Id { get; set; }
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }
        public string Customer { get; set; }

        public string ActivityDecription { get; set; }
        public DateTime DateTaskCompleted { get; set; }
        public int TaskDurationMinutes { get; set; }

    }
}
