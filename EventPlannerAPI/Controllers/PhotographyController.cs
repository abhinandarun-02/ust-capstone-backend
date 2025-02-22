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
    public class PhotographiesController : ControllerBase
    {
        private readonly IPhotographyRepository _photographyRepository;

        public PhotographiesController(IPhotographyRepository photographyRepository)
        {
            _photographyRepository = photographyRepository;
        }

        // POST: api/Photographies
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddPhotography([FromBody] PhotographyDTO photographyDTO)
        {
            if (string.IsNullOrEmpty(photographyDTO.Name))
            {
                return BadRequest(new Response{Message = "Photography name cannot be empty"});
            }

            var success = await _photographyRepository.AddPhotographyAsync(photographyDTO);
            if (!success)
            {
                return BadRequest(new Response{Message = "An error occurred. Couldn't add the photography."});
            }

            return Ok(new Response{Message = $"{photographyDTO.Name} was successfully added to the database."});
        }

        // GET: api/Photographies/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhotographyById(int id)
        {
            var photography = await _photographyRepository.GetPhotographyByIdAsync(id);
            if (photography == null)
            {
                return NotFound(new Response{Message = $"Photography with id {id} was not found"});
            }

            return Ok(photography);
        }

        // GET: api/Photographies
        [HttpGet]
        public async Task<IActionResult> GetAllPhotographies()
        {
            var photographies = await _photographyRepository.GetAllPhotographiesAsync();
            if (!photographies.Any())
            {
                return NotFound(new Response{Message = "No photographies available"});
            }

            return Ok(photographies);
        }

        // DELETE: api/Photographies/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotography(int id)
        {
            var success = await _photographyRepository.DeletePhotographyAsync(id);
            if (!success)
            {
                return NotFound(new Response{Message = $"Photography with id {id} could not be found or deleted."});
            }

            return Ok(new Response{Message = $"Photography with id {id} was successfully deleted."});
        }

        // PUT: api/Photographies/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhotography(int id, [FromBody] PhotographyDTO photographyDTO)
        {
            if (string.IsNullOrEmpty(photographyDTO.Name))
            {
                return BadRequest(new Response{Message = "Photography name cannot be empty"});
            }

            var success = await _photographyRepository.UpdatePhotographyAsync(id, photographyDTO);
            if (!success)
            {
                return NotFound(new Response{Message = $"Photography with id {id} could not be found or updated."});
            }

            return Ok(new Response{Message = $"Photography with id {id} was successfully updated."});
        }
    }
}
