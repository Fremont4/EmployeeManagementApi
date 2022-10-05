using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interface.Api.Controllers
{

    [ApiController]
    //define the route
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
       // private readonly InterfaceDbContext _interfaceDbContext;

       // public LoginController(InterfaceDbContext interfaceDbContext)
       // {
        //    _interfaceDbContext = interfaceDbContext;
       // }
        //api for finding a user(logins)
        [HttpGet, Authorize]

        //public IActionResult LoginUser([FromBody] LoginModel loginObj)
        public IEnumerable<string> Get()

        {
            return new string[] { "koech@gmail.com","678"};

            //var user = _interfaceDbContext.Users.Where(x => x.Email.Equals(loginObj.Email) &&
            //x.password.Equals(loginObj.Password)).FirstOrDefault();
            //if (user == null)
            //{
            //    return Ok(new { status = 401, issuccess = false, message = "Not found" });
            //}
            //else
            //    return Ok(new { status = 200, issuccess = true, response = user.Email});

        }
    }
}
