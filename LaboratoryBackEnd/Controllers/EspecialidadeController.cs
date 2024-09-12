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
    public class EspecialidadeController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IEspecialidadeService _service;

        public EspecialidadeController(ILoggerService loggerService, IEspecialidadeService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Especialidade>>> GetEspecialidades()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Especialidade>> GetEspecialidade(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutEspecialidade(int id, Especialidade especialidade)
        {
            if (id != especialidade.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(especialidade);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(especialidade);
                await _loggerService.LogError<Especialidade>(HttpContext.Request.Method, especialidade, User, ex);
                if (!EspecialidadeExists(id))
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
                await _service.RemoveContex(especialidade);
                await _loggerService.LogError<Especialidade>(HttpContext.Request.Method, especialidade, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Especialidade>> PostEspecialidade(Especialidade especialidade)
        {
            try
            {
                var created = await _service.Post(especialidade);
                return CreatedAtAction("GetEspecialidade", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(especialidade);
                await _loggerService.LogError<Especialidade>(HttpContext.Request.Method, especialidade, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteEspecialidade(int id)
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
                await _loggerService.LogError<Especialidade>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool EspecialidadeExists(int id)
        {
            return _service.Exists(id);
        }
    }
}