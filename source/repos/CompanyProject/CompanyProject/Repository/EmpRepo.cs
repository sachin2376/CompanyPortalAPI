using CompanyProject.DataModels;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.EmployeeRequestModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{

    public class EmpRepo : IEmpRepo
    {
        private readonly CompanyDbContext dbcontext;
        private readonly IProjectRepo projectrepo;

        public EmpRepo(CompanyDbContext dbcontext,IProjectRepo projectrepo)
        {
            this.dbcontext = dbcontext;
            this.projectrepo = projectrepo;
        }

        public async Task<Employee> CreateAsync(EmployeeRequest request)
        {
            Employee employee = new()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeName = request.EmployeeName,
                ProjectId = request.ProjectId,
            };
            employee.Project = await projectrepo.GetAsync(request.ProjectId); 
            await dbcontext.Employee.AddAsync(employee);
            await dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteAsync(Guid employeeid)
        {
            var employee = await GetAsync(employeeid);
            if (employee != null)
                dbcontext.Employee.Remove(employee);
            await dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await dbcontext.Employee.Include(x => x.Project.Client.Company).ToListAsync();
        }

        public async Task<Employee?> GetAsync(Guid employeeid)
        {
            return await dbcontext.Employee.Include(x => x.Project.Client.Company).FirstOrDefaultAsync(x=>x.EmployeeId.Equals(employeeid));
        }

        public async Task<Employee?> UpdateAsync(Guid employeeid, EmployeeRequest request)
        {
            var employee = await GetAsync(employeeid);
            if(employee!=null)
            {
                employee.EmployeeName = request.EmployeeName;
                employee.ProjectId = request.ProjectId;
            }
            await dbcontext.SaveChangesAsync();
            return await GetAsync(employeeid);
        }
    }
}
    