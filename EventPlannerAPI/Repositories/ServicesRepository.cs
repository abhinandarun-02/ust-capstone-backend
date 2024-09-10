using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;

        public ServicesRepository(
            EventPlannerDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Add a new service
        public async Task<ServiceDTO?> AddServiceAsync(ServiceDTO serviceDto)
        {
            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.Id == serviceDto.weddingId);
            if (wedding == null)
            {
                return null; 
            }

            var catering = serviceDto.CateringName != null 
                ? await _context.Caterings.FirstOrDefaultAsync(c => c.Name == serviceDto.CateringName) 
                : null;
            var photography = serviceDto.PhotographyName != null 
                ? await _context.Photographies.FirstOrDefaultAsync(p => p.Name == serviceDto.PhotographyName) 
                : null;
            var venue = serviceDto.VenueName != null 
                ? await _context.Venues.FirstOrDefaultAsync(v => v.Name == serviceDto.VenueName) 
                : null;

            if ((serviceDto.CateringName != null && catering == null) ||
                (serviceDto.PhotographyName != null && photography == null) ||
                (serviceDto.VenueName != null && venue == null))
            {
                return null; 
            }

            var service = _mapper.Map<Service>(serviceDto);
            service.Wedding = wedding;
            service.Catering = catering;
            service.Photography = photography;
            service.Venue = venue;

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return serviceDto;
        }

        // Delete a service by Id
        public async Task<bool> DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get all services for a particular wedding
        public async Task<IEnumerable<ServiceDTO>> GetServicesByWeddingIdAsync(int weddingId)
        {
            var services = await _context.Services
                .Include(s => s.Wedding)
                .Include(s => s.Catering)
                .Include(s => s.Photography)
                .Include(s => s.Venue)
                .Where(s => s.WeddingId == weddingId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceDTO>>(services);
        }


        // Get a service by Id
        public async Task<ServiceDTO?> GetServiceByIdAsync(int id)
        {
            var service = await _context.Services
                .Include(s => s.Wedding)
                .Include(s => s.Catering)
                .Include(s => s.Photography)
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(s => s.Id == id);

            return service == null ? null : _mapper.Map<ServiceDTO>(service);
        }

        // Get all services (for admin use)
        public async Task<IEnumerable<ServiceDTO>> GetAllServicesAsync()
        {
            var services = await _context.Services
                .Include(s => s.Wedding)
                .Include(s => s.Catering)
                .Include(s => s.Photography)
                .Include(s => s.Venue)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceDTO>>(services);
        }
    }
}
