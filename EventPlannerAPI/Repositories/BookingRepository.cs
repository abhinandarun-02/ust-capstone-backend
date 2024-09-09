using System;
using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories;

public class BookingRepository : IBookingRepository
{
    public EventPlannerDbContext _context;
    public IMapper _mapper;
    public BookingRepository(EventPlannerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<bool> BookingExistsAsync(int weddingId)
    {
        return _context.Bookings.AnyAsync(b => b.WeddingId == weddingId);
    }

    public async Task<BookingDTO> CreateBookingAsync(BookingDTO bookingDto)
    {
        var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.Name == bookingDto.WeddingName);
        if (wedding == null) throw new Exception("Wedding not found");

        var booking = _mapper.Map<Booking>(bookingDto);
        booking.WeddingId = wedding.Id;

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return _mapper.Map<BookingDTO>(booking);
    }


    public async Task<bool> DeleteBookingAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null) return false;

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
    {
        var bookings = await _context.Bookings.Include(b => b.Wedding).ToListAsync();
        return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
    }

    public async Task<BookingDTO?> GetBookingByIdAsync(int id)
    {
        var booking = await _context.Bookings.Include(b => b.Wedding)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null) return null;

        return _mapper.Map<BookingDTO>(booking);
    }

    public async Task<IEnumerable<BookingDTO>> GetBookingsByStatusAsync(BookingStatus status)
    {
        var bookings = await _context.Bookings.Where(b => b.Status == status)
            .Include(b => b.Wedding)
            .ToListAsync();

        return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
    }

    public async Task<IEnumerable<BookingDTO>> GetBookingsByWeddingIdAsync(int weddingId)
    {
        var bookings = await _context.Bookings.Where(b => b.WeddingId == weddingId)
            .Include(b => b.Wedding)
            .ToListAsync();

        return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
    }
    public async Task<bool> UpdateBookingAsync(BookingDTO bookingDto)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Wedding.Name == bookingDto.WeddingName);
        if (booking == null) return false;

        _mapper.Map(bookingDto, booking); 
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
        return true;
    }
}
