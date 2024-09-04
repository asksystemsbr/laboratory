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
    public class BoletoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IBoletoService _service;

        public BoletoController(ILoggerService loggerService, IBoletoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetClientes()
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
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
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
        public async Task<IActionResult> PutBoleto(int id, Boleto boleto)
        {
            if (id != boleto.ID)
            {
                return BadRequest();
            }


            try
            {
                await _service.Put(boleto);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(boleto);
                await _loggerService.LogError<Boleto>(HttpContext.Request.Method, boleto, User, ex);
                if (!BoletoExists(id))
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
                await _service.RemoveContex(boleto);

                await _loggerService.LogError<Boleto>(HttpContext.Request.Method, boleto, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {

            try
            {
                var createdImovel = await _service.Post(boleto);
                return CreatedAtAction("GetBoleto", new { id = createdImovel.ID }, createdImovel);


            }
            catch (Exception ex)
            {
                await _service.RemoveContex(boleto);

                await _loggerService.LogError<Boleto>(HttpContext.Request.Method, boleto, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteBoleto(int id)
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

                await _loggerService.LogError<Boleto>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }      

        private bool BoletoExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
