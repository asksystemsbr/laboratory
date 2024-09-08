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
        public async Task<ActionResult<IEnumerable<Modulos>>> GetModulos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modulos>> GetModulo(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulos modulo)
        {
            if (id != modulo.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(modulo);
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
        public async Task<ActionResult<Modulos>> PostModulo(Modulos modulo)
        {
            var createdModulo = await _service.Post(modulo);
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