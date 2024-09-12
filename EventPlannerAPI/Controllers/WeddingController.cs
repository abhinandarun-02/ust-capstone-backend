using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
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
            var response = new Response();
            if (success){
                response.Message = $"{weddingDto.Id} was successfully created.";
                return Ok(response);
            }
            response.Message = "Couldn't create wedding.";
            return BadRequest(response);
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
            var response = new Response();
            if (weddingDto == null)
            {
                response.Message = "Wedding data is required.";
                return BadRequest(response);
            }

            var updatedWedding = await _weddingRepository.UpdateWeddingAsync(id, weddingDto);
            if (updatedWedding == false)
            {
                return NotFound();
            }
            response.Message = "Updation successful.";
            return Ok(response);
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
            return Ok(new Response{Message = "Updation successful."});
        }
    }
}
