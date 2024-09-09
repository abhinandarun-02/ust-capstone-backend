using EventPlannerAPI.Models;

namespace EventPlannerAPI.DTOs
{
    public class BookingDTO
    {
        public BookingStatus Status { get; set; }
        public DateTime BookedDate { get; set; }
        public required string WeddingName { get; set; }
    }
}
