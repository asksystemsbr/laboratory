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
    public class SetorController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ISetorService _service;

        public SetorController(ILoggerService loggerService, ISetorService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetSetores()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> GetSetor(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetor(int id, Setor setor)
        {
            if (id != setor.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(setor);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(setor);
                await _loggerService.LogError<Setor>(HttpContext.Request.Method, setor, User, ex);
                if (!SetorExists(id))
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
                await _service.RemoveContex(setor);
                await _loggerService.LogError<Setor>(HttpContext.Request.Method, setor, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Setor>> PostSetor(Setor setor)
        {
            try
            {
                var created = await _service.Post(setor);
                return CreatedAtAction("GetSetor", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(setor);
                await _loggerService.LogError<Setor>(HttpContext.Request.Method, setor, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetor(int id)
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
                await _loggerService.LogError<Setor>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool SetorExists(int id)
        {
            return _service.Exists(id);
        }
    }
}