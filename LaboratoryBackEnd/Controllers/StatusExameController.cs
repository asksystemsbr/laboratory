using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusExameController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IStatusExameService _service;

        public StatusExameController(ILoggerService loggerService, IStatusExameService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusExame>>> GetStatusExames()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusExame>> GetStatusExame(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusExame(int id, StatusExame statusExame)
        {
            if (id != statusExame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(statusExame);
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
        public async Task<ActionResult<StatusExame>> PostStatusExame(StatusExame statusExame)
        {
            var createdStatusExame = await _service.Post(statusExame);
            return CreatedAtAction(nameof(GetStatusExame), new { id = createdStatusExame.ID }, createdStatusExame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusExame(int id)
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