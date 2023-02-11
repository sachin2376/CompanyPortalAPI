namespace CompanyProject.Requests.ProjectRequestModels
{
    public class ProjectRequest
    {
        public string? ProjectName { get; set; }
        public int Duration { get; set; }
        public int TeamSize { get; set; }
        public Guid ClientId { get; set; }
    }
}
