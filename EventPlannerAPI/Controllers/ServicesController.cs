using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        // CREATE: Adds a new service
        [HttpPost]
        public async Task<IActionResult> AddServiceAsync([FromBody] ServiceDTO serviceDto)
        {
            var result = await _servicesRepository.AddServiceAsync(serviceDto);

            if (result == null)
            {
                return NotFound(new Response { Message = "Wedding or one of the services not found." });
            }

            return Ok(new Response { Message = $"Services have been registered." });
        }

        // READ: Fetch all services for a particular wedding
        [HttpGet("wedding/{weddingId}")]
        public async Task<IActionResult> GetServicesByWeddingIdAsync(int weddingId)
        {
            var services = await _servicesRepository.GetServicesByWeddingIdAsync(weddingId);

            if (services == null || !services.Any())
            {
                return NotFound(new Response { Message = "No services found for the given wedding." });
            }

            return Ok(services);
        }

        // READ: Fetch a service by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceByIdAsync(int id)
        {
            var service = await _servicesRepository.GetServiceByIdAsync(id);

            if (service == null)
            {
                return NotFound(new Response { Message = "Service not found." });
            }

            return Ok(service);
        }

        // DELETE: Delete a service by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceAsync(int id)
        {
            var result = await _servicesRepository.DeleteServiceAsync(id);

            if (!result)
            {
                return NotFound(new Response { Message = "Service not found." });
            }

            return NoContent();
        }

        // READ: Fetch all services (admin use)
        [HttpGet]
        public async Task<IActionResult> GetAllServicesAsync()
        {
            var services = await _servicesRepository.GetAllServicesAsync();

            if (services == null || !services.Any())
            {
                return NotFound(new Response { Message = "No services available." });
            }

            return Ok(services);
        }
    }
}
