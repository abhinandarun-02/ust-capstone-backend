using System.Security.Claims;
using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories.Services
{
    public class WeddingRepository : IWeddingRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeddingRepository(EventPlannerDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // CREATE: Adds a new wedding
        public async Task<bool> CreateWeddingAsync(WeddingDTO weddingDto)
        {
            var plannerId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(plannerId))
            {
                return false;
            }

            var wedding = _mapper.Map<Wedding>(weddingDto);

            wedding.PlannerId = plannerId;

            await _context.Weddings.AddAsync(wedding);
            await _context.SaveChangesAsync();

            return true;
        }


        // READ: Fetch a wedding by Id
        public async Task<WeddingDTO?> GetWeddingByIdAsync(int id)
        {
            // Fetch the wedding from the database using the ID
            var wedding = await _context.Weddings.FindAsync(id);
            return wedding == null ? null : _mapper.Map<WeddingDTO>(wedding);
        }

        // READ: Get all weddings
        public async Task<IEnumerable<WeddingDTO>> GetAllWeddingsAsync()
        {
            var weddings = await _context.Weddings.ToListAsync();
            return _mapper.Map<IEnumerable<WeddingDTO>>(weddings);
        }

        // UPDATE: Update an existing wedding by Id
        public async Task<bool> UpdateWeddingAsync(int id, WeddingDTO weddingDto)
        {
            // Find the existing wedding by string ID
            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.Id == id);
            if (wedding == null) return false;

            _mapper.Map(weddingDto, wedding);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: Delete a wedding by Id
        public async Task<bool> DeleteWeddingAsync(int id)
        {
            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.Id == id);
            if (wedding == null) return false;

            _context.Remove(wedding);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<WeddingDTO?> GetWeddingByUsernameAsync(string username)
        {
            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.PlannerUsername == username);
            return wedding == null ? null : _mapper.Map<WeddingDTO>(wedding);
        }

        public async Task<WeddingDTO?> GetWeddingByPlannerIdAsync(string plannerId)
        {
            var wedding = await _context.Weddings.FirstOrDefaultAsync(w => w.PlannerId == plannerId);
            return wedding == null ? null : _mapper.Map<WeddingDTO>(wedding);
        }
    }
}