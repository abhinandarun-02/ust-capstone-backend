namespace EventPlannerAPI.DTOs
{
    public class ServiceDTO
    {
        public required string Type { get; set; }
        public required string WeddingName { get; set; }      // Use name instead of ID
        public string? CateringName { get; set; }     // Use name instead of ID
        public string? PhotographyName { get; set; }  // Use name instead of ID
        public string? VenueName { get; set; }        // Use name instead of ID
    }
}
