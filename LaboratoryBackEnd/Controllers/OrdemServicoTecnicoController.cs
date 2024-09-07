using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoTecnicoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrdemServicoTecnicoService _service;

        public OrdemServicoTecnicoController(ILoggerService loggerService, IOrdemServicoTecnicoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoTecnico>>> GetOrdemServicoTecnicos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoTecnico>> GetOrdemServicoTecnico(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemServicoTecnico(int id, OrdemServicoTecnico ordemServicoTecnico)
        {
            if (id != ordemServicoTecnico.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(ordemServicoTecnico);
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
        public async Task<ActionResult<OrdemServicoTecnico>> PostOrdemServicoTecnico(OrdemServicoTecnico ordemServicoTecnico)
        {
            var createdOrdemServicoTecnico = await _service.Post(ordemServicoTecnico);
            return CreatedAtAction(nameof(GetOrdemServicoTecnico), new { id = createdOrdemServicoTecnico.ID }, createdOrdemServicoTecnico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdemServicoTecnico(int id)
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