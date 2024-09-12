using System;
using EventPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Data
{
    public class EventPlannerDbContext : DbContext
    {
        public EventPlannerDbContext(DbContextOptions<EventPlannerDbContext> options) : base(options) { }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Catering> Caterings { get; set; }
        public DbSet<Photography> Photographies { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Catering data
            modelBuilder.Entity<Catering>().HasData(
                new Catering { Id = 1, Name = "Gourmet Feast", Price = 500.00m, Location = "City Center", About = "Fine dining experience.", Rating = 4.5m, Tier = "Premium", Contact = "info@gourmetfeast.com", MenuDetails = "Includes a five-course meal." },
                new Catering { Id = 2, Name = "Quick Bites", Price = 200.00m, Location = "Downtown", About = "Casual and quick meals.", Rating = 4.0m, Tier = "Standard", Contact = "info@quickbites.com", MenuDetails = "Buffet style meals with various options." }
            );

            // Seed Photography data
            modelBuilder.Entity<Photography>().HasData(
                new Photography { Id = 1, Name = "Capture Moments", Price = 800.00m, Location = "Uptown", About = "Professional wedding photography.", Rating = 4.8m, Tier = "Premium", Contact = "contact@capturemoments.com", PackageDetails = "Full-day coverage with photo album." },
                new Photography { Id = 2, Name = "Photo Magic", Price = 600.00m, Location = "Suburbs", About = "High-quality event photography.", Rating = 4.6m, Tier = "Standard", Contact = "info@photomagic.com", PackageDetails = "Half-day coverage with digital files." }
            );

            // Seed Venue data
            modelBuilder.Entity<Venue>().HasData(
                new Venue { Id = 1, Name = "Grand Hall", Price = 1500.00m, Location = "Main Street", About = "Elegant ballroom for weddings.", Rating = 4.7m, Tier = "Luxury", Contact = "info@grandhall.com", Capacity = 500, Address = "123 Main Street" },
                new Venue { Id = 2, Name = "Riverside Pavilion", Price = 1200.00m, Location = "River Road", About = "Beautiful venue by the river.", Rating = 4.5m, Tier = "Premium", Contact = "info@riversidepavilion.com", Capacity = 300, Address = "456 River Road" }
            );
        }
    }
}
