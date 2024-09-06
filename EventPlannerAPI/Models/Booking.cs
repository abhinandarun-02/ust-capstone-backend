using System;

namespace EventPlannerAPI.Models;

public class Booking
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime BookedDate { get; set; }

    // Foreign Keys 
    public int WeddingId { get; set; }

    // Navigation properties
    public Wedding Wedding { get; set; }
}
