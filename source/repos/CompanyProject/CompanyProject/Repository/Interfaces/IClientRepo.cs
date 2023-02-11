using CompanyProject.DataModels;
using CompanyProject.Requests.ClientRequestModels;

namespace CompanyProject.Repository.Interfaces
{
    public interface IClientRepo
    {
        Task<Client?> GetClientByIdAsync(Guid clientid);
        Task<List<Client>> GetAllAsync();
        Task<Client> CreateAsync(ClientRequest request);
        Task<Client?> UpdateAsync(Guid clientId,ClientRequest client);
        Task<Client?> DeleteAsync(Guid clientId);
    }
}
