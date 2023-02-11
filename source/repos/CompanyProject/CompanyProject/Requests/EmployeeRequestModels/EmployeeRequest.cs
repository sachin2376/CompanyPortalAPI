namespace CompanyProject.Requests.EmployeeRequestModels
{
    public class EmployeeRequest
    {
        public string? EmployeeName { get; set; }
        public Guid ProjectId { get; set; }
    }
}
