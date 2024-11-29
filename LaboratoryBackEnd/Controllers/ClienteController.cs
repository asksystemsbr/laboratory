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
    public class ClienteController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IClienteService _service;

        public ClienteController(ILoggerService loggerService, IClienteService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        // GET: api/Cliente
        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var items = await _service.GetItems();
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {

                await _loggerService.LogError<string>(HttpContext.Request.Method, "", User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var item = await _service.GetItem(id);
                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception ex)
            {

                await _loggerService.LogError<string>(HttpContext.Request.Method, "", User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("clienteByCPF/{cpf}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetByCPF(string cpf)
        {
            var item = await _service.GetItemByCPF(cpf);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("clienteByRG/{rg}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetByRG(string rg)
        {
            var item = await _service.GetItemByRG(rg);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("clienteByNome/{nome}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetByNome(string nome)
        {
            var item = await _service.GetItemByNome(nome);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("clienteByTelefone/{telefone}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Cliente>> GetByTelefone(string telefone)
        {
            var item = await _service.GetItemByTelefone(telefone);
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

        // PUT: api/Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
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

        // POST: api/Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDto clienteDto)
        {

            var cliente = new ClienteDtoToCliente().MapDtoToCliente(clienteDto);
            try
            {
                
                cliente.DataCadastro = DateTime.Now;
                cliente.Senha = "#saolucas";//senha padrão para usar no portal

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

        [HttpPost("createPortal")]
        [Authorize(Policy = "CanWrite")]
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

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                if (item.EnderecoId.HasValue)
                {
                    await _service.Delete(id, item.EnderecoId.Value);
                    return NoContent();
                }
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
