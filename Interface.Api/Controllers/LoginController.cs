using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Controllers
{

    [ApiController]
    //define the route
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly InterfaceDbContext _interfaceDbContext;

        public LoginController(InterfaceDbContext interfaceDbContext)
        {
            _interfaceDbContext = interfaceDbContext;
        }
        //api for finding a user(logins)
        [HttpPost]
        
        public IActionResult LoginUser([FromBody] LoginModel loginObj)
        {
           
            var user = _interfaceDbContext.Users.Where(x => x.Email.Equals(loginObj.Email) &&
            x.password.Equals(loginObj.Password)).FirstOrDefault();
            if (user == null)
            {
                return Ok(new { status = 401, issuccess = false, message = "Not found" });
            }
            else
                return Ok(new { status = 200, issuccess = true, message = "User Exists" });

        }
    }
}
