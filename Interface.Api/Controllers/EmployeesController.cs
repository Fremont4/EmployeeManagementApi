
//controllers enables crud perfomance
using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Controllers

{
    [ApiController]
    //define the route
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly InterfaceDbContext _interfaceDbContext;

        public EmployeesController(InterfaceDbContext interfaceDbContext)
        {
            _interfaceDbContext = interfaceDbContext;
        }
        [HttpGet]//angular application
        public async Task <IActionResult> GetAllEmployees()
        {
            //Talk to employees and fetch all the list of employees that we have inside the database
            var employees = await _interfaceDbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        //add an employee to the database.
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            //get all other properties of employees
            await _interfaceDbContext.Employees.AddAsync(employeeRequest);
            //save changes after adding new employee
            await _interfaceDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }


        //for viewing existence of employee in a database.
        [HttpGet]
        [Route("{id:Guid}")]
        

        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
          var employee = await _interfaceDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee==null)   
            {
                return NotFound();
            }
            return Ok(employee);
        }
        //for updating of employee in a database.
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]Guid id, Employee UpdateEmployeeRequest) {
            var employee = await _interfaceDbContext.Employees.FindAsync(id);

            if (employee==null)
            {
                return NotFound();
            }
            employee.firstName = UpdateEmployeeRequest.firstName;
            employee.Email = UpdateEmployeeRequest.Email;
            employee.Phone = UpdateEmployeeRequest.Phone;
            employee.Salary = UpdateEmployeeRequest.Salary;
            employee.Department = UpdateEmployeeRequest.Department;
            await _interfaceDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        //for deleting employee in a database.
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id) {
       
            var employee = await _interfaceDbContext.Employees.FindAsync(id);

            if (employee==null)
            {
                return NotFound();
            }
            _interfaceDbContext.Employees.Remove(employee);
            await _interfaceDbContext.SaveChangesAsync();
            return Ok(employee);
        }                                                         

    }

}
