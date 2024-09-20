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
    public class MetodoExameController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IMetodoExameService _service;

        public MetodoExameController(ILoggerService loggerService, IMetodoExameService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<MetodoExame>>> GetSetores()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<MetodoExame>> GetSetor(int id)
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
        public async Task<IActionResult> PutSetor(int id, MetodoExame metodoExame)
        {
            if (id != metodoExame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(metodoExame);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(metodoExame);
                await _loggerService.LogError<MetodoExame>(HttpContext.Request.Method, metodoExame, User, ex);
                if (!MetodoExameExists(id))
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
                await _service.RemoveContex(metodoExame);
                await _loggerService.LogError<MetodoExame>(HttpContext.Request.Method, metodoExame, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<MetodoExame>> PostSetor(MetodoExame metodoExame)
        {
            try
            {
                var created = await _service.Post(metodoExame);
                return CreatedAtAction("GetSetor", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(metodoExame);
                await _loggerService.LogError<MetodoExame>(HttpContext.Request.Method, metodoExame, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> Delete(int id)
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
                await _loggerService.LogError<MetodoExame>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool MetodoExameExists(int id)
        {
            return _service.Exists(id);
        }
    }
}