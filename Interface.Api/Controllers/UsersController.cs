using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Controllers
    
{
    [ApiController]
    //define the route
    [Route("api/[controller]")]   
    public class UsersController : Controller


    {
        private readonly InterfaceDbContext _interfaceDbContext;

        public UsersController(InterfaceDbContext interfaceDbContext)
        {
            _interfaceDbContext = interfaceDbContext;
        }
        //add users to the database.
        [HttpPost]//angular application(connects.)
        public async Task<IActionResult> addUsers(Users usersRequest)
        {
            usersRequest.Id = Guid.NewGuid();
             await _interfaceDbContext.Users.AddAsync(usersRequest);
            await _interfaceDbContext.SaveChangesAsync();
            return Ok(usersRequest);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _interfaceDbContext.Users.ToListAsync();
            return Ok(users);
        }
        
    }
}
