using System;

namespace EventPlannerAPI.Models;

public class CancelledEvent
{
    public int Id { get; set; }
    public DateTime BookedDate { get; set; }
    public DateTime CancelledDate { get; set; }
    public string ReasonForCancel { get; set; }

    // Foreign keys
    public int BookingId { get; set; }

    // Navigation Properties
    public Booking Booking { get; set; }
}
