using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        // POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking(BookingDTO bookingDto)
        {
            var createdBooking = await _bookingRepository.CreateBookingAsync(bookingDto);
            return Ok($"{bookingDto.WeddingName} was booked on {bookingDto.BookedDate}.");
        }

        // PUT: api/bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, BookingDTO bookingDto)
        {
            var exists = await _bookingRepository.GetBookingByIdAsync(id);
            if (exists == null) return NotFound();

            var success = await _bookingRepository.UpdateBookingAsync(bookingDto);
            if (!success) return BadRequest();

            return NoContent();
        }

        // DELETE: api/bookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var success = await _bookingRepository.DeleteBookingAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }

        // GET: api/bookings/wedding/{weddingId}
        [HttpGet("wedding/{weddingId}")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookingsByWeddingId(int weddingId)
        {
            var bookings = await _bookingRepository.GetBookingsByWeddingIdAsync(weddingId);
            return Ok(bookings);
        }

        // GET: api/bookings/status/{status}
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookingsByStatus(BookingStatus status)
        {
            var bookings = await _bookingRepository.GetBookingsByStatusAsync(status);
            return Ok(bookings);
        }
    }
}
