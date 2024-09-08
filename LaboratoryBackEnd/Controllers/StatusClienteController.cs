using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusClienteController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IStatusClienteService _service;

        public StatusClienteController(ILoggerService loggerService, IStatusClienteService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusCliente>>> GetStatusClientes()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusCliente>> GetStatusCliente(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusCliente(int id, StatusCliente statusCliente)
        {
            if (id != statusCliente.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(statusCliente);
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
        public async Task<ActionResult<StatusCliente>> PostStatusCliente(StatusCliente statusCliente)
        {
            var createdStatusCliente = await _service.Post(statusCliente);
            return CreatedAtAction(nameof(GetStatusCliente), new { id = createdStatusCliente.ID }, createdStatusCliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusCliente(int id)
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
