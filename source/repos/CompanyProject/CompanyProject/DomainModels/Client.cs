namespace CompanyProject.DomainModels
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Company? Company { get; set; }

    }
}
