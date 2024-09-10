using AuthAPI.DTO;
using AuthAPI.Models;
using AuthAPI.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AuthAPI.AppConstants;
using System.Security.Claims;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetUserDetailsAsync()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized(new Response { StatusCode = StatusCodes.Unauthorized, Message = "Invalid token" });
            }

            var response = await _userRepository.GetUserDetailsAsync(userIdClaim.Value);

            if (response == null)
            {
                return NotFound(new Response { StatusCode = StatusCodes.NotFound, Message = "User not found" });
            }
            return Ok(response);
        }
    }
}