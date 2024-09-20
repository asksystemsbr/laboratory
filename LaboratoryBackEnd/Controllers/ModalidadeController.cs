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
    public class ModalidadeController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IModalidadeService _service;

        public ModalidadeController(ILoggerService loggerService, IModalidadeService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Modalidade>>> GetModalidades()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Modalidade>> GetModalidade(int id)
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
        public async Task<IActionResult> PutModalidade(int id, Modalidade modalidade)
        {
            if (id != modalidade.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(modalidade);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(modalidade);
                await _loggerService.LogError<Modalidade>(HttpContext.Request.Method, modalidade, User, ex);
                if (!ModalidadeExists(id))
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
                await _service.RemoveContex(modalidade);
                await _loggerService.LogError<Modalidade>(HttpContext.Request.Method, modalidade, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Modalidade>> PostModalidade(Modalidade modalidade)
        {
            try
            {
                var created = await _service.Post(modalidade);
                return CreatedAtAction("GetModalidade", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(modalidade);
                await _loggerService.LogError<Modalidade>(HttpContext.Request.Method, modalidade, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteModalidade(int id)
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
                await _loggerService.LogError<Modalidade>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ModalidadeExists(int id)
        {
            return _service.Exists(id);
        }
    }
}