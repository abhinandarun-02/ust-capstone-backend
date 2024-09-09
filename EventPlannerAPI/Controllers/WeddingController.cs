using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EventPlannerAPI.DTOs;
using EventPlannerAPI.Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingController : ControllerBase
    {
        private readonly IWeddingRepository _weddingRepository;
        private readonly IMapper _mapper;

        public WeddingController(IWeddingRepository weddingRepository, IMapper mapper)
        {
            _weddingRepository = weddingRepository;
            _mapper = mapper;
        }

        // POST: api/Wedding
        [HttpPost]
        public async Task<IActionResult> CreateWeddingAsync([FromBody] WeddingDTO weddingDto)
        {
            if (weddingDto == null)
            {
                return BadRequest("Wedding data is required.");
            }

            var success = await _weddingRepository.CreateWeddingAsync(weddingDto);
            if (success)
            return Ok($"{weddingDto} was successfully created.");
            return BadRequest("Couldn't create wedding.");
        }

        // GET: api/Wedding/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWeddingByIdAsync(int id)
        {
            var wedding = await _weddingRepository.GetWeddingByIdAsync(id);
            if (wedding == null)
            {
                return NotFound();
            }

            return Ok(wedding);
        }

        // GET: api/Wedding
        [HttpGet]
        public async Task<IActionResult> GetAllWeddingsAsync()
        {
            var weddings = await _weddingRepository.GetAllWeddingsAsync();
            return Ok(weddings);
        }

        // PUT: api/Wedding/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeddingAsync(int id, [FromBody] WeddingDTO weddingDto)
        {
            if (weddingDto == null)
            {
                return BadRequest("Wedding data is required.");
            }

            var updatedWedding = await _weddingRepository.UpdateWeddingAsync(id, weddingDto);
            if (updatedWedding == false)
            {
                return NotFound();
            }

            return Ok("Updation successful.");
        }

        // DELETE: api/Wedding/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeddingAsync(int id)
        {
            var result = await _weddingRepository.DeleteWeddingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok("Deletion Successful!");
        }
    }
}
