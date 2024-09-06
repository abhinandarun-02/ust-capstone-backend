using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpGet("userinfo")]
        [Authorize]
        public IActionResult GetUserInfo()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            if (email == null)
            {
                return Unauthorized("No valid token found.");
            }

            var userInfo = new
            {
                Email = email,
                Roles = roles
            };

            return Ok(userInfo);
        }
    }
}
