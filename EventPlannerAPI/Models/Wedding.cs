using System;

namespace EventPlannerAPI.Models;

public class Wedding
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public int GuestCount { get; set; }
    public required string Location { get; set; }
    public required string PlannerUsername { get; set; }

    // Foreign Keys
    public required string BookingId { get; set; }

    // Navigation Properties
    public required Booking Booking { get; set; }
}
