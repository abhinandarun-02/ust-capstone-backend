using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
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
            var idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            // Ensure email is present, which indicates a valid token
            if (emailClaim == null)
            {
                return Unauthorized("No valid token found.");
            }

            var userInfo = new
            {
                Id = idClaim?.Value,
                Name = userNameClaim?.Value,
                Email = emailClaim?.Value,
                Roles = roles
            };

            return Ok(userInfo);
        }

    }
}
