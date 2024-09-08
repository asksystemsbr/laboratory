using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrdemDeServicoService _service;

        public OrdemDeServicoController(ILoggerService loggerService, IOrdemDeServicoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdemDeServico>>> GetOrdemDeServicos()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemDeServico>> GetOrdemDeServico(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdemDeServico(int id, OrdemDeServico ordemDeServico)
        {
            if (id != ordemDeServico.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(ordemDeServico);
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
        public async Task<ActionResult<OrdemDeServico>> PostOrdemDeServico(OrdemDeServico ordemDeServico)
        {
            var createdOrdemDeServico = await _service.Post(ordemDeServico);
            return CreatedAtAction(nameof(GetOrdemDeServico), new { id = createdOrdemDeServico.ID }, createdOrdemDeServico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdemDeServico(int id)
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