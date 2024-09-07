using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoExameController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrdemServicoExameService _service;

        public OrdemServicoExameController(ILoggerService loggerService, IOrdemServicoExameService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoExame>>> GetOrdemServicoExames()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoExame>> GetOrdemServicoExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemServicoExame(int id, OrdemServicoExame ordemServicoExame)
        {
            if (id != ordemServicoExame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(ordemServicoExame);
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
        public async Task<ActionResult<OrdemServicoExame>> PostOrdemServicoExame(OrdemServicoExame ordemServicoExame)
        {
            var createdOrdemServicoExame = await _service.Post(ordemServicoExame);
            return CreatedAtAction(nameof(GetOrdemServicoExame), new { id = createdOrdemServicoExame.ID }, createdOrdemServicoExame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdemServicoExame(int id)
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