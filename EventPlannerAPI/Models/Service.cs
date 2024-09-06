using System;

namespace EventPlannerAPI.Models;

public class Service
{
    public int Id { get; set; }
    public required string Type { get; set; }

    // Foreign Keys
    public string? WeddingId { get; set; }
    public string? CateringId { get; set; }
    public string? PhotographyId { get; set; }
    public string? VenueId { get; set; }

    // Navigation Properties
    public Wedding? Wedding { get; set; }
    public Catering? Catering { get; set; }
    public Photography? Photography { get; set; }
    public Venue? Venue { get; set; }
}
