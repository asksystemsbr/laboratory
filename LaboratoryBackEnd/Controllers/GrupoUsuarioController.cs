using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class GrupoUsuarioController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IGrupoUsuarioService _service;

        public GrupoUsuarioController(ILoggerService loggerService, IGrupoUsuarioService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<GrupoUsuario>>> GetGrupoUsuarios()
        {
            var items = await _service.GetItems();
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<GrupoUsuario>> GetGrupoUsuario(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutGrupoUsuario(int id, GrupoUsuario grupoUsuario)
        {
            if (id != grupoUsuario.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(grupoUsuario);
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
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<GrupoUsuario>> PostGrupoUsuario(GrupoUsuario grupoUsuario)
        {
            var createdGrupoUsuario = await _service.Post(grupoUsuario);
            return CreatedAtAction(nameof(GetGrupoUsuario), new { id = createdGrupoUsuario.ID }, createdGrupoUsuario);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteGrupoUsuario(int id)
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