using Microsoft.EntityFrameworkCore;
using EventPlannerAPI.Models;

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
                    Image = "/catering-1.webp",
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
                    Image = "/catering-2.webp",
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
                    Image = "/catering-3.webp",
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
                    Image = "/catering-4.webp",
                    Price = 2000.00m,
                    Location = "Los Angeles",
                    About = "Elegant catering for sophisticated events.",
                    Rating = 4.9m,
                    Tier = "Luxury",
                    Contact = "info@elegantevents.com",
                    MenuDetails = "French cuisine and gourmet options"
                },
                new Catering
                {
                    Id = 5,
                    Name = "Taste of India",
                    Image = "/catering-5.webp",
                    Price = 1600.00m,
                    Location = "Miami",
                    About = "Authentic Indian catering with a variety of dishes.",
                    Rating = 4.7m,
                    Tier = "Premium",
                    Contact = "info@test.com",
                    MenuDetails = "Indian curries, biryanis, and desserts"
                },
                new Catering
                {
                    Id = 6,
                    Name = "Sushi Delight",
                    Image = "/catering-6.webp",
                    Price = 1400.00m,
                    Location = "New York",
                    About = "Fresh sushi catering for sushi lovers.",
                    Rating = 4.5m,
                    Tier = "Standard",
                    Contact = "info@test.com",
                    MenuDetails = "Sushi rolls, sashimi, and nigiri"
                }
            );

            // Seed Photography Data
            modelBuilder.Entity<Photography>().HasData(
                new Photography
                {
                    Id = 1,
                    Name = "PhotoMagic Studios",
                    Image = "/photography-1.webp",
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
                    Image = "/photography-2.webp",
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
                    Image = "/photography-3.webp",
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
                    Image = "/photography-4.webp",
                    Price = 1500.00m,
                    Location = "San Francisco",
                    About = "Affordable and reliable photography services.",
                    Rating = 4.5m,
                    Tier = "Standard",
                    Contact = "info@captureall.com",
                    PackageDetails = "Basic coverage with digital photos"
                },
                new Photography
                {
                    Id = 5,
                    Name = "Dreamy Shots",
                    Image = "/photography-5.webp",
                    Price = 2000.00m,
                    Location = "Chicago",
                    About = "Creating dreamy and romantic photos for your special day.",
                    Rating = 4.6m,
                    Tier = "Premium",
                    Contact = "info@test.com",
                    PackageDetails = "Full-day coverage, digital album, prints"
                },
                new Photography
                {
                    Id = 6,
                    Name = "Candid Clicks",
                    Image = "/photography-6.webp",
                    Price = 1700.00m,
                    Location = "Los Angeles",
                    About = "Capturing candid moments with a creative eye.",
                    Rating = 4.7m,
                    Tier = "Standard",
                    Contact = "info@test.com",
                    PackageDetails = "Half-day coverage, digital photos"
                }
            );

            // Seed Venue Data
            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    Id = 1,
                    Name = "Grand Ballroom",
                    Image = "/venue-1.webp",
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
                    Image = "/venue-2.webp",
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
                    Image = "/venue-3.webp",
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
                    Image = "/venue-4.webp",
                    Price = 4000.00m,
                    Location = "Chicago",
                    About = "A chic, modern space for urban weddings.",
                    Rating = 4.6m,
                    Tier = "Standard",
                    Contact = "info@modernloft.com",
                    Capacity = 150,
                    Address = "101 Loft Lane, Chicago, IL"
                },
                new Venue
                {
                    Id = 5,
                    Name = "Rustic Barn",
                    Image = "/venue-5.webp",
                    Price = 3500.00m,
                    Location = "Los Angeles",
                    About = "A charming barn venue with a rustic ambiance.",
                    Rating = 4.5m,
                    Tier = "Standard",
                    Contact = "info@test.com",
                    Capacity = 100,
                    Address = "234 Barn Rd, Los Angeles, CA"
                },
                new Venue
                {
                    Id = 6,
                    Name = "Mountain Retreat",
                    Image = "/venue-6.webp",
                    Price = 7000.00m,
                    Location = "Denver",
                    About = "A serene mountain venue with breathtaking views.",
                    Rating = 4.8m,
                    Tier = "Luxury",
                    Contact = "info@test.com",
                    Capacity = 200,
                    Address = "345 Mountain Rd, Denver, CO"
                }
            );

        }
    }
}
