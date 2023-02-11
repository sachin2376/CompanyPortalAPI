namespace CompanyProject.DomainModels
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int Duration { get; set; }
        public int TeamSize { get; set; }
        public Client? Client { get; set; }
    }
}
