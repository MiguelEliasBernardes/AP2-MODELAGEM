using Microsoft.AspNetCore.Mvc;
using VeterinariaAPI.Models;
using VeterinariaAPI.Repositories.Interfaces;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _repository;

        public PetsController(IPetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _repository.GetAll();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _repository.GetById(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pet pet)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var novoPet = await _repository.Create(pet);
            return CreatedAtAction(nameof(GetById), new { id = novoPet.Id }, novoPet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pet pet)
        {
            if (id != pet.Id) return BadRequest();
            await _repository.Update(pet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
