using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.DataModels
{
    [Table("Employee")]
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project  { get; set; }
    }
}
