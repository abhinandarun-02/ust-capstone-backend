using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories
{
    public class CateringRepository : ICateringRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;

        public CateringRepository(EventPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddCateringAsync(CateringDTO cateringDto)
        {
            var catering = _mapper.Map<Catering>(cateringDto);
            await _context.Caterings.AddAsync(catering);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCateringAsync(int id)
        {
            var catering = await _context.Caterings.FindAsync(id);
            if (catering == null)
            {
                return false;
            }
            _context.Caterings.Remove(catering);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CateringDTO>> GetAllCateringsAsync()
        {
            var caterings = await _context.Caterings.ToListAsync();
            return _mapper.Map<IEnumerable<CateringDTO>>(caterings);
        }

        public async Task<CateringDTO?> GetCateringByIdAsync(int id)
        {
            var catering = await _context.Caterings.FindAsync(id);
            return catering == null ? null : _mapper.Map<CateringDTO>(catering);
        }

        public async Task<bool> UpdateCateringAsync(int id, CateringDTO cateringDto)
        {
            var existingCatering = await _context.Caterings.FirstOrDefaultAsync(v => v.Id == id);
            if (existingCatering == null)
            {
                return false;
            }

            // Map the updated values from the DTO to the existing entity
            
            
            existingCatering.Name = cateringDto.Name;
            existingCatering.Price = cateringDto.Price;
            existingCatering.Location = cateringDto.Location;
            existingCatering.About = cateringDto.About;
            existingCatering.Rating = cateringDto.Rating;
            existingCatering.Tier = cateringDto.Tier;
            existingCatering.Contact = cateringDto.Contact;
            existingCatering.MenuDetails = cateringDto.MenuDetails;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
