using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosPagamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IMetodosPagamentoService _service;

        public MetodosPagamentoController(ILoggerService loggerService, IMetodosPagamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodosPagamento>>> GetMetodosPagamentos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetodosPagamento>> GetMetodosPagamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodosPagamento(int id, MetodosPagamento metodosPagamento)
        {
            if (id != metodosPagamento.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(metodosPagamento);
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
        public async Task<ActionResult<MetodosPagamento>> PostMetodosPagamento(MetodosPagamento metodosPagamento)
        {
            var createdMetodosPagamento = await _service.Post(metodosPagamento);
            return CreatedAtAction(nameof(GetMetodosPagamento), new { id = createdMetodosPagamento.ID }, createdMetodosPagamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodosPagamento(int id)
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