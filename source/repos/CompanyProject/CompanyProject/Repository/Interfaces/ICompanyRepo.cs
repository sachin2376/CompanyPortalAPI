using CompanyProject.DataModels;
using CompanyProject.Requests.CompanyRequestModels;

namespace CompanyProject.Repository.Interfaces
{
    public interface ICompanyRepo
    {
        Task<List<Company?>> GetAllCompaniesAsync();
        Task<Company?> GetAsync(Guid companyid);
        Task<Company> CreateAsync(CompanyRequest company);
        Task<Company?> UpdateAsync(Guid id, CompanyUpdateRequest company);
        Task<Company?> DeleteAsync(Guid id);
    }
}
