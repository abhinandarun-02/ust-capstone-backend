using AutoMapper;
using EventPlannerAPI.Data;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerAPI.Repositories
{
    public class PhotographyRepository : IPhotographyRepository
    {
        private readonly EventPlannerDbContext _context;
        private readonly IMapper _mapper;

        public PhotographyRepository(EventPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddPhotographyAsync(PhotographyDTO photographyDto)
        {
            var photography = _mapper.Map<Photography>(photographyDto);
            await _context.Photographies.AddAsync(photography);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePhotographyAsync(int id)
        {
            var photography = await _context.Photographies.FindAsync(id);
            if (photography == null)
            {
                return false;
            }
            _context.Photographies.Remove(photography);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhotographyDTO>> GetAllPhotographiesAsync()
        {
            var photographies = await _context.Photographies.ToListAsync();
            return _mapper.Map<IEnumerable<PhotographyDTO>>(photographies);
        }

        public async Task<PhotographyDTO?> GetPhotographyByIdAsync(int id)
        {
            var photography = await _context.Photographies.FindAsync(id);
            return photography == null ? null : _mapper.Map<PhotographyDTO>(photography);
        }

        public async Task<bool> UpdatePhotographyAsync(int id, PhotographyDTO photographyDto)
        {
            var existingphotography = await _context.Photographies.FindAsync(id);
            if (existingphotography == null)
            {
                return false;
            }

            _mapper.Map(photographyDto, existingphotography);
            _context.Photographies.Update(existingphotography);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
