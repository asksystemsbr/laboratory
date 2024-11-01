using LaboratoryBackEnd.Service.Interface;
using LaboratoryBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Data.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IOrcamentoService _service;

        public OrcamentoController(ILoggerService loggerService, IOrcamentoService service)
        {
            _loggerService = loggerService;
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<OrcamentoCabecalho>>> GetItems()
        {
            var items = await _service.GetItemsCabecalho();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<OrcamentoCabecalho>> GetItem(int id)
        {
            var item = await _service.GetItemCabecalho(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getOrcamentoCompleto/{idCabecalho}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<OrcamentoCompletoDto>> GetItemCompleto(int idCabecalho)
        {

            try
            {                
                var item = await _service.GetItemCabecalho(idCabecalho);
                if (item == null)
                {
                    return NotFound();
                }

                var itemDetalhe = await _service.GetItemsDetalhe(item.ID);
                var itemPagamento = await _service.GetItemsPagamentos(item.ID);

                var result = new OrcamentoCompletoDto()
                {
                    OrcamentoCabecalho = item,
                    OrcamentoDetalhe = itemDetalhe,
                    OrcamentoPagamento = itemPagamento
                };

                return result;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idCabecalho, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getExamesList/{idCabecalho}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<List<Exame>>> GetExamesList(int idCabecalho)
        {

            try
            {
                var item = await _service.GetExamesList(idCabecalho);
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idCabecalho, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getPagamentosList/{idCabecalho}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<List<FormaPagamento>>> GetPagamentosList(int idCabecalho)
        {

            try
            {
                var item = await _service.GetPagamentosList(idCabecalho);
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idCabecalho, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }        

        [HttpPut()]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutItem( OrcamentoCompletoDto item)
        {
            List<OrcamentoDetalhe> detalhesProcessados = new List<OrcamentoDetalhe>();
            List<OrcamentoPagamento> pagamentosProcessados = new List<OrcamentoPagamento>();
            try
            {
                await _service.Put(item.OrcamentoCabecalho);

                await _service.DeleteDetalhe(item.OrcamentoCabecalho.ID);
                await _service.DeletePagamento(item.OrcamentoCabecalho.ID);
                foreach (var detalhe in item.OrcamentoDetalhe)
                {
                    detalhe.ID = 0;
                    var createdDetalhe = await _service.PostDetalhe(detalhe);
                    detalhesProcessados.Add(createdDetalhe);
                }

                foreach (var pagamento in item.OrcamentoPagamento)
                {
                    pagamento.ID = 0;
                    var createdPagamento = await _service.PostPagamento(pagamento);
                    pagamentosProcessados.Add(createdPagamento);
                }
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContexCabecalho(item.OrcamentoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<OrcamentoCompletoDto>(HttpContext.Request.Method, item, User, ex);
                if (!ItemExists(item.OrcamentoCabecalho.ID))
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
                await _service.RemoveContexCabecalho(item.OrcamentoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<OrcamentoCompletoDto>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<OrcamentoCabecalho>> PostItem(OrcamentoCompletoDto item)
        {
            List<OrcamentoDetalhe> detalhesProcessados = new List<OrcamentoDetalhe>();
            List<OrcamentoPagamento> pagamentosProcessados = new List<OrcamentoPagamento>();

            try
            {
                var created = await _service.PostCabecalho(item.OrcamentoCabecalho);
                if (created != null){

                    foreach (var detalhe in item.OrcamentoDetalhe)
                    {
                        detalhe.OrcamentoId = created.ID;
                        var createdDetalhe = await _service.PostDetalhe(detalhe);
                        detalhesProcessados.Add(detalhe);
                    }

                    foreach (var pagamento in item.OrcamentoPagamento)
                    {
                        pagamento.OrcamentoId = created.ID;
                        var createdPagamento = await _service.PostPagamento(pagamento);
                        pagamentosProcessados.Add(pagamento);
                    }
                }
                return CreatedAtAction("GetPlano", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContexCabecalho(item.OrcamentoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<OrcamentoCompletoDto>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _service.GetItemCabecalho(id);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                await _service.DeleteDetalhe(item.ID);
                await _service.DeletePagamento(item.ID);
                await _service.DeleteCabecalho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                await _service.RemoveContexCabecalho(item);
                await _loggerService.LogError<OrcamentoCabecalho>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ItemExists(int id)
        {
            return _service.ExistsCabecalho(id);
        }
    }
}