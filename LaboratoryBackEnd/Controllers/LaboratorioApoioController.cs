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
    public class LaboratorioApoioController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ILaboratorioApoioService _service;

        public LaboratorioApoioController(ILoggerService loggerService, ILaboratorioApoioService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaboratorioApoio>>> GetLaboratorioApoios()
        {
            var items = await _service.GetItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LaboratorioApoio>> GetLaboratorioApoio(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaboratorioApoio(int id, LaboratorioApoio laboratorioApoio)
        {
            if (id != laboratorioApoio.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(laboratorioApoio);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoio>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                if (!LaboratorioApoioExists(id))
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
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoio>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LaboratorioApoio>> PostLaboratorioApoio(LaboratorioApoio laboratorioApoio)
        {
            try
            {
                var created = await _service.Post(laboratorioApoio);
                return CreatedAtAction("GetLaboratorioApoio", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoio>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaboratorioApoio(int id)
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
                await _loggerService.LogError<LaboratorioApoio>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool LaboratorioApoioExists(int id)
        {
            return _service.Exists(id);
        }
    }
}