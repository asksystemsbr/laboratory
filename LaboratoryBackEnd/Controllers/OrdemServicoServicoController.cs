using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoServicoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrdemServicoServicoService _service;

        public OrdemServicoServicoController(ILoggerService loggerService, IOrdemServicoServicoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemServicoServico>>> GetOrdemServicoServicos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoServico>> GetOrdemServicoServico(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemServicoServico(int id, OrdemServicoServico ordemServicoServico)
        {
            if (id != ordemServicoServico.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(ordemServicoServico);
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
        public async Task<ActionResult<OrdemServicoServico>> PostOrdemServicoServico(OrdemServicoServico ordemServicoServico)
        {
            var createdOrdemServicoServico = await _service.Post(ordemServicoServico);
            return CreatedAtAction(nameof(GetOrdemServicoServico), new { id = createdOrdemServicoServico.ID }, createdOrdemServicoServico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdemServicoServico(int id)
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