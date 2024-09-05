using AuthAPI.AppConstants;
using AuthAPI.DTO;
using AuthAPI.Models;
using AuthAPI.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;


        public AuthController(
           IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginModel)
        {
            var response = await _authRepository.LoginAsync(loginModel);
            if (response == null)
            {
                return BadRequest(new Response { StatusCode = StatusCodes.NotFound, Message = StatusMessages.ErrorStatus });
            }
            if (response.StatusCode == StatusCodes.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterDTO user)
        {
            var response = await _authRepository.RegisterAsync(user);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] RegisterDTO admin)
        {
            var response = await _authRepository.RegisterAdminAsync(admin);
            return StatusCode(response.StatusCode, response);
        }

    }
}
