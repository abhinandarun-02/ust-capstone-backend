using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthAPI.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> RegisterPlannerAsync(Planner planner)
        {
            // Check if planner exists
            if (await _context.Planners.AnyAsync(p => p.Username == planner.Username))
                return new Response { StatusCode = 400, Message = "Planner already exists" };

            // Register the planner
            _context.Planners.Add(planner);
            await _context.SaveChangesAsync();

            return new Response { StatusCode = 201, Message = "Planner registered successfully" };
        }
    }
}
