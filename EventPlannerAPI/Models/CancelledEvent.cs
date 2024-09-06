using System;

namespace EventPlannerAPI.Models;

public class CancelledEvent
{
    public required string Id { get; set; }
    public DateTime BookedDate { get; set; }
    public DateTime CancelledDate { get; set; }
    public required string ReasonForCancel { get; set; }

    // Foreign keys
    public string? BookingId { get; set; }

    // Navigation Properties
    public Booking? Booking { get; set; }
}
