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
    public class ContasCategoriasController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IContasCategoriasService _service;

        public ContasCategoriasController(ILoggerService loggerService, IContasCategoriasService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<ContasCategorias>>> GetContasCategorias()
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
        public async Task<ActionResult<ContasCategorias>> GetContasCategorias(int id)
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
        public async Task<IActionResult> PutContasCategorias(int id, ContasCategorias categoriasContas)
        {
            if (id != categoriasContas.ID)
            {
                return BadRequest();
            }


            try
            {
                await _service.Put(categoriasContas);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(categoriasContas);
                await _loggerService.LogError<ContasCategorias>(HttpContext.Request.Method, categoriasContas, User, ex);
                if (!CategoriasContasExists(id))
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
                await _service.RemoveContex(categoriasContas);

                await _loggerService.LogError<ContasCategorias>(HttpContext.Request.Method, categoriasContas, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<ContasCategorias>> PostContasCategorias(ContasCategorias categoriasContas)
        {

            try
            {
                var created = await _service.Post(categoriasContas);
                return CreatedAtAction("PostContasCategorias", new { id = created.ID }, created);


            }
            catch (Exception ex)
            {
                await _service.RemoveContex(categoriasContas);

                await _loggerService.LogError<ContasCategorias>(HttpContext.Request.Method, categoriasContas, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteContasCategorias(int id)
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

                await _loggerService.LogError<ContasCategorias>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }      

        private bool CategoriasContasExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
