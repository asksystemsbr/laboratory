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
    public class ConvenioController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IConvenioService _service;

        public ConvenioController(ILoggerService loggerService, IConvenioService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Convenio>>> GetItems()
        {
            var items = await _service.GetItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Convenio>> GetItem(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getConvenioByCodigo/{codigoConvenio}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Convenio>> GetItemByCodigo(string codigoConvenio)
        {
            var item = await _service.GetItemByCodigo(codigoConvenio);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getConvenioByCodigoAndRecepcao/{codigoConvenio}/{recepacaoId}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Convenio>> GetConvenioByCodigoRecepcao(string codigoConvenio,int recepacaoId)
        {
            var item = await _service.GetConvenioByCodigoRecepcao(codigoConvenio, recepacaoId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getConvenioByRecepcao/{recepacaoId}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Convenio>>> GetConvenioByRecepcao(int recepacaoId)
        {
            var item = await _service.GetConveniosByRecepcao(recepacaoId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutItem(int id, Convenio item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(item);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Convenio>(HttpContext.Request.Method, item, User, ex);
                if (!ItemExists(id))
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
                await _service.RemoveContex(item);
                await _loggerService.LogError<Convenio>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Convenio>> PostItem(Convenio item)
        {
            try
            {
                var created = await _service.Post(item);
                return CreatedAtAction("GetConvenio", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Convenio>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Delete(id,item.EnderecoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Convenio>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ItemExists(int id)
        {
            return _service.Exists(id);
        }
    }
}