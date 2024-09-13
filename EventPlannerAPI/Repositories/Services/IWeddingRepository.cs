using System;
using EventPlannerAPI.DTOs;

namespace EventPlannerAPI.Repositories.Services;

public interface IWeddingRepository
{
    Task<bool> CreateWeddingAsync(WeddingDTO weddingDto);
    Task<WeddingDTO?> GetWeddingByIdAsync(int id);
    Task<IEnumerable<WeddingDTO>> GetAllWeddingsAsync();
    Task<WeddingDTO?> GetWeddingByUsernameAsync(string username);
    Task<WeddingDTO?> GetWeddingByPlannerIdAsync(string plannerId);

    Task<bool> UpdateWeddingAsync(int id, WeddingDTO weddingDto);
    Task<bool> DeleteWeddingAsync(int id);
}
