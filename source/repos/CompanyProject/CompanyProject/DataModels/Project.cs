using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.DataModels
{
    [Table("project")]
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int Duration { get; set; }
        public int TeamSize { get; set; }

        public Guid ClientId { get; set; }
        public Client? Client { get; set; }

    }
}
