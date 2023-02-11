using AutoMapper;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.EmployeeRequestModels;
using CompanyProject.Requests.ProjectRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmpRepo emprepo;
        private readonly IMapper mapper;

        public EmployeeController(IEmpRepo emprepo, IMapper mapper)
        {
            this.emprepo = emprepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
        {
            var employee = await emprepo.CreateAsync(request);
            return employee == null ? NotFound() : CreatedAtAction(nameof(GetById), new { employeeid = employee.EmployeeId }, mapper.Map<DomainModels.Employee>(employee));
        }

        [HttpPut("{employeeid:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid employeeid, EmployeeRequest request)
        {
            var employee = await emprepo.UpdateAsync(employeeid, request);
            return employee == null ? NotFound() : Ok(mapper.Map<DomainModels.Employee>(employee));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeeList = await emprepo.GetAllAsync();
            if (!employeeList.Any())
            {
                return NotFound("No record found");
            }
            return Ok(mapper.Map<List<DomainModels.Employee>>(employeeList));
        }

        [HttpGet("{employeeid:guid}")]
        public async Task<IActionResult> GetById(Guid employeeid)
        {
            var employee = await emprepo.GetAsync(employeeid);
            return employee == null ? NotFound("Employee record not found!") : Ok(mapper.Map<DomainModels.Employee>(employee));
        }

        [HttpDelete("{employeeid:guid}")]
        public async Task<IActionResult> Delete(Guid employeeid)
        {
            var employee = await emprepo.DeleteAsync(employeeid);
            return employee == null ? NotFound("Record not found") : Ok(mapper.Map<DomainModels.Employee>(employee));
        }
    }
}
