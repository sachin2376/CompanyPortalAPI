using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.DataModels
{

    [Table("company")]
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
        public List<Client> Clients { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }
    }
}
