using CompanyProject.DataModels;
using CompanyProject.Requests.EmployeeRequestModels;

namespace CompanyProject.Repository.Interfaces
{
    public interface IEmpRepo
    {
        Task<Employee> CreateAsync(EmployeeRequest request);
        Task<Employee?> UpdateAsync(Guid employeeid, EmployeeRequest request);
        Task<Employee?> GetAsync(Guid employeeid);
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> DeleteAsync(Guid employeeid);
    }
}
