using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace core_auth.Controllers
{
    public class User
    {
        public string Name { get; set; }
    }

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Authorize()
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Config.SecretKey);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "Administrator")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(descriptor);
            return Ok(handler.WriteToken(token));
        }
    }
}