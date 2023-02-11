using AutoMapper;
using CompanyProject.Repository.Interfaces;
using CompanyProject.Requests.ProjectRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepo projectRepo;
        private readonly IMapper mapper;

        public ProjectController(IProjectRepo projectRepo,IMapper mapper)
        {
            this.projectRepo = projectRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProjectRequest request)
        {
            var project = await projectRepo.CreateAsync(request);
            return project==null ? NotFound() : CreatedAtAction(nameof(GetById),new { projectid = project.ProjectId },mapper.Map<DomainModels.Project>(project));
        }

        [HttpPut("{projectid:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid projectid,ProjectRequest request)
        {
            var project = await projectRepo.UpdateAsync(projectid, request);
            return project == null ? NotFound() : Ok(mapper.Map<DomainModels.Project>(project));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projectList =  await projectRepo.GetAllAsync();
            if(!projectList.Any())
            {
                return NotFound("No record found");
            }
            return Ok(mapper.Map<List<DomainModels.Project>>(projectList));
        }

        [HttpGet("{projectid:guid}")]
        public async Task<IActionResult> GetById(Guid projectid)
        {
            var project = await projectRepo.GetAsync(projectid);
            return project == null ? NotFound("project not found!") : Ok(mapper.Map<DomainModels.Project>(project));
        }

        [HttpDelete("{projectid:guid}")]
        public async Task<IActionResult> Delete(Guid projectid)
        {
            var project = await projectRepo.DeleteAsync(projectid);
            return project == null ? NotFound("Record not found") : Ok(mapper.Map<DomainModels.Project>(project));
        }

        
    }
}
