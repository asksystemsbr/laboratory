using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ISubCategoriaService _service;

        public SubCategoriaController(ILoggerService loggerService, ISubCategoriaService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoria>>> GetSubCategorias()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoria>> GetSubCategoria(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategoria(int id, SubCategoria subCategoria)
        {
            if (id != subCategoria.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(subCategoria);
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
        public async Task<ActionResult<SubCategoria>> PostSubCategoria(SubCategoria subCategoria)
        {
            var createdSubCategoria = await _service.Post(subCategoria);
            return CreatedAtAction(nameof(GetSubCategoria), new { id = createdSubCategoria.ID }, createdSubCategoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategoria(int id)
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