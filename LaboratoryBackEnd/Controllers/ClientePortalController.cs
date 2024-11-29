using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Utils;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Data.Mpas;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ClientePortalController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IClienteService _service;

        public ClientePortalController(ILoggerService loggerService, IClienteService service)
        {
            _loggerService = loggerService;
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost("createPortal")]
        public async Task<ActionResult<Cliente>> PostClientePortal(ClienteDto clienteDto)
        {

            var cliente = new ClienteDtoToCliente().MapDtoToCliente(clienteDto);
            try
            {

                cliente.DataCadastro = DateTime.Now;

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


        [HttpPut("updatePortal/{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clienteDto)
        {
            if (id != clienteDto.ID)
            {
                return BadRequest();
            }

            var cliente = new ClienteDtoToCliente().MapDtoToCliente(clienteDto);
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
        private bool ClienteExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
