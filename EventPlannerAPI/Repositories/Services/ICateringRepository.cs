using System;
using EventPlannerAPI.DTOs;

namespace EventPlannerAPI.Repositories.Services;

public interface ICateringRepository
{
    Task<IEnumerable<CateringDTO>> GetAllCateringsAsync();
    Task<CateringDTO?> GetCateringByIdAsync(int id);
    Task<CateringDTO?> AddCateringAsync(CateringDTO cateringDto);
    Task<bool> UpdateCateringAsync(int id, CateringDTO cateringDto);
    Task<bool> DeleteCateringAsync(int id);
}
