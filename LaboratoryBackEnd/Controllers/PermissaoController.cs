using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IPermissaoService _service;

        public PermissaoController(ILoggerService loggerService, IPermissaoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permissao>>> GetPermissoes()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permissao>> GetPermissao(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissao(int id, Permissao permissao)
        {
            if (id != permissao.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(permissao);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.Exists(id))
                {
                    return NotFound();
                }
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Permissao>> PostPermissao(Permissao permissao)
        {
            var createdPermissao = await _service.Post(permissao);
            return CreatedAtAction(nameof(GetPermissao), new { id = createdPermissao.ID }, createdPermissao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissao(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}