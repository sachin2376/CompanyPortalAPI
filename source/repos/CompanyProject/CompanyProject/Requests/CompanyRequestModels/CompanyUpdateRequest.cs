using CompanyProject.DataModels;

namespace CompanyProject.Requests.CompanyRequestModels
{
    public class CompanyUpdateRequest
    {
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
    }
}
