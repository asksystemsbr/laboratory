using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class RecipienteAmostraController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IRecipienteAmostraService _service;

        public RecipienteAmostraController(ILoggerService loggerService, IRecipienteAmostraService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipienteAmostra>>> GetRecipienteAmostras()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipienteAmostra>> GetRecipienteAmostra(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipienteAmostra(int id, RecipienteAmostra recipienteAmostra)
        {
            if (id != recipienteAmostra.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(recipienteAmostra);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(recipienteAmostra);
                await _loggerService.LogError<RecipienteAmostra>(HttpContext.Request.Method, recipienteAmostra, User, ex);
                if (!RecipienteAmostraExists(id))
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
                await _service.RemoveContex(recipienteAmostra);
                await _loggerService.LogError<RecipienteAmostra>(HttpContext.Request.Method, recipienteAmostra, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RecipienteAmostra>> PostRecipienteAmostra(RecipienteAmostra recipienteAmostra)
        {
            try
            {
                var created = await _service.Post(recipienteAmostra);
                return CreatedAtAction("GetRecipienteAmostra", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(recipienteAmostra);
                await _loggerService.LogError<RecipienteAmostra>(HttpContext.Request.Method, recipienteAmostra, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipienteAmostra(int id)
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
                await _loggerService.LogError<RecipienteAmostra>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool RecipienteAmostraExists(int id)
        {
            return _service.Exists(id);
        }
    }
}