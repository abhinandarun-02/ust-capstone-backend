using System;
using EventPlannerAPI.DTOs;
namespace EventPlannerAPI.Repositories.Services;

public interface IPhotographyRepository
{
    Task<IEnumerable<PhotographyDTO>> GetAllPhotographiesAsync();
    Task<PhotographyDTO?> GetPhotographyByIdAsync(int id);
    Task<bool> AddPhotographyAsync(PhotographyDTO photographyDto);
    Task<bool> UpdatePhotographyAsync(int id, PhotographyDTO photographyDto);
    Task<bool> DeletePhotographyAsync(int id);
}
