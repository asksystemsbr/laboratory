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
    public class SolicitanteController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ISolicitanteService _service;

        public SolicitanteController(ILoggerService loggerService, ISolicitanteService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Solicitante>>> GetItems()
        {
            var items = await _service.GetItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Solicitante>> GetItem(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("existsByCPF/{cpf}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<bool>> ExistsByCPF(string cpf)
        {
            var item = await _service.GetItemByCPF(cpf);
            if (item == null)
            {
                return Ok(false); 
            }
            return Ok(true); 
        }

        [HttpGet("solicitanteByCRM/{crm}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Solicitante>> GetItemByCRM(string crm)
        {
            var item = await _service.GetItemByCRM(crm);
            if (item == null)
            {
                return NoContent();
            }
            return item;
        }


        //[HttpGet("getSolicitanteByRecepcao/{recepcaoId}")]
        //[Authorize(Policy = "CanRead")]
        //public async Task<ActionResult<IEnumerable<Solicitante>>> GetSolicitanteByRecepcao(int recepcaoId)
        //{
        //    var items = await _service.GetSolicitanteByRecepcao(recepcaoId);

        //    return Ok(items);
        //}

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutItem(int id, Solicitante item)
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
                await _loggerService.LogError<Solicitante>(HttpContext.Request.Method, item, User, ex);
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
                await _loggerService.LogError<Solicitante>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Solicitante>> PostItem(Solicitante item)
        {
            try
            {
                var created = await _service.Post(item);
                return CreatedAtAction("GetPlano", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Solicitante>(HttpContext.Request.Method, item, User, ex);
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
                await _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Solicitante>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ItemExists(int id)
        {
            return _service.Exists(id);
        }
    }
}