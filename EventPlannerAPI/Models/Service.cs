namespace EventPlannerAPI.Models;

public class Service
{
    public int Id { get; set; }
    public required string Type { get; set; }

    // Foreign Keys
    public required int WeddingId { get; set; }
    public int? CateringId { get; set; }
    public int? PhotographyId { get; set; }
    public int? VenueId { get; set; }

    // Navigation Properties
    public required Wedding Wedding { get; set; }
    public Catering? Catering { get; set; }
    public Photography? Photography { get; set; }
    public Venue? Venue { get; set; }
}
