using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IFornecedorService _service;

        public FornecedorController(ILoggerService loggerService, IFornecedorService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(fornecedor);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(fornecedor);
                await _loggerService.LogError<Fornecedor>(HttpContext.Request.Method, fornecedor, User, ex);
                if (!FornecedorExists(id))
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
                await _service.RemoveContex(fornecedor);
                await _loggerService.LogError<Fornecedor>(HttpContext.Request.Method, fornecedor, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var created = await _service.Post(fornecedor);
                return CreatedAtAction("GetFornecedor", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(fornecedor);
                await _loggerService.LogError<Fornecedor>(HttpContext.Request.Method, fornecedor, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
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
                await _loggerService.LogError<Fornecedor>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
