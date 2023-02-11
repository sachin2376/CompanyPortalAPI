using CompanyProject.DataModels;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.CompanyRequestModels;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly CompanyDbContext dbcontext;

        public CompanyRepo(CompanyDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Company> CreateAsync(CompanyRequest request)
        {
            Company company = new()
            {
                CompanyId = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                Location = request.Location,
                Count = request.Count,
                Clients = new List<Client>(),
                Projects = new List<Project>(),
                Employees = new List<Employee>()
            };
            await dbcontext.AddAsync(company);
            await dbcontext.SaveChangesAsync();
            return company;
        }

        public async Task<List<Company?>> GetAllCompaniesAsync()
        {
            return await dbcontext.Company.ToListAsync<Company?>();
        }

        public async Task<Company?> GetAsync(Guid companyid)
        {
            return await dbcontext.Company.FirstOrDefaultAsync(x => x.CompanyId.Equals(companyid));
        }

        public async Task<Company?> UpdateAsync(Guid id, CompanyUpdateRequest company)
        {
            if (IsExist(id).Result)
            {
                var existingCompany = await GetAsync(id);
                if (existingCompany != null)
                {
                    existingCompany.CompanyName = company.CompanyName;
                    existingCompany.Location = company.Location;
                    existingCompany.Count = company.Count;
                }
                await dbcontext.SaveChangesAsync();
                return existingCompany;
            }
            return null;
        }

        public async Task<Company?> DeleteAsync(Guid id)
        {
            if(IsExist(id).Result)
            {
                var company = await dbcontext.Company.FirstOrDefaultAsync(x => x.CompanyId.Equals(id));
                dbcontext.Company.Remove(company);
                await dbcontext.SaveChangesAsync();
                return company;
            }

            return default;
        }

        private async Task<bool> IsExist(Guid id)
        {
            return (await dbcontext.Company.FirstOrDefaultAsync(x => x.CompanyId.Equals(id))) != null;
        }
    }
}
