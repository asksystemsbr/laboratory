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
    public class LaboratorioApoioMateriaisController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ILaboratorioApoioMateriaisService _service;

        public LaboratorioApoioMateriaisController(ILoggerService loggerService, ILaboratorioApoioMateriaisService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaboratorioApoioMateriais>>> GetLaboratorioApoios()
        {
            var items = await _service.GetItems();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LaboratorioApoioMateriais>> GetLaboratorioApoio(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getbylab/{id}")]
        public async Task<ActionResult<IEnumerable<MaterialApoio>>> GetItemByLaboratorio(int id)
        {
            var item = await _service.GetMaterialItemByLaboratorio(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaboratorioApoio(int id, LaboratorioApoioMateriais laboratorioApoio)
        {
            if (id != laboratorioApoio.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(laboratorioApoio);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoioMateriais>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                if (!LaboratorioApoioMateriaisExists(id))
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
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoioMateriais>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LaboratorioApoioMateriais>> PostLaboratorioApoio(LaboratorioApoioMateriais laboratorioApoio)
        {
            try
            {
                var created = await _service.Post(laboratorioApoio);
                return CreatedAtAction("GetLaboratorioApoioMateriais", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContex(laboratorioApoio);
                await _loggerService.LogError<LaboratorioApoioMateriais>(HttpContext.Request.Method, laboratorioApoio, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaboratorioApoio(int id)
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
                await _loggerService.LogError<LaboratorioApoioMateriais>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deletebylab/{id}")]
        public async Task<IActionResult> DeleteLaboratorioApoiobylab(int id)
        {
            try
            {
                await _service.DeleteByLaboratorio(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //await _service.RemoveContex(item);
                await _loggerService.LogError<LaboratorioApoioMateriais>(HttpContext.Request.Method, null, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool LaboratorioApoioMateriaisExists(int id)
        {
            return _service.Exists(id);
        }
    }
}