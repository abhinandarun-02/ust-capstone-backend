using EventPlannerAPI.DTOs;

namespace EventPlannerAPI.Repositories.Services
{
    public interface IServicesRepository
    {
        // Add a new service
        Task<ServiceDTO?> AddServiceAsync(ServiceDTO serviceDto);

        // Delete an existing service by Id
        Task<bool> DeleteServiceAsync(int id);

        // Retrieve all services associated with a specific wedding
        Task<IEnumerable<ServiceDTO>> GetServicesByWeddingIdAsync(int weddingId);

        // Retrieve all services in the database (for admin use)
        Task<IEnumerable<ServiceDTO>> GetAllServicesAsync();
        Task<ServiceDTO?> GetServiceByIdAsync(int id);
    }
}
