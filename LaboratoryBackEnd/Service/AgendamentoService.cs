using AutoMapper;
using Humanizer;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Service
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<AgendamentoCabecalho> _repository;
        private readonly IRepository<AgendamentoDetalhe> _repositoryDetalhe;
        private readonly IRepository<AgendamentoPagamento> _repositoryPagamento;
        private readonly IRepository<AgendamentoHorario> _repositoryAgendamentoHorario;
        private readonly IRepository<AgendamentoHorarioGerado> _repositoryAgendamentoHorarioGerados;
        private readonly IRepository<Exame> _repositoryExames;
        private readonly IRepository<Convenio> _repositoryConvenio;
        private readonly IRepository<Plano> _repositoryPlano;
        private readonly IRepository<Solicitante> _repositorySolicitante;
        private readonly IRepository<Recepcao> _repositoryRecepcao;
        private readonly IRepository<FormaPagamento> _repositoryFormaPagamentos;
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Permissao> _repositoryPermissao;
        private readonly IRepository<Modulo> _repositoryModulo;
        private readonly IRepository<Cliente> _repositoryCliente;
        private readonly IMapper _mapper;


        public AgendamentoService(ILoggerService loggerService
            , IRepository<AgendamentoCabecalho> repository
            , IRepository<AgendamentoDetalhe> repositoryDetalhe
            , IRepository<AgendamentoPagamento> repositoryPagamento
            , IRepository<Exame> repositoryExames
            , IRepository<Convenio> repositoryConvenio
            , IRepository<Plano> repositoryPlano
            , IRepository<Solicitante> repositorySolicitante
            , IRepository<Recepcao> repositoryRecepcao
            , IRepository<FormaPagamento> repositoryFromaPagamentos
            , IRepository<Usuario> repositoryUsuario
            , IRepository<Permissao> repositoryPermissao
            , IRepository<Modulo> repositoryModulo
            , IRepository<Cliente> repositoryCliente
            , IRepository<AgendamentoHorario> repositoryAgendamentoHorario
            , IRepository<AgendamentoHorarioGerado> repositoryAgendamentoHorarioGerados
            , IMapper mapper
            )
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryDetalhe = repositoryDetalhe;
            _repositoryPagamento = repositoryPagamento;
            _repositoryExames = repositoryExames;
            _repositoryConvenio = repositoryConvenio;
            _repositoryPlano = repositoryPlano;
            _repositorySolicitante = repositorySolicitante;
            _repositoryRecepcao = repositoryRecepcao;
            _repositoryFormaPagamentos = repositoryFromaPagamentos;
            _repositoryUsuario = repositoryUsuario;
            _repositoryPermissao = repositoryPermissao;
            _repositoryModulo = repositoryModulo;
            _repositoryCliente = repositoryCliente;
            _repositoryAgendamentoHorario = repositoryAgendamentoHorario;
            _repositoryAgendamentoHorarioGerados = repositoryAgendamentoHorarioGerados;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgendamentoCabecalho>> GetItemsCabecalho()
        {
            return await _repository
                .Query()
                //.Where(x=>x.Status=="1")
                .OrderBy(x=>x.ID)
                .ToListAsync();
        }

        public async Task<IEnumerable<AgendamentoCabecalho>> GetItemsCabecalhoPedido()
        {
            return await _repository
                .Query()
                .Where(x => x.Status == "2")
                .OrderBy(x => x.ID)
                .ToListAsync();
        }

        public async Task<AgendamentoCabecalho> GetItemCabecalho(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<List<AgendamentoDetalhe>> GetItemsDetalhe(int idCabecacalho)
        {
            return await _repositoryDetalhe.Query().Where(x=>x.AgendamentoId==idCabecacalho).ToListAsync();
        }

        public async Task<List<AgendamentoPagamento>> GetItemsPagamentos(int idCabecacalho)
        {
            return await _repositoryPagamento.Query().Where(x => x.AgendamentoId == idCabecacalho).ToListAsync();
        }

        public async Task<List<Exame>> GetExamesList(int idCabecalho)
        {
            // Filtra OrcamentoDetalhe pelo OrcamentoId e inclui Exame
            var exameIds = await _repositoryDetalhe.Query()
                .Where(od => od.AgendamentoId == idCabecalho)
                    .Select(od => od.ExameId)
                        .ToListAsync();

            // 2. Buscar os exames completos usando os IDs obtidos
            var exames = await _repositoryExames.Query()
                .Where(ex => exameIds.Contains(ex.ID))
                .ToListAsync();

            return exames;
        }

        public async Task<List<FormaPagamento>> GetPagamentosList(int idCabecalho)
        {
            var pagamentosIds = await _repositoryPagamento.Query()
                .Where(od => od.AgendamentoId == idCabecalho)
                    .Select(od => od.PagamentoId)
                        .ToListAsync();

            // 2. Buscar os exames completos usando os IDs obtidos
            var pagamentos = await _repositoryFormaPagamentos.Query()
                .Where(ex => pagamentosIds.Contains(ex.ID))
                .ToListAsync();

            return pagamentos;
        }

        public async Task<bool> CheckDescontoPermission(int idUsuario)
        {
            bool isPerm = false;
            var usuario = await _repositoryUsuario.GetItem(idUsuario);

            if (usuario!=null)
            {
                var permissao = await _repositoryPermissao.Query()
                        .Include(p => p.Modulo)  // Inclui o módulo associado para poder filtrar pela descrição
                        .Where(p => p.Modulo.Descricao == "DescontoOrcamento" && p.GrupoUsuarioId == usuario.GrupoUsuarioId)
                        .FirstOrDefaultAsync();


                //write
                if (permissao != null && permissao.TipoPermissaoId == 2)
                    isPerm = true;
            }

            return isPerm;
        }

        public async Task<string> ValidateCreatePedido(int idOrcamento)
        {
            string ret = string.Empty;
            var orcamento = await _repository.GetItem(idOrcamento);
            if (orcamento != null)
            {
                if(orcamento.Status=="1")
                {
                    #region ValidateCliente
                    var cliente = await _repositoryCliente.GetItem(orcamento.PacienteId??0);
                    if(cliente != null)
                    {
                        if(cliente.EnderecoId>0)
                        {
                            if (string.IsNullOrEmpty( cliente.CpfCnpj))
                                { ret = "Não foi possível localizar o CPF do paciente!"; }
                        }
                        else
                        { ret = "Não foi possível localizar o endereço do paciente!"; }
                    }
                    else
                    { ret = "Não foi possível localizar o paciente!"; }
                    #endregion                   
                }
                else
                { ret = "Orçamento não está com status ativo"; }
            }
            else
                { ret = "Não foi possível localizar o orçamento!"; }


            return ret;
        }

        public async Task<string> ValidateCreateBudget(int idAgendamento)
        {
            string ret = string.Empty;
            var agendamento = await _repository.GetItem(idAgendamento);
            if (agendamento != null)
            {
                if (agendamento.Status != "1")              
                { ret = "Agendamento não está com status ativo"; }
            }
            else
            { ret = "Não foi possível localizar o agendamento!"; }


            return ret;
        }

        public async Task<string> ValidateDeleteAgendamento(int idAgendamento)
        {
            string ret = string.Empty;
            var agendamento = await _repository.GetItem(idAgendamento);
            if (agendamento != null)
            {
                if (agendamento.Status != "1")
                { ret = "Agendamento não está com status ativo"; }
            }
            else
            { ret = "Não foi possível localizar o agendamento!"; }


            return ret;
        }

        public async Task Put(AgendamentoCabecalho item)
        {
            await _repository.Put(item);
        }
        public async Task PutDetalhe(AgendamentoDetalhe item)
        {
            await _repositoryDetalhe.Put(item);
        }

        public async Task PutPagamento(AgendamentoPagamento item)
        {
            await _repositoryPagamento.Put(item);
        }

        public async Task PutAgendamentoHorarioGerado(AgendamentoHorarioGerado item)
        {
            await _repositoryAgendamentoHorarioGerados.Put(item);
        }

        public async Task<AgendamentoCabecalho> PostCabecalho(AgendamentoCabecalho item)
        {
            return await _repository.Post(item);
        }

        public async Task<AgendamentoDetalhe> PostDetalhe(AgendamentoDetalhe item)
        {
            return await _repositoryDetalhe.Post(item);
        }

        public async Task<AgendamentoPagamento> PostPagamento(AgendamentoPagamento item)
        {
            return await _repositoryPagamento.Post(item);
        }

        public async Task<AgendamentoHorario> PostHorarios(AgendamentoHorarioDto item)
        {
            // Criação do agendamento
            var agendamento = new AgendamentoHorario
            {
                RecepcaoId = item.UnidadeId,
                ConvenioId = item.ConvenioId,
                PlanoId = item.PlanoId,
                SolicitanteId = item.SolicitanteId,
                ExameId = item.ExameId,
                DataInicio = item.DataInicio,
                HoraInicio = TimeSpan.Parse(item.HoraInicio),
                HoraFim = TimeSpan.Parse(item.HoraFim),
                DuracaoMinutos = item.DuracaoMinutos,
                IntervaloMinutos = item.IntervaloMinutos
            };

            try
            {
                AgendamentoHorario retorno =null;

                // Geração de horários automáticos
                var dataAtual = item.DataInicio;

                while (dataAtual <= item.DataFim)
                {
                    agendamento.DataInicio = dataAtual;
                    agendamento.ID = 0;
                    retorno = await _repositoryAgendamentoHorario.Post(agendamento);

                    var horarioAtual = dataAtual.Date + agendamento.HoraInicio;

                    while (horarioAtual.TimeOfDay + TimeSpan.FromMinutes(item.DuracaoMinutos) <= agendamento.HoraFim)
                    {
                        var horarioGerado = new AgendamentoHorarioGerado
                        {
                            AgendamentoHorarioId = retorno.ID,
                            Horario = horarioAtual,
                            Status = "Disponível"
                        };

                        horarioAtual = horarioAtual.AddMinutes(item.DuracaoMinutos + item.IntervaloMinutos);
                        await _repositoryAgendamentoHorarioGerados.Post(horarioGerado);
                    }

                    dataAtual = dataAtual.AddDays(1); // Avançar para o próximo dia
                }


                return retorno;
            }
            catch (Exception ex)
            {
                await RemoveContexHorario(agendamento);
                throw ex;
            }

            
        }
        public async Task<AgendamentoHorario> GetItemHorario(int id)
        {
            return await _repositoryAgendamentoHorario.GetItem(id);
        }

        public async Task<List<AgendamentoHorarioDto>> GetItemsHorarios()
        {

            var agendamentos = await _repositoryAgendamentoHorario.GetItems();

            if (agendamentos == null) return null;

            List<AgendamentoHorarioDto> lstRet = new List<AgendamentoHorarioDto>();

            foreach (var item in agendamentos)
            {
                var unidade = await _repositoryRecepcao.GetItem(item.RecepcaoId??0);
                var convenio = await _repositoryConvenio.GetItem(item.ConvenioId ?? 0);
                var plano = await _repositoryPlano.GetItem(item.PlanoId ?? 0);
                var solicitante = await _repositorySolicitante.GetItem(item.SolicitanteId ?? 0);
                var exame = await _repositoryExames.GetItem(item.ExameId ?? 0);

                var agendamentoDto = _mapper.Map<AgendamentoHorarioDto>(item);
                agendamentoDto.Unidade = unidade?.NomeRecepcao;
                agendamentoDto.Convenio = convenio?.Descricao;
                agendamentoDto.Plano = plano?.Descricao;
                agendamentoDto.Solicitante = solicitante?.Descricao;
                agendamentoDto.Exame = exame?.NomeExame;

                lstRet.Add(agendamentoDto);
            }
            

            return lstRet;
        }

        public async Task<AgendamentoHorarioGerado> GetHorarioGerado(int id)
        {
            return await _repositoryAgendamentoHorarioGerados.GetItem(id);
        }

        public async Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGerado(int idAgendamento)
        {
            return await _repositoryAgendamentoHorarioGerados
                .Query()
                .Where(x => 
                x.AgendamentoHorarioId == idAgendamento
                ).ToListAsync();
        }
        public async Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGeradoPreenchidos(int idAgendamento)
        {
            return await _repositoryAgendamentoHorarioGerados
                .Query()
                .Where(x =>
                x.AgendamentoHorarioId == idAgendamento
                && x.Status.ToLower() != "disponível"
                ).ToListAsync();
        }

        public async Task<List<AgendamentoHorarioGerado>> GetItemsHorarioGeradoDisponible(
            int convenioId
            ,int planoId
            ,int unidadeId
            ,int exameId
            ,DateTime dataSolicitada
            )
        {
            var agenda = await _repositoryAgendamentoHorario
                .Query()
                .Where(x =>
                            x.RecepcaoId == unidadeId
                            && x.ConvenioId == convenioId
                            && x.PlanoId == planoId
                            && x.ExameId == exameId
                            && x.DataInicio == dataSolicitada
                ).FirstOrDefaultAsync();

            if (agenda == null) return null;

            return await _repositoryAgendamentoHorarioGerados
                .Query()
                .Where(x =>
                x.AgendamentoHorarioId == agenda.ID
                && x.Status.ToLower() == "disponível"
                ).ToListAsync();
        }

        public async Task DeleteAgendamentoHorario(int id)
        {
            await _repositoryAgendamentoHorario.Delete(id);
        }

        public async Task DeleteAgendamentoHorarioGerado(int idCabecalho)
        {
            var detalhes = await GetItemsHorarioGerado(idCabecalho);
            foreach (var item in detalhes)
            {
                await _repositoryAgendamentoHorarioGerados.Delete(item.ID);
            }
        }

        public async Task DeleteAgendamentoHorarioGeradoByDetalhe(int idDetalhe)
        {
            await _repositoryAgendamentoHorarioGerados.Delete(idDetalhe);
        }

        public async Task DeleteCabecalho(int id)
        {
            await _repository.Delete(id);
        }

        public async Task DeleteDetalhe(int idCabecalho)
        {
            var detalhes = await GetItemsDetalhe(idCabecalho);
            foreach (var item in detalhes)
            {
                await _repositoryDetalhe.Delete(item.ID);
            }
        }

        public async Task DeletePagamento(int idCabecalho)
        {
            var pagamentos = await GetItemsPagamentos(idCabecalho);
            foreach (var item in pagamentos)
            {
                await _repositoryPagamento.Delete(item.ID);
            }
        }

        public bool ExistsCabecalho(int id)
        {
            return _repository.Exists(id);
        }
        public async Task RemoveContexAgendamentoHorario(AgendamentoHorario item)
        {
            _repositoryAgendamentoHorario.RemoveContex(item);
        }
        public async Task RemoveContexCabecalho(AgendamentoCabecalho item)
        {
            _repository.RemoveContex(item);
        }
        public async Task RemoveContexDetalhe(AgendamentoDetalhe item)
        {
            _repositoryDetalhe.RemoveContex(item);
        }
        public async Task RemoveContexPagamento(AgendamentoPagamento item)
        {
            _repositoryPagamento.RemoveContex(item);
        }

        public async Task RemoveContexHorario(AgendamentoHorario item)
        {
            _repositoryAgendamentoHorario.RemoveContex(item);
        }
    }
}