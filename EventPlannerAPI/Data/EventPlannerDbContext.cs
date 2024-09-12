using Microsoft.EntityFrameworkCore;
using EventPlannerAPI.Models;
using System;

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

            // Seed Catering Data
            modelBuilder.Entity<Catering>().HasData(
                new Catering
                {
                    Id = 1,
                    Name = "Gourmet Delights",
                    Price = 1500.00m,
                    Location = "New York",
                    About = "High-end catering service with gourmet options.",
                    Rating = 4.5m,
                    Tier = "Premium",
                    Contact = "info@gourmetdelights.com",
                    MenuDetails = "Italian, Mexican, and American cuisine"
                },
                new Catering
                {
                    Id = 2,
                    Name = "Green Bites",
                    Price = 1200.00m,
                    Location = "San Francisco",
                    About = "Specializes in vegetarian and vegan meals.",
                    Rating = 4.8m,
                    Tier = "Standard",
                    Contact = "contact@greenbites.com",
                    MenuDetails = "Vegan salads, wraps, and smoothies"
                },
                new Catering
                {
                    Id = 3,
                    Name = "Classic Feasts",
                    Price = 1800.00m,
                    Location = "Chicago",
                    About = "Classic catering with a wide range of dishes.",
                    Rating = 4.6m,
                    Tier = "Standard",
                    Contact = "hello@classicfeasts.com",
                    MenuDetails = "American BBQ, salads, and desserts"
                },
                new Catering
                {
                    Id = 4,
                    Name = "Elegant Events",
                    Price = 2000.00m,
                    Location = "Los Angeles",
                    About = "Elegant catering for sophisticated events.",
                    Rating = 4.9m,
                    Tier = "Luxury",
                    Contact = "info@elegantevents.com",
                    MenuDetails = "French cuisine and gourmet options"
                }
            );

            // Seed Photography Data
            modelBuilder.Entity<Photography>().HasData(
                new Photography
                {
                    Id = 1,
                    Name = "PhotoMagic Studios",
                    Price = 2500.00m,
                    Location = "Los Angeles",
                    About = "Specializing in wedding photography with a magical touch.",
                    Rating = 4.9m,
                    Tier = "Luxury",
                    Contact = "contact@photomagic.com",
                    PackageDetails = "Full-day coverage, digital album, and prints"
                },
                new Photography
                {
                    Id = 2,
                    Name = "Event Snapshots",
                    Price = 1800.00m,
                    Location = "New York",
                    About = "Capturing the essence of every event.",
                    Rating = 4.7m,
                    Tier = "Standard",
                    Contact = "info@eventsnapshots.com",
                    PackageDetails = "Half-day coverage, digital photos"
                },
                new Photography
                {
                    Id = 3,
                    Name = "Memorable Moments",
                    Price = 2200.00m,
                    Location = "Miami",
                    About = "High-quality photography with creative styles.",
                    Rating = 4.8m,
                    Tier = "Luxury",
                    Contact = "contact@memorablemoments.com",
                    PackageDetails = "Full-day coverage, digital and printed photos"
                },
                new Photography
                {
                    Id = 4,
                    Name = "Capture All",
                    Price = 1500.00m,
                    Location = "San Francisco",
                    About = "Affordable and reliable photography services.",
                    Rating = 4.5m,
                    Tier = "Standard",
                    Contact = "info@captureall.com",
                    PackageDetails = "Basic coverage with digital photos"
                }
            );

            // Seed Venue Data
            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    Id = 1,
                    Name = "Grand Ballroom",
                    Price = 8000.00m,
                    Location = "New York",
                    About = "A luxurious venue with a grand view and ample space.",
                    Rating = 4.9m,
                    Tier = "Luxury",
                    Contact = "contact@grandballroom.com",
                    Capacity = 500,
                    Address = "123 Grand Ave, New York, NY"
                },
                new Venue
                {
                    Id = 2,
                    Name = "Ocean View Resort",
                    Price = 6000.00m,
                    Location = "Miami",
                    About = "Beautiful beachside venue with stunning ocean views.",
                    Rating = 4.7m,
                    Tier = "Premium",
                    Contact = "info@oceanviewresort.com",
                    Capacity = 300,
                    Address = "456 Beach Blvd, Miami, FL"
                },
                new Venue
                {
                    Id = 3,
                    Name = "Elegant Gardens",
                    Price = 5500.00m,
                    Location = "San Francisco",
                    About = "A picturesque garden venue perfect for outdoor weddings.",
                    Rating = 4.8m,
                    Tier = "Premium",
                    Contact = "contact@elegantgardens.com",
                    Capacity = 250,
                    Address = "789 Garden St, San Francisco, CA"
                },
                new Venue
                {
                    Id = 4,
                    Name = "Modern Loft",
                    Price = 4000.00m,
                    Location = "Chicago",
                    About = "A chic, modern space for urban weddings.",
                    Rating = 4.6m,
                    Tier = "Standard",
                    Contact = "info@modernloft.com",
                    Capacity = 150,
                    Address = "101 Loft Lane, Chicago, IL"
                }
            );

        }
    }
}
