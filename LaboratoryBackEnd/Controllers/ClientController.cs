using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IClientService _service;

        public ClientController(ILoggerService loggerService, IClientService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        // GET: api/Cliente
        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }


            try
            {
                await _service.Put(cliente);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(cliente);
                await _loggerService.LogError<Cliente>(HttpContext.Request.Method, cliente, User, ex);
                if (!ClienteExists(id))
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
                await _service.RemoveContex(cliente);

                await _loggerService.LogError<Cliente>(HttpContext.Request.Method, cliente, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {

            try
            {
                var createdImovel = await _service.Post(cliente);
                return CreatedAtAction("GetCliente", new { id = createdImovel.ID }, createdImovel);


            }
            catch (Exception ex)
            {
                await _service.RemoveContex(cliente);

                await _loggerService.LogError<Cliente>(HttpContext.Request.Method, cliente, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteCliente(int id)
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

                await _loggerService.LogError<Cliente>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }      

        private bool ClienteExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
