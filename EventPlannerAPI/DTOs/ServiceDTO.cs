namespace EventPlannerAPI.DTOs
{
    public class ServiceDTO
    {
        public required string Type { get; set; }
        public required string WeddingName { get; set; }
        public string? CateringName { get; set; }
        public string? PhotographyName { get; set; }
        public string? VenueName { get; set; }
    }
}
