using System;
using EventPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Data;

public class EventPlannerDbContext : DbContext
{
    public EventPlannerDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Wedding> Weddings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Catering> Caterings { get; set; }
    public DbSet<Photography> Photographies { get; set; }
    public DbSet<Venue> Venues { get; set; }
}


