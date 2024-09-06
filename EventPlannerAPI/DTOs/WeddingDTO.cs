namespace EventPlannerAPI.DTOs
{
    public class WeddingDTO
    {
        public required string Name { get; set; }
        public DateTime Date { get; set; }
        public int GuestCount { get; set; }
        public required string Location { get; set; }
        public required string PlannerUsername { get; set; }
    }
}
