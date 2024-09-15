using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialApoioController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IMaterialApoioService _service;

        public MaterialApoioController(ILoggerService loggerService, IMaterialApoioService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<MaterialApoio>>> GetExames()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<MaterialApoio>> GetExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutExame(int id, MaterialApoio exame)
        {
            if (id != exame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(exame);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.Exists(id))
                {
                    return NotFound();
                }
                throw;
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Exame>> PostExame(MaterialApoio exame)
        {
            var createdExame = await _service.Post(exame);
            return CreatedAtAction(nameof(GetExame), new { id = createdExame.ID }, createdExame);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}