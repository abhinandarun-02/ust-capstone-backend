using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Planner> Planners { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
