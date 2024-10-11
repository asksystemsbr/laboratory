using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcaoConvenioPlanoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IRecepcaoConvenioPlanoService _service;

        public RecepcaoConvenioPlanoController(ILoggerService loggerService, IRecepcaoConvenioPlanoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanos()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecepcaoConvenioPlano>> GetRecepcaoConvenioPlano(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("byRecepcao/{recepcaoId}")]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanosByRecepcao(int recepcaoId)
        {
            var items = await _service.GetItemsByRecepcao(recepcaoId);
            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcaoConvenioPlano(int id, RecepcaoConvenioPlano recepcaoConvenioPlano)
        {
            if (id != recepcaoConvenioPlano.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(recepcaoConvenioPlano);
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
        public async Task<ActionResult<RecepcaoConvenioPlano>> PostRecepcaoConvenioPlano(RecepcaoConvenioPlano recepcaoConvenioPlano)
        {
            var createdRecepcaoConvenioPlano = await _service.Post(recepcaoConvenioPlano);
            return CreatedAtAction(nameof(GetRecepcaoConvenioPlano), new { id = createdRecepcaoConvenioPlano.ID }, createdRecepcaoConvenioPlano);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepcaoConvenioPlano(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }

        [HttpPost("addOrUpdate/{recepcaoId}")]
        public async Task<IActionResult> AddOrUpdateRecepcaoConvenioPlanos(int recepcaoId, [FromBody] List<RecepcaoConvenioPlano> conveniosPlanos)
        {
            await _service.AddOrUpdateAsync(recepcaoId, conveniosPlanos);
            return NoContent();
        }
    }
}