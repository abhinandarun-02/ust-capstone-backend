using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public class RegisterAdminRepository : IRegisterAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRegisterRepository _registerRepository;

        public RegisterAdminRepository(ApplicationDbContext context, IRegisterRepository registerRepository)
        {
            _context = context;
            _registerRepository = registerRepository;
        }

        public async Task<Response> RegisterAdminAsync(Admin admin)
        {
            // Check if the admin already exists
            if (await _context.Admins.AnyAsync(a => a.Username == admin.Username))
                return new Response { StatusCode = 400, Message = "Admin already exists" };

            // Register the admin
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            // Register the admin as a planner as well
            var planner = new Planner
            {
                Username = admin.Username,
                Email = admin.Email,
                Password = admin.Password
            };

            var plannerResponse = await _registerRepository.RegisterPlannerAsync(planner);

            if (plannerResponse.StatusCode == 201)
            {
                return new Response { StatusCode = 201, Message = "Admin Registered successfully" };
            }
            else
            {
                // Rollback admin registration if planner registration fails
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
                return new Response { StatusCode = 500, Message = "Error registering admin as planner" };
            }
        }
    }
}
