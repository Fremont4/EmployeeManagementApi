using Interface.Api.App_Repositories.EmployeeRepo;
using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTestController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeTestController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            return new OkObjectResult(await _employeeRepo.CreateEmployee(employeeRequest));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployes()
        {
            return new OkObjectResult(await _employeeRepo.GetAllEmployeeS());
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public IActionResult UpdateEmployee(Guid id)
        //{
        //    return new OkObjectResult(_employeeRepo.UpdateEmployee(id));
        //}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid Id)
        {
            return new OkObjectResult(await _employeeRepo.DeleteEmployee(Id));
        }
    }

}
