using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanos()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
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
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanosByRecepcao(int recepcaoId)
        {
            var items = await _service.GetItemsByRecepcao(recepcaoId);
            return Ok(items);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
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
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<RecepcaoConvenioPlano>> PostRecepcaoConvenioPlano(RecepcaoConvenioPlano recepcaoConvenioPlano)
        {
            var createdRecepcaoConvenioPlano = await _service.Post(recepcaoConvenioPlano);
            return CreatedAtAction(nameof(GetRecepcaoConvenioPlano), new { id = createdRecepcaoConvenioPlano.ID }, createdRecepcaoConvenioPlano);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
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
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> AddOrUpdateRecepcaoConvenioPlanos(int recepcaoId, [FromBody] List<RecepcaoConvenioPlano> conveniosPlanos)
        {
            await _service.AddOrUpdateAsync(recepcaoId, conveniosPlanos);

            // Atualiza o campo 'restricao' baseado no valor dinâmico vindo do front
            int restricaoValue = conveniosPlanos.FirstOrDefault()?.Retricao ?? 0;
            //await _service.UpdateRestricao(recepcaoId, restricaoValue);

            return NoContent();
        }
    }
}