using Microsoft.AspNetCore.Mvc;
using WebApiWithSqliteDB.DataModels;

namespace WebApiWithSqliteDB.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(dbContext.Employee.ToList()); 
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateEmployee([FromBody]Employee employee)
        {
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(dbContext.Employee.FirstOrDefault(x => x.EmployeeId.Equals(id)));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employee.FirstOrDefault(x => x.EmployeeId.Equals(id));
            if (employee != null)
            {
                dbContext.Employee.Remove(employee);
                dbContext.SaveChanges();
                return Ok($"Employee {id} Deleted successfully !");
            }
            return NotFound($"Employee {id} not found !");
        }
    }
}
