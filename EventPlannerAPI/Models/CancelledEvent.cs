namespace EventPlannerAPI.Models;
public class CancelledEvent
{
    public required string Id { get; set; }
    public DateTime BookedDate { get; set; }
    public DateTime CancelledDate { get; set; }
    public required string ReasonForCancel { get; set; }
    public required string BookingId { get; set; }

}