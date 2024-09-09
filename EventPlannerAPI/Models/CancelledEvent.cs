namespace EventPlannerAPI.Models;
public class CancelledEvent
{
    public required int Id { get; set; }
    public DateTime BookedDate { get; set; }
    public DateTime CancelledDate { get; set; }
    public required string ReasonForCancel { get; set; }
    public required int BookingId { get; set; }

}