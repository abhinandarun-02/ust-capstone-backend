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
    public class CateringsController : ControllerBase
    {
        private readonly ICateringRepository _cateringRepository;

        public CateringsController(ICateringRepository cateringRepository)
        {
            _cateringRepository = cateringRepository;
        }

        // POST: api/Caterings
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCatering([FromBody] CateringDTO cateringDTO)
        {
            if (string.IsNullOrEmpty(cateringDTO.Name))
            {
                
                return BadRequest(new Response{Message="Catering name cannot be empty"});
            }

            var success = await _cateringRepository.AddCateringAsync(cateringDTO);
            if (!success)
            {
                return BadRequest(new Response{Message = "An error occurred. Couldn't add the catering."});
            }

            return Ok(new Response{Message = $"{cateringDTO.Name} was successfully added to the database."});
        }

        // GET: api/Caterings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCateringById(int id)
        {
            var catering = await _cateringRepository.GetCateringByIdAsync(id);
            if (catering == null)
            {
                return NotFound(new Response{Message = $"Catering with id {id} was not found"});
            }

            return Ok(catering);
        }

        // GET: api/Caterings
        [HttpGet]
        public async Task<IActionResult> GetAllCaterings()
        {
            var caterings = await _cateringRepository.GetAllCateringsAsync();
            if (!caterings.Any())
            {
                return NotFound(new Response{Message = "No caterings available"});
            }

            return Ok(caterings);
        }

        // DELETE: api/Caterings/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatering(int id)
        {
            var success = await _cateringRepository.DeleteCateringAsync(id);
            if (!success)
            {
                return NotFound(new Response{Message = $"Catering with id {id} could not be found or deleted."});
            }

            return Ok(new Response{Message= $"Catering with id {id} was successfully deleted."});
        }

        // PUT: api/Caterings/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatering(int id, [FromBody] CateringDTO cateringDTO)
        { 
            if (string.IsNullOrEmpty(cateringDTO.Name))
            {
                return BadRequest(new Response{Message = "Catering name cannot be empty"});
            }

            var success = await _cateringRepository.UpdateCateringAsync(id, cateringDTO);
            if (!success)
            {
                return NotFound(new Response{Message = $"Catering with id {id} could not be found or updated."});
            }

            return Ok(new Response{Message = $"Catering with id {id} was successfully updated."});
        }
    }
}
