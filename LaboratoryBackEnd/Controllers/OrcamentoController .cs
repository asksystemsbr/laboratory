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
        private readonly IAgendamentoService _serviceAgendamento;

        public OrcamentoController(ILoggerService loggerService
            , IOrcamentoService service
            , IAgendamentoService serviceAgendamento
            )
        {
            _loggerService = loggerService;
            _service = service;
            _serviceAgendamento = serviceAgendamento;
        }

        [HttpGet]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<OrcamentoCabecalho>>> GetItems()
        {
            var items = await _service.GetItemsCabecalho();

            return Ok(items);
        }

        [HttpGet("portal/{usuarioId}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<OrcamentoCabecalho>>> GetItemsByPaciente(int usuarioId)
        {
            var items = await _service.GetItemsCabecalhoByPaciente(usuarioId);

            return Ok(items);
        }

        [HttpGet("getItemsPedido")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<IEnumerable<OrcamentoCabecalho>>> GetItemsPedido()
        {
            var items = await _service.GetItemsCabecalhoPedido();

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

        [HttpGet("checkExamAgendamento/{idExame}")]
        [Authorize(Policy = "CanRead")]
        public async Task<ActionResult<bool>> CheckExamAgendamento(int idExame)
        {

            try
            {
                var item = await _service.CheckExameAgendamento(idExame);
                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                await _loggerService.LogError<int>(HttpContext.Request.Method, idExame, User, ex);
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
        public async Task<IActionResult> PutItem( OrcamentoCompletoDto item)
        {
            List<OrcamentoDetalhe> detalhesProcessados = new List<OrcamentoDetalhe>();
            List<OrcamentoPagamento> pagamentosProcessados = new List<OrcamentoPagamento>();
            bool isSchedulerOK = true;
            bool isPedido = true;

            try
            {
                await _service.Put(item.OrcamentoCabecalho);

                //disponibilizar e validar as datas
                foreach (var detalheDto in item.OrcamentoDetalhe)
                {
                    var agendamentoHorarioGerado = await _serviceAgendamento.GetHorarioGerado(detalheDto.HorarioId ?? 0);
                    if (agendamentoHorarioGerado != null)
                    {
                        //novo agendamento e tem que ter o horário disponível
                        if (detalheDto.ID == 0)
                        {
                            if (agendamentoHorarioGerado.Status.ToLower() != "disponível")
                            {
                                isSchedulerOK = false;
                                break;
                            }
                        }
                        if (agendamentoHorarioGerado != null)
                        {
                            agendamentoHorarioGerado.Status = "Disponível";
                            await _serviceAgendamento.PutAgendamentoHorarioGerado(agendamentoHorarioGerado);
                        }
                    }

                    string status = "Agendado";
                    if (detalheDto.ID != 0)
                    {
                        var detalheFromBD = await _service.GetItemDetalhe(detalheDto.ID);
                        status = detalheFromBD.Status;
                        if (status.ToLower() == "agendado")
                            isPedido = false;
                    }

                    var detalheIndex = item.OrcamentoDetalhe.FindIndex(x => x.ExameId == detalheDto.ExameId);
                    if (detalheIndex >= 0)
                    {
                        item.OrcamentoDetalhe[detalheIndex].Status = status;
                    }

                }
                if (!isSchedulerOK)
                {
                    return StatusCode(500, $"Agendamento indisponível. Recarregue a agenda!");
                }

                await _service.DeleteDetalhe(item.OrcamentoCabecalho.ID);
                await _service.DeletePagamento(item.OrcamentoCabecalho.ID);
                foreach (var detalhe in item.OrcamentoDetalhe)
                {
                    detalhe.ID = 0;
                    var createdDetalhe = await _service.PostDetalhe(detalhe);
                    detalhesProcessados.Add(createdDetalhe);


                    //setar o horario como agendado
                    var agendamentoHorarioGerado = await _serviceAgendamento.GetHorarioGerado(detalhe.HorarioId ?? 0);
                    if (agendamentoHorarioGerado != null)
                    {
                        agendamentoHorarioGerado.Status = "Utilizado";
                        await _serviceAgendamento.PutAgendamentoHorarioGerado(agendamentoHorarioGerado);
                    }
                }

                foreach (var pagamento in item.OrcamentoPagamento)
                {
                    pagamento.ID = 0;
                    var createdPagamento = await _service.PostPagamento(pagamento);
                    pagamentosProcessados.Add(createdPagamento);

                }

                if (isPedido)
                {
                    item.OrcamentoCabecalho.Status = "2";
                    await _service.Put(item.OrcamentoCabecalho);
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
            bool isSchedulerOK = true;

            try
            {
                //validar as datas
                foreach (var detalheDto in item.OrcamentoDetalhe)
                {
                    var agendamentoHorarioGerado = await _serviceAgendamento.GetHorarioGerado(detalheDto.HorarioId ?? 0);
                    if (agendamentoHorarioGerado != null)
                    {
                        //novo agendamento e tem que ter o horário disponível
                        if (agendamentoHorarioGerado.Status.ToLower() != "disponível")
                        {
                            isSchedulerOK = false;
                            break;
                        }
                    }
                }
                if (!isSchedulerOK)
                {
                    return StatusCode(500, $"Agendamento indisponível. Recarregue a agenda!");
                }

                var created = await _service.PostCabecalho(item.OrcamentoCabecalho);
                if (created != null){

                    foreach (var detalhe in item.OrcamentoDetalhe)
                    {
                        detalhe.OrcamentoId = created.ID;
                        detalhe.Status = "Agendado";
                        var createdDetalhe = await _service.PostDetalhe(detalhe);
                        detalhesProcessados.Add(detalhe);

                        var agendamentoHorarioGerado = await _serviceAgendamento.GetHorarioGerado(detalhe.HorarioId ?? 0);
                        if (agendamentoHorarioGerado != null)
                        {
                            agendamentoHorarioGerado.Status = "Utilizado";
                            await _serviceAgendamento.PutAgendamentoHorarioGerado(agendamentoHorarioGerado);
                        }
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