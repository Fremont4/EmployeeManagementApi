using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Interface.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly InterfaceDbContext _interfaceDbContext;

        public AuthController(InterfaceDbContext interfaceDbContext)
        {
            _interfaceDbContext = interfaceDbContext;
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] LoginModel loginObj)
        {
            var user = _interfaceDbContext.Users.Where(x => x.Email.Equals(loginObj.Email) && x.password.Equals(loginObj.Password)).FirstOrDefault();
            if (user is null)
            {

                return BadRequest("Invalid Client request");
            }
            if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]


                    {
                    new Claim("Email",user.Email!=null?user.Email:""),
                    new Claim("FullName",user.FullName!=null?user.FullName:"")
                };
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7265",
                    audience: "https://localhost:5265",
                   claims,

                   
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuntheticatedResponse { Token = tokenString });
            }
            // else
            return Unauthorized();


        }
    }
}