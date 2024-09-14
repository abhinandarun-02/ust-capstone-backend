namespace EventPlannerAPI.DTOs
{
    public class PhotographyDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public required string Location { get; set; }
        public required string About { get; set; }
        public decimal Rating { get; set; }
        public required string Tier { get; set; }
        public required string Contact { get; set; }
        public required string PackageDetails { get; set; }
    }
}
