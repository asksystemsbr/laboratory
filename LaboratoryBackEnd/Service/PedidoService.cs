using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly ILoggerService _loggerService;        
        private readonly IRepository<PedidoCabecalho> _repository;
        private readonly IRepository<PedidoDetalhe> _repositoryDetalhe;
        private readonly IRepository<PedidoPagamento> _repositoryPagamento;
        private readonly IRepository<OrcamentoCabecalho> _repositoryOrcamentoCabecalho;
        private readonly IRepository<Exame> _repositoryExames;
        private readonly IRepository<FormaPagamento> _repositoryFormaPagamentos;
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Permissao> _repositoryPermissao;
        private readonly IRepository<Modulo> _repositoryModulo;
        private readonly IRepository<Cliente> _repositoryCliente;


        public PedidoService(ILoggerService loggerService
            , IRepository<PedidoCabecalho> repository
            , IRepository<PedidoDetalhe> repositoryDetalhe
            , IRepository<PedidoPagamento> repositoryPagamento
            , IRepository<OrcamentoCabecalho> repositoryOrcamentoCabecalho
            , IRepository<Exame> repositoryExames
            , IRepository<FormaPagamento> repositoryFromaPagamentos
            , IRepository<Usuario> repositoryUsuario
            , IRepository<Permissao> repositoryPermissao
            , IRepository<Modulo> repositoryModulo
            , IRepository<Cliente> repositoryCliente
            )
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryDetalhe = repositoryDetalhe;
            _repositoryPagamento = repositoryPagamento;
            _repositoryOrcamentoCabecalho = repositoryOrcamentoCabecalho;
            _repositoryExames = repositoryExames;
            _repositoryFormaPagamentos = repositoryFromaPagamentos;
            _repositoryUsuario = repositoryUsuario;
            _repositoryPermissao = repositoryPermissao;
            _repositoryModulo = repositoryModulo;
            _repositoryCliente = repositoryCliente;
        }

        public async Task<IEnumerable<PedidoCabecalho>> GetItemsCabecalho()
        {
            return await _repository
                .Query()
                .Where(x=>x.Status=="1")
                .OrderBy(x=>x.ID)
                .ToListAsync();
        }

        public async Task<IEnumerable<PedidoCabecalho>> GetItemsCabecalhoPedido()
        {
            return await _repository
                .Query()
                .Where(x => x.Status == "2")
                .OrderBy(x => x.ID)
                .ToListAsync();
        }

        public async Task<PedidoCabecalho> GetItemCabecalho(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<List<PedidoDetalhe>> GetItemsDetalhe(int idCabecacalho)
        {
            return await _repositoryDetalhe.Query().Where(x=>x.PedidoId==idCabecacalho).ToListAsync();
        }

        public async Task<List<PedidoPagamento>> GetItemsPagamentos(int idCabecacalho)
        {
            return await _repositoryPagamento.Query().Where(x => x.PedidoId == idCabecacalho).ToListAsync();
        }

        public async Task<List<Exame>> GetExamesList(int idCabecalho)
        {
            // Filtra OrcamentoDetalhe pelo OrcamentoId e inclui Exame
            var exameIds = await _repositoryDetalhe.Query()
                .Where(od => od.PedidoId == idCabecalho)
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
                .Where(od => od.PedidoId == idCabecalho)
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
            var orcamento = await _repositoryOrcamentoCabecalho.GetItem(idOrcamento);
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
        

        public async Task Put(PedidoCabecalho item)
        {
            await _repository.Put(item);
        }
        public async Task PutDetalhe(PedidoDetalhe item)
        {
            await _repositoryDetalhe.Put(item);
        }

        public async Task PutPagamento(PedidoPagamento item)
        {
            await _repositoryPagamento.Put(item);
        }

        public async Task<PedidoCabecalho> PostCabecalho(PedidoCabecalho item)
        {
            return await _repository.Post(item);
        }

        public async Task<PedidoDetalhe> PostDetalhe(PedidoDetalhe item)
        {
            return await _repositoryDetalhe.Post(item);
        }

        public async Task<PedidoPagamento> PostPagamento(PedidoPagamento item)
        {
            return await _repositoryPagamento.Post(item);
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

        public async Task RemoveContexCabecalho(PedidoCabecalho item)
        {
            _repository.RemoveContex(item);
        }
        public async Task RemoveContexDetalhe(PedidoDetalhe item)
        {
            _repositoryDetalhe.RemoveContex(item);
        }
        public async Task RemoveContexPagamento(PedidoPagamento item)
        {
            _repositoryPagamento.RemoveContex(item);
        }
    }
}