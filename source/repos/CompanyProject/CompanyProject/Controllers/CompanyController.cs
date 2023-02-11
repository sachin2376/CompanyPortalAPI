using AutoMapper;
using CompanyProject.DataModels;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.CompanyRequestModels;
using Microsoft.AspNetCore.Mvc;


namespace CompanyProject.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]/")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepo companyRepo;
        private readonly IMapper mapper;

        public CompanyController(ICompanyRepo companyRepo,IMapper mapper)
        {
            this.companyRepo = companyRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyRequest request)
        {
            var company = await companyRepo.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { companyId = company.CompanyId },mapper.Map<DomainModels.Company>(company));
        }

        [HttpPut("{companyId}")]
        public async Task<IActionResult> Update([FromRoute]Guid companyId, CompanyUpdateRequest company)
        {
            var updatedCompany = await companyRepo.UpdateAsync(companyId, company);
            return Ok(mapper.Map<DomainModels.Company>(updatedCompany));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await companyRepo.GetAllCompaniesAsync();
            if(companies!=null && companies.Any())
            {
                return Ok(mapper.Map<List<DomainModels.Company>>(companies));
            }
            return NotFound();
        }

        [HttpGet("{companyId:guid}")]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get([FromRoute]Guid companyId)
        {
            var company = await companyRepo.GetAsync(companyId);
            
            if(company==null)
            {
                return NotFound("Record Not Found !");
            }

            return Ok(mapper.Map<DomainModels.Company>(company));
        }

        [HttpDelete("{companyid:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid companyId)
        {
            var company =await companyRepo.DeleteAsync(companyId);
            if (company != null)
                return Ok(mapper.Map<DomainModels.Company>(company));
            return NotFound("Record Not Found !");
        }

       
    }
}
