namespace EventPlannerAPI.Models
{
    public class Wedding
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Date { get; set; }
        public int GuestCount { get; set; }
        public required string Location { get; set; }
        public required string PlannerUsername { get; set; }
    }
}
