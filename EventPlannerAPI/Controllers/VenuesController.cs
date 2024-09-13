using EventPlannerAPI.DTOs;
using EventPlannerAPI.Models;
using EventPlannerAPI.Repositories.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;

        public VenuesController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        // POST: api/Venues
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddVenue([FromBody] VenueDTO venueDTO)
        {
            if (string.IsNullOrEmpty(venueDTO.Name))
            {
                return BadRequest(new Response{Message = "Venue name cannot be empty"});
            }

            var success = await _venueRepository.AddVenueAsync(venueDTO);
            if (!success)
            {
                return BadRequest(new Response{Message = "An error occurred. Couldn't add the venue."});
            }

            return Ok(new Response{Message = $"{venueDTO.Name} was successfully added to the database."});
        }

        // GET: api/Venues/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenueById(int id)
        {
            var venue = await _venueRepository.GetVenueByIdAsync(id);
            if (venue == null)
            {
                return NotFound(new Response{Message = $"Venue with id {id} was not found"});
            }

            return Ok(venue);
        }

        // GET: api/Venues
        [HttpGet]
        public async Task<IActionResult> GetAllVenues()
        {
            var venues = await _venueRepository.GetAllVenuesAsync();
            if (!venues.Any())
            {
                return NotFound(new Response{Message = "No venues available"});
            }

            return Ok(venues);
        }

        // DELETE: api/Venues/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            var success = await _venueRepository.DeleteVenueAsync(id);
            if (!success)
            {
                return NotFound(new Response{Message = $"Venue with id {id} could not be found or deleted."});
            }

            return Ok(new Response{Message = $"Venue with id {id} was successfully deleted."});
        }

        // PUT: api/Venues/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenue(int id, [FromBody] VenueDTO venueDTO)
        {
            if (string.IsNullOrEmpty(venueDTO.Name))
            {
                return BadRequest(new Response{Message = "Venue name cannot be empty"});
            }

            var success = await _venueRepository.UpdateVenueAsync(id, venueDTO);
            if (!success)
            {
                return NotFound(new Response{Message = $"Venue with id {id} could not or updated."});
            }

            return Ok(new Response{Message = $"Venue with id {id} was successfully updated."});
        }
    }
}
