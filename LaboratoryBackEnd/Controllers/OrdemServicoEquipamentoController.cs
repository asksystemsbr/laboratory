using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoEquipamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrdemServicoEquipamentoService _service;

        public OrdemServicoEquipamentoController(ILoggerService loggerService, IOrdemServicoEquipamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoEquipamento>>> GetOrdemServicoEquipamentos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoEquipamento>> GetOrdemServicoEquipamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemServicoEquipamento(int id, OrdemServicoEquipamento ordemServicoEquipamento)
        {
            if (id != ordemServicoEquipamento.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(ordemServicoEquipamento);
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
        public async Task<ActionResult<OrdemServicoEquipamento>> PostOrdemServicoEquipamento(OrdemServicoEquipamento ordemServicoEquipamento)
        {
            var createdOrdemServicoEquipamento = await _service.Post(ordemServicoEquipamento);
            return CreatedAtAction(nameof(GetOrdemServicoEquipamento), new { id = createdOrdemServicoEquipamento.ID }, createdOrdemServicoEquipamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdemServicoEquipamento(int id)
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