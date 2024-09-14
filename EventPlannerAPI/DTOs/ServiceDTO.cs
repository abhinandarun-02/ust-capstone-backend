namespace EventPlannerAPI.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required int WeddingId { get; set; }
        public int? CateringId { get; set; }
        public int? PhotographyId { get; set; }
        public int? VenueId { get; set; }


        // Additional details
        public CateringDTO? CateringDetails { get; set; }
        public PhotographyDTO? PhotographyDetails { get; set; }
        public VenueDTO? VenueDetails { get; set; }
    }
}
