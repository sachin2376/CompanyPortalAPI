
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.DataModels
{
    [Table("client")]
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

    }
}
