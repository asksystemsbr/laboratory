using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IPagamentoService _service;

        public PagamentoController(ILoggerService loggerService, IPagamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(pagamento);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(pagamento);
                await _loggerService.LogError<Pagamento>(HttpContext.Request.Method, pagamento, User, ex);
                if (!PagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(pagamento);
                await _loggerService.LogError<Pagamento>(HttpContext.Request.Method, pagamento, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            try
            {
                var created = await _service.Post(pagamento);
                return CreatedAtAction("GetPagamento", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(pagamento);
                await _loggerService.LogError<Pagamento>(HttpContext.Request.Method, pagamento, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Pagamento>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        private bool PagamentoExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
