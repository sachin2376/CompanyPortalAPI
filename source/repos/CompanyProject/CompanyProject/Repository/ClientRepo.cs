using CompanyProject.DataModels;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.ClientRequestModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class ClientRepo : IClientRepo
    {
        private readonly CompanyDbContext dbcontext;
        private readonly ICompanyRepo companyRepo;
        public ClientRepo(CompanyDbContext dbcontext, ICompanyRepo companyRepo)
        {
            this.dbcontext = dbcontext;
            this.companyRepo = companyRepo;
        }
        public async Task<Client> CreateAsync(ClientRequest clientrequest)
        {
            Client client = new()
            {
                ClientId = Guid.NewGuid(),
                FirstName = clientrequest.FirstName,
                LastName = clientrequest.LastName,
                Email = clientrequest.Email,
                BirthDate = clientrequest.BirthDate,
                CompanyId = clientrequest.CompanyId,
            };

            var company = await companyRepo.GetAsync(clientrequest.CompanyId);
            if(company!=null)
            {
                if(company.Clients == null)
                {
                    company.Clients = new List<Client>();
                }
                company.Clients.Add(client);
            }
            await dbcontext.Client.AddAsync(client);
            await dbcontext.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> DeleteAsync(Guid clientId)
        {
            var client = await GetClientByIdAsync(clientId);
            if(client!=null)
            {
                dbcontext.Client.Remove(client);
                await dbcontext.SaveChangesAsync();
            }
            return client;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await dbcontext.Client.Include(x=>x.Company).
                ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(Guid clientid)
        {
            return await dbcontext.Client.Include(x=>x.Company).FirstOrDefaultAsync(x => x.ClientId.Equals(clientid));
        }

        public async Task<Client?> UpdateAsync(Guid clientId, ClientRequest client)
        {
            var updateClient = await GetClientByIdAsync(clientId);
            if(updateClient!=null)
            {
                updateClient.FirstName = client.FirstName;
                updateClient.LastName = client.LastName;
                updateClient.Email = client.Email;
                updateClient.BirthDate = client.BirthDate;

                if (updateClient.CompanyId != client.CompanyId)
                {
                    var company1 = await companyRepo.GetAsync(updateClient.CompanyId);
                    if(company1!=null)
                        company1.Clients.Remove(updateClient);
                    updateClient.CompanyId = client.CompanyId;
                    var company2 = await companyRepo.GetAsync(client.CompanyId);
                    if(company2!=null)
                    {
                        company2.Clients ??= new List<Client>();
                        company2.Clients.Add(updateClient);
                    }
                }
                await dbcontext.SaveChangesAsync();
            }
            return updateClient;
        }

        
    }
}
