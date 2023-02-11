using CompanyProject.DataModels;
using CompanyProject.Requests.ProjectRequestModels;

namespace CompanyProject.Repository.Interfaces
{
    public interface IProjectRepo
    {
        Task<Project> CreateAsync(ProjectRequest request);
        Task<Project?> UpdateAsync(Guid projectId,ProjectRequest project);
        Task<Project> DeleteAsync(Guid projectId);
        Task<Project?> GetAsync(Guid projectId);
        Task<List<Project>> GetAllAsync();
    }
}
