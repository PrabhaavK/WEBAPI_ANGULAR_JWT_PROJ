using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWT_forAngular_server.Models;
using Microsoft.AspNetCore.Authorization;
 
namespace JWT_forAngular_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
 
        public CourseController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
 
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = _context.Courses.ToList();
            if (courses == null || !courses.Any())
            {
                return NotFound("No courses found.");
            }
            return Ok(courses);
        }
    }
}