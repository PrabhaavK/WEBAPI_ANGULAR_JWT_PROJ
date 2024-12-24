using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Configuration; 
using Microsoft.IdentityModel.Tokens; 
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt; 
using System.Linq; 
using System.Security.Claims; 
using System.Text;
using JWT_forAngular_server.Models;

namespace JWT_forAngular_server.Controller
{
    [ApiController] 
    [Route("api/[controller]")]
    

    public class AuthenticationController : ControllerBase
    {
        private AppDbContext _context;
        private IConfiguration config;

        public AuthenticationController(AppDbContext context, IConfiguration _config)
        {
            this._context = context;
            config = _config;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<dynamic> Login(LoginModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(s => s.email == model.Email && s.password == model.Password);
        
                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new { user.userId, user.userName, user.email, user.mobile_no, user.role, user.profileImage, Token = token });
                }
                else
                {
                    return Unauthorized(); // status code 403
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [NonAction]
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.role),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config.GetValue<string>("Jwt:issuer"),
                audience: config.GetValue<string>("Jwt:audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}