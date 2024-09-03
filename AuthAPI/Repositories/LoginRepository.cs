using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenManager _tokenManager;
        public LoginRepository(ApplicationDbContext context, ITokenManager tokenManager)
        {
            _context = context;
            _tokenManager = tokenManager;
        }

        public async Task<Response> LoginAsync(LoginModel loginModel)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == loginModel.Username && a.Password == loginModel.Password);
            var planner = await _context.Planners
                .FirstOrDefaultAsync(p => p.Username == loginModel.Username && p.Password == loginModel.Password);

            if (admin != null)
            {
                var token = await _tokenManager.Authenticate(new LoginModel { Username = admin.Username, Password = admin.Password });
                return new Response { StatusCode = 200, Message = token };
            }
            else if (planner != null)
            {
                var token = await _tokenManager.Authenticate(new LoginModel { Username = planner.Username, Password = planner.Password});
                return new Response { StatusCode = 200, Message = token };
            }

            return new Response { StatusCode = 401, Message = "Invalid credentials" };
        }
    }
}
