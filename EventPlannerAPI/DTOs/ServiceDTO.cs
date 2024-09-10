namespace EventPlannerAPI.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string WeddingName { get; set; }
        public string? CateringName { get; set; }
        public string? PhotographyName { get; set; }
        public string? VenueName { get; set; }


        // Additional details
        public CateringDTO? CateringDetails { get; set; }
        public PhotographyDTO? PhotographyDetails { get; set; }
        public VenueDTO? VenueDetails { get; set; }
    }
}
