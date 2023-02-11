using CompanyProject.DataModels;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.ProjectRequestModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly CompanyDbContext dbcontext;
        private readonly IClientRepo clientRepo;

        public ProjectRepo(CompanyDbContext dbcontext,IClientRepo clientRepo)
        {
            this.dbcontext = dbcontext;
            this.clientRepo = clientRepo;
        }


        public async Task<Project> CreateAsync(ProjectRequest request)
        {
            Project project = new()
            {
                ProjectId = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                Duration = request.Duration,
                TeamSize = request.TeamSize,
                ClientId = request.ClientId,
            };
            var client = await clientRepo.GetClientByIdAsync(project.ClientId);
            project.Client = client;
            await dbcontext.Project.AddAsync(project);
            await dbcontext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteAsync(Guid projectId)
        {
            var project = await GetAsync(projectId);
            if(project!=null)
            {
                dbcontext.Project.Remove(project);
                await dbcontext.SaveChangesAsync();
            }
            return project;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbcontext.Project.Include(x => x.Client.Company).ToListAsync();
        }

        public async Task<Project?> GetAsync(Guid projectId)
        {
            return await dbcontext.Project.Include(x => x.Client.Company).FirstOrDefaultAsync(x => x.ProjectId.Equals(projectId));
        }

        public async Task<Project?> UpdateAsync(Guid projectId, ProjectRequest project)
        {
            var existingProject = await GetAsync(projectId);
            if(existingProject!=null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.Duration= project.Duration;
                existingProject.TeamSize= project.TeamSize;
                existingProject.ClientId= project.ClientId;
                await dbcontext.SaveChangesAsync();
                return await GetAsync(existingProject.ProjectId);
            }
            return existingProject;
        }
    }
}
