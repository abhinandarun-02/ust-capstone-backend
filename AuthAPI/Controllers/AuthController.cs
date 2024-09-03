using AuthAPI.Models;
using AuthAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRegisterRepository _registerRepository;
        private readonly IRegisterAdminRepository _registerAdminRepository;
        private readonly ITokenManager _tokenManager;

        public AuthController(
            ILoginRepository loginRepository,
            IRegisterRepository registerRepository,
            IRegisterAdminRepository registerAdminRepository,
            ITokenManager tokenManager)
        {
            _loginRepository = loginRepository;
            _registerRepository = registerRepository;
            _registerAdminRepository = registerAdminRepository;
            _tokenManager = tokenManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            var response = await _loginRepository.LoginAsync(loginModel);
            if (response.StatusCode == 200)
            {
                var token = await _tokenManager.Authenticate(loginModel);
                return Ok(new { Token = token });
            }
            return BadRequest(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPlannerAsync([FromBody] Planner planner)
        {
            var response = await _registerRepository.RegisterPlannerAsync(planner);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] Admin admin)
        {
            var response = await _registerAdminRepository.RegisterAdminAsync(admin);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("helloworld")]
        [Authorize]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World! You are authenticated.");
        }
    }
}
