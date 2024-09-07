using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRecepcaoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IUsuarioRecepcaoService _service;

        public UsuarioRecepcaoController(ILoggerService loggerService, IUsuarioRecepcaoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRecepcao>>> GetUsuarioRecepcoes()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRecepcao>> GetUsuarioRecepcao(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRecepcao(int id, UsuarioRecepcao usuarioRecepcao)
        {
            if (id != usuarioRecepcao.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(usuarioRecepcao);
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
        public async Task<ActionResult<UsuarioRecepcao>> PostUsuarioRecepcao(UsuarioRecepcao usuarioRecepcao)
        {
            var createdUsuarioRecepcao = await _service.Post(usuarioRecepcao);
            return CreatedAtAction(nameof(GetUsuarioRecepcao), new { id = createdUsuarioRecepcao.ID }, createdUsuarioRecepcao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRecepcao(int id)
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