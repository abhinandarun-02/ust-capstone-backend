using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;

namespace EventPlannerAPI.Repositories.Services;

public interface IBookingRepository
{
    Task<BookingDTO> CreateBookingAsync(BookingDTO bookingDto);
    Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
    Task<BookingDTO?> GetBookingByIdAsync(int id);
    Task<bool> UpdateBookingAsync(BookingDTO bookingDto);
    Task<bool> DeleteBookingAsync(int id);
    Task<IEnumerable<BookingDTO>> GetBookingsByWeddingIdAsync(int weddingId);
    Task<IEnumerable<BookingDTO>> GetBookingsByStatusAsync(BookingStatus status);
    Task<bool> BookingExistsAsync(int weddingId);
}
