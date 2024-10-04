using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IModuloService _service;

        public ModuloController(ILoggerService loggerService, IModuloService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulo item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(item);
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
        public async Task<ActionResult<Modulo>> PostModulo(Modulo item)
        {
            var createdModulo = await _service.Post(item);
            return CreatedAtAction(nameof(GetModulo), new { id = createdModulo.ID }, createdModulo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulo(int id)
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