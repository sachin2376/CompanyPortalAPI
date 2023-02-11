using AutoMapper;
using CompanyProject.Repository;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.ClientRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepo clientRepo;
        private readonly IMapper mapper;

        public ClientController(IClientRepo clientRepo,IMapper mapper)
        {
            this.clientRepo = clientRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ClientRequest request)
        {
            var client = await clientRepo.CreateAsync(request);
            return CreatedAtAction(nameof(GetClientById),new {clientid = client.ClientId},mapper.Map<DomainModels.Client>(client));
        }

        [HttpGet("{clientId}")]
        [ActionName(nameof(GetClientById))]
        public async Task<IActionResult> GetClientById([FromRoute]Guid clientid)
        {
            var client = await clientRepo.GetClientByIdAsync(clientid);
            if (client == null)
            {
                return NotFound("Record Not Found");
            }
            return Ok(mapper.Map<DomainModels.Client>(client));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientList =await clientRepo.GetAllAsync();
            if(clientList.Count == 0 )
            {
                return Ok("No record found");
            }
            return Ok(mapper.Map<List<DomainModels.Client>>(clientList));
        }

        [HttpDelete("{clientid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid clientid)
        {
            var client = await clientRepo.DeleteAsync(clientid);
            if (client == null)
                return NotFound();

            return Ok(mapper.Map<DomainModels.Client>(client));
        }

        [HttpPut("{clientid}")]
        public async Task<IActionResult> Update([FromRoute]Guid clientid, [FromBody]ClientRequest request)
        {
            var client = await clientRepo.UpdateAsync(clientid, request);
            if (client == null)
                return NotFound();
            return Ok(mapper.Map<DomainModels.Client>(client));
        }
        
    }
}
