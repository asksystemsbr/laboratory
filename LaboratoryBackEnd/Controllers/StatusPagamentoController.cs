using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPagamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IStatusPagamentoService _service;

        public StatusPagamentoController(ILoggerService loggerService, IStatusPagamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPagamento>>> GetStatusPagamentos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusPagamento>> GetStatusPagamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusPagamento(int id, StatusPagamento statusPagamento)
        {
            if (id != statusPagamento.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(statusPagamento);
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
        public async Task<ActionResult<StatusPagamento>> PostStatusPagamento(StatusPagamento statusPagamento)
        {
            var createdStatusPagamento = await _service.Post(statusPagamento);
            return CreatedAtAction(nameof(GetStatusPagamento), new { id = createdStatusPagamento.ID }, createdStatusPagamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusPagamento(int id)
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