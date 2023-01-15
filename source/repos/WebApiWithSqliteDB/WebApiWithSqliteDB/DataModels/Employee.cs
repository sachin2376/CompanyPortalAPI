using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithSqliteDB.DataModels
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
    }
}
