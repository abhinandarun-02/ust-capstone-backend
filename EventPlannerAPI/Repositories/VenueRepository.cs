using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace EventPlannerAPI.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;

        public VenueRepository(EventPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddVenueAsync(VenueDTO venueDto)
        {
            var venue = _mapper.Map<Venue>(venueDto);
            await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVenueAsync(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return false;
            }
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VenueDTO>> GetAllVenuesAsync()
        {
            var venues = await _context.Venues.ToListAsync();
            return _mapper.Map<IEnumerable<VenueDTO>>(venues);
        }

        public async Task<VenueDTO?> GetVenueByIdAsync(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            return venue == null ? null : _mapper.Map<VenueDTO>(venue);
        }

        public async Task<bool> UpdateVenueAsync(int id, VenueDTO venueDto)
        {
            // Find the existing venue by its Id
            var existingVenue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);
            if (existingVenue == null)
            {
                return false;
            }

            // Map the updated values from the DTO to the existing entity
            _mapper.Map(venueDto, existingVenue);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
