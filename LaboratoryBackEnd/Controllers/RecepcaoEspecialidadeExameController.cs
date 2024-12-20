using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryBackEnd.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class RecepcaoEspecialidadeExameController : ControllerBase
    {
        private readonly IRecepcaoEspecialidadeExameService _service;

        public RecepcaoEspecialidadeExameController(IRecepcaoEspecialidadeExameService service)
        {
            _service = service;
        }

        [HttpGet("byRecepcao/{recepcaoId}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RecepcaoEspecialidadeExameDto>>> GetEspecialidadesExamesByRecepcao(int recepcaoId)
        {
            var result = await _service.GetItemsByRecepcao(recepcaoId);
            return Ok(result);
        }

        [HttpPost("addOrUpdate/{recepcaoId}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> AddOrUpdateEspecialidadesExames(int recepcaoId, [FromBody] List<RecepcaoEspecialidadeExame> especialidadesExames)
        {
            try
            {
                await _service.AddOrUpdateAsync(recepcaoId, especialidadesExames);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }
    }
}