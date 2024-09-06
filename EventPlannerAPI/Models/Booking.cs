using System;

namespace EventPlannerAPI.Models;

public class Booking
{
    public required string Id { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime BookedDate { get; set; }

    // Foreign Keys 
    public required string WeddingId { get; set; }

    // Navigation properties
    public required Wedding Wedding { get; set; }
}


public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled
}
