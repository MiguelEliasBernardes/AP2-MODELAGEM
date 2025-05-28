using Microsoft.AspNetCore.Mvc;
using VeterinariaAPI.Models;
using VeterinariaAPI.Repositories.Interfaces;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutoresController : ControllerBase
    {
        private readonly ITutorRepository _repository;

        public TutoresController(ITutorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tutores = await _repository.GetAll();
            return Ok(tutores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tutor = await _repository.GetById(id);
            if (tutor == null) return NotFound();
            return Ok(tutor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tutor tutor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var novoTutor = await _repository.Create(tutor);
            return CreatedAtAction(nameof(GetById), new { id = novoTutor.Id }, novoTutor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tutor tutor)
        {
            if (id != tutor.Id) return BadRequest();
            await _repository.Update(tutor);
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
