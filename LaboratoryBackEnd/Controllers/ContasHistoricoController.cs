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
    public class ContasHistoricoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IContasHistoricoService _service;

        public ContasHistoricoController(ILoggerService loggerService, IContasHistoricoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<ContasHistorico>>> GetContasHistorico()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<ContasHistorico>> GetContasHistorico(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpPut("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutContasHistorico(int id, ContasHistorico item)
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
                await _loggerService.LogError<ContasHistorico>(HttpContext.Request.Method, item, User, ex);
                if (!ContasHistoricoExists(id))
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

                await _loggerService.LogError<ContasHistorico>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<ContasHistorico>> PostContasHistorico(ContasHistorico item)
        {

            try
            {
                var created = await _service.Post(item);
                return CreatedAtAction("PostContasHistorico", new { id = created.ID }, created);


            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);

                await _loggerService.LogError<ContasHistorico>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteContasHistorico(int id)
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

                await _loggerService.LogError<ContasHistorico>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }      

        private bool ContasHistoricoExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
