using EventPlannerAPI.DTOs;

namespace EventPlannerAPI.Repositories.Services;

public interface IVenueRepository
{
    Task<IEnumerable<VenueDTO>> GetAllVenuesAsync();
    Task<VenueDTO?> GetVenueByIdAsync(int id);
    Task<bool> AddVenueAsync(VenueDTO venueDto);
    Task<bool> UpdateVenueAsync(int id, VenueDTO venueDto);
    Task<bool> DeleteVenueAsync(int id);
}
