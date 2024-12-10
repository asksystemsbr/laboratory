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
using AutoMapper;
using Microsoft.IdentityModel.Logging;

namespace LaboratoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IPedidoService _service;
        private readonly IOrcamentoService _serviceOrcamento;
        private readonly IMapper _mapper;

        public PedidoController(
            ILoggerService loggerService,
            IPedidoService service,
            IOrcamentoService serviceOrcamento,
            IMapper mapper)
        {
            _loggerService = loggerService;
            _service = service;
            _serviceOrcamento = serviceOrcamento;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<PedidoCabecalho>>> GetItems()
        {
            var items = await _service.GetItemsCabecalho();

            return Ok(items);
        }

        [HttpGet("getItemsPedido")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<PedidoCabecalho>>> GetItemsPedido()
        {
            var items = await _service.GetItemsCabecalhoPedido();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<PedidoCabecalho>> GetItem(int id)
        {
            var item = await _service.GetItemCabecalho(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("getPedidoCompleto/{idCabecalho}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<PedidoCompletoDto>> GetItemCompleto(int idCabecalho)
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

                var result = new PedidoCompletoDto()
                {
                    PedidoCabecalho = item,
                    PedidoDetalhe = itemDetalhe,
                    PedidoPagamento = itemPagamento
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

        [HttpGet("checkDescontoPermission/{idUsuario}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<bool>> CheckDescontoPermission(int idUsuario)
        {

            try
            {
                var item = await _service.CheckDescontoPermission(idUsuario);
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idUsuario, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("validateCreatePedido/{idOrcamento}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<string>> ValidateCreatePedido(int idOrcamento)
        {

            try
            {
                var item = await _service.ValidateCreatePedido(idOrcamento);
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idOrcamento, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }      

        [HttpPut()]
        [Authorize(Policy = "CanWrite")]
        public async Task<IActionResult> PutItem( PedidoCompletoDto item)
        {
            List<PedidoDetalhe> detalhesProcessados = new List<PedidoDetalhe>();
            List<PedidoPagamento> pagamentosProcessados = new List<PedidoPagamento>();
            try
            {
                await _service.Put(item.PedidoCabecalho);

                await _service.DeleteDetalhe(item.PedidoCabecalho.ID);
                await _service.DeletePagamento(item.PedidoCabecalho.ID);
                foreach (var detalhe in item.PedidoDetalhe)
                {
                    detalhe.ID = 0;
                    var createdDetalhe = await _service.PostDetalhe(detalhe);
                    detalhesProcessados.Add(createdDetalhe);
                }

                foreach (var pagamento in item.PedidoPagamento)
                {
                    pagamento.ID = 0;
                    var createdPagamento = await _service.PostPagamento(pagamento);
                    pagamentosProcessados.Add(createdPagamento);
                }
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await _service.RemoveContexCabecalho(item.PedidoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<PedidoCompletoDto>(HttpContext.Request.Method, item, User, ex);
                if (!ItemExists(item.PedidoCabecalho.ID))
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
                await _service.RemoveContexCabecalho(item.PedidoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<PedidoCompletoDto>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Policy = "CanWrite")]
        public async Task<ActionResult<PedidoCabecalho>> PostItem(OrcamentoCompletoDto item)
        {
            // Converter usando AutoMapper
            var pedidoCompletoDto = _mapper.Map<PedidoCompletoDto>(item);
            pedidoCompletoDto.PedidoCabecalho.ID = 0;
            List<PedidoDetalhe> detalhesProcessados = new List<PedidoDetalhe>();
            List<PedidoPagamento> pagamentosProcessados = new List<PedidoPagamento>();

            try
            {
                pedidoCompletoDto.PedidoCabecalho.OrcamentoId = item.OrcamentoCabecalho.ID;
                pedidoCompletoDto.PedidoCabecalho.Status = "2";
                var created = await _service.PostCabecalho(pedidoCompletoDto.PedidoCabecalho);
                if (created != null){
                    
                    foreach (var detalhe in pedidoCompletoDto.PedidoDetalhe)
                    {
                        detalhe.ID = 0;
                        detalhe.PedidoId = created.ID;
                        detalhe.DataColeta = DateTime.Now;
                        var createdDetalhe = await _service.PostDetalhe(detalhe);
                        detalhesProcessados.Add(detalhe);
                    }

                    //atualizando os status
                    foreach (var detalhe in item.OrcamentoDetalhe)
                    {
                        detalhe.Status = "Em OS";
                        await _serviceOrcamento.PutDetalhe(detalhe);
                    }

                    foreach (var pagamento in pedidoCompletoDto.PedidoPagamento)
                    {
                        pagamento.ID = 0;
                        pagamento.PedidoId = created.ID;
                        var createdPagamento = await _service.PostPagamento(pagamento);
                        pagamentosProcessados.Add(pagamento);
                    }
                }
                return CreatedAtAction("GetPlano", new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                await _service.RemoveContexCabecalho(pedidoCompletoDto.PedidoCabecalho);
                foreach (var detalhe in detalhesProcessados)
                    await _service.RemoveContexDetalhe(detalhe);
                foreach (var pagamento in pagamentosProcessados)
                    await _service.RemoveContexPagamento(pagamento);
                await _loggerService.LogError<PedidoCompletoDto>(HttpContext.Request.Method, pedidoCompletoDto, User, ex);
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
                await _loggerService.LogError<PedidoCabecalho>(HttpContext.Request.Method, item, User, ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool ItemExists(int id)
        {
            return _service.ExistsCabecalho(id);
        }
    }
}