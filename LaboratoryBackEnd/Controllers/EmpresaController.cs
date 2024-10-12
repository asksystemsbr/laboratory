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
    [EnableCors("AllowSpecificOrigin")] // Adicionando CORS
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IEmpresaService _service;
        private readonly IEmpresaCategoriaService _serviceEmpresaCategorias;

        public EmpresaController(ILoggerService loggerService
            , IEmpresaService service,
            IEmpresaCategoriaService serviceEmpresaCategorias)
        {
            _loggerService = loggerService;
            _service = service;
            _serviceEmpresaCategorias = serviceEmpresaCategorias;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")] // Adicionando autorização de leitura
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            var items = await _service.GetItems();
            //if (items == null || !items.Any())
            //{
            //    return NotFound();
            //}
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")] // Adicionando autorização de leitura
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getEmpresaCategoria")]
        [Authorize(Policy = "CanRead")] // Adicionando autorização de leitura
        public async Task<ActionResult<IEnumerable<EmpresaCatagoria>>> GetEmpresasCategorias()
        {
            var items = await _serviceEmpresaCategorias.GetItems();
            return Ok(items);
        }

        [HttpGet("getEmpresaCategoria/{id}")]
        [Authorize(Policy = "CanRead")] // Adicionando autorização de leitura
        public async Task<ActionResult<EmpresaCatagoria>> GetEmpresasCategorias(int id)
        {
            var item = await _serviceEmpresaCategorias.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")] // Adicionando autorização de escrita
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(empresa);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(empresa);
                await _loggerService.LogError<Empresa>(HttpContext.Request.Method, empresa, User, ex);
                if (!EmpresaExists(id))
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
                await _service.RemoveContex(empresa);

                await _loggerService.LogError<Empresa>(HttpContext.Request.Method, empresa, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")] // Adicionando autorização de escrita
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            try
            {
                var created = await _service.Post(empresa);
                return CreatedAtAction("GetEmpresa", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(empresa);
                await _loggerService.LogError<Empresa>(HttpContext.Request.Method, empresa, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")] // Adicionando autorização de escrita
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Delete(id, item.EnderecoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(item);
                await _loggerService.LogError<Empresa>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return _service.Exists(id);
        }
    }
}