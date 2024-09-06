using System;

namespace EventPlannerAPI.Models;

public class Wedding
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int GuestCount { get; set; }
    public string Location { get; set; }

    // Foreign Keys
    public int PlannerId { get; set; }
    public int BookingId { get; set; }

    // Navigation Properties
    public Planner Planner { get; set; }
    public Booking Booking { get; set; }
}
