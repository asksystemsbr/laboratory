using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IEquipamentoService _service;

        public EquipamentoController(ILoggerService loggerService, IEquipamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(equipamento);
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
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            var createdEquipamento = await _service.Post(equipamento);
            return CreatedAtAction(nameof(GetEquipamento), new { id = createdEquipamento.ID }, createdEquipamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
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