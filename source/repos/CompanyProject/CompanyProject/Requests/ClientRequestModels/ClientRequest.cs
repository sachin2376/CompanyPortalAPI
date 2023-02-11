namespace CompanyProject.Requests.ClientRequestModels
{
    public class ClientRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CompanyId { get; set; }
    }
}
