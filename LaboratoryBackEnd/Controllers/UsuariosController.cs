using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IUsuarioService _service;

        public UsuariosController(ILoggerService loggerService, IUsuarioService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        // POST: api/Usuarios/authenticate
        [HttpPost("authenticate")]
        public async Task<ActionResult<LoginCredentials>> Authenticate([FromBody] LoginCredentials credentials)
        {
            try
            {
                var items = await _service.Authenticate(credentials);
                return Ok(items);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(InvalidOperationException))
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _service.GetItem(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // GET: api/Usuarios/5
        [HttpGet("getusuariogrupo/{grupoId}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioByrGrupo(int grupoId)
        {

            var usuario = await _service.GetUsuarioByrGrupo(grupoId);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(usuario);

            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(usuario);
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, usuario, User, ex);

                if (!UsuarioExists(id))
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
                await _service.RemoveContex(usuario);
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, usuario, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }


        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                var created = await _service.Post(usuario);

                return CreatedAtAction("GetUsuario", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {

                await _service.RemoveContex(usuario);
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, usuario, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteUsuario(int id)
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
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, item, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("limpargrupo/{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutLimparGrupoUsuario(int id)
        {
            var usuario = await _service.GetItem(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.GrupoUsuarioId = 0;
            try
            {
                await _service.Put(usuario);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(usuario);
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, usuario, User, ex);

                if (!UsuarioExists(id))
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
                await _service.RemoveContex(usuario);
                await _loggerService.LogError<Usuario>(HttpContext.Request.Method, usuario, User, ex);
                // Retorna uma resposta de erro com o código 500 e a mensagem de exceção
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _service.Exists(id);
        }


    }
}
