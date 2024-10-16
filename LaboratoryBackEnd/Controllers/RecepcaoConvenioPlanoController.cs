using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class RecepcaoConvenioPlanoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IRecepcaoConvenioPlanoService _service;

        public RecepcaoConvenioPlanoController(ILoggerService loggerService, IRecepcaoConvenioPlanoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanos()
        {
            var items = await _service.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<RecepcaoConvenioPlano>> GetRecepcaoConvenioPlano(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("byRecepcao/{recepcaoId}")]
        //[Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<RecepcaoConvenioPlano>>> GetRecepcaoConvenioPlanosByRecepcao(int recepcaoId)
        {
            var items = await _service.GetItemsByRecepcao(recepcaoId);
            return Ok(items);
        }

        [HttpPut("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutRecepcaoConvenioPlano(int id, RecepcaoConvenioPlano recepcaoConvenioPlano)
        {
            if (id != recepcaoConvenioPlano.ID)
            {
                return BadRequest();
            }

            try
            {
                await _service.Put(recepcaoConvenioPlano);
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
        //[Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<RecepcaoConvenioPlano>> PostRecepcaoConvenioPlano(RecepcaoConvenioPlano recepcaoConvenioPlano)
        {
            var createdRecepcaoConvenioPlano = await _service.Post(recepcaoConvenioPlano);
            return CreatedAtAction(nameof(GetRecepcaoConvenioPlano), new { id = createdRecepcaoConvenioPlano.ID }, createdRecepcaoConvenioPlano);
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteRecepcaoConvenioPlano(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Adiciona ou atualiza os convênios e planos para uma recepção específica
        /// </summary>
        /// <param name="recepcaoId">ID da recepção</param>
        /// <param name="conveniosPlanos">Lista de convênios e planos a serem adicionados ou atualizados</param>
        /// <returns>Nenhum conteúdo se a operação for bem-sucedida</returns>
        [HttpPost("addOrUpdate/{recepcaoId}")]
        //[Authorize(Policy = "CanWrite")]
        [SwaggerOperation(Summary = "Adiciona ou atualiza convênios e planos para uma recepção",
                          Description = "Este endpoint adiciona novos convênios e planos ou atualiza os existentes para uma recepção específica. Também atualiza o campo de restrição.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Operação realizada com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Não autorizado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor")]
        public async Task<IActionResult> AddOrUpdateRecepcaoConvenioPlanos(
            [SwaggerParameter("ID da recepção", Required = true)] int recepcaoId,
            [SwaggerParameter("Lista de convênios e planos", Required = true)][FromBody] List<RecepcaoConvenioPlano> conveniosPlanos)
        {
            try
            {
                await _service.AddOrUpdateAsync(recepcaoId, conveniosPlanos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                //_loggerService.LogError(ex, $"Erro ao adicionar/atualizar convênios e planos para recepção {recepcaoId}");
                return StatusCode(500, "Ocorreu um erro interno ao processar sua solicitação.");
            }
        }
    }
}