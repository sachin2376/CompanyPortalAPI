using CompanyProject.DataModels;

namespace CompanyProject.DomainModels
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Project? Project { get; set; }
    }
}
