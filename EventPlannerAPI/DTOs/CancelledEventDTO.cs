namespace EventPlannerAPI.DTOs
{
    public class CancelledEventDTO
    {
        public DateTime BookedDate { get; set; }
        public DateTime CancelledDate { get; set; }
        public string? ReasonForCancel { get; set; }
    }
}
