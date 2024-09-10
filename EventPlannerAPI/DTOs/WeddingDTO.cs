namespace EventPlannerAPI.DTOs
{
    public class WeddingDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Date { get; set; }
        public int GuestCount { get; set; }
        public required string Location { get; set; }
        public required string PlannerUsername { get; set; }
        public ICollection<ServiceDTO> Services { get; set; } = new List<ServiceDTO>();
    }
}