using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Service
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrcamentoCabecalho> _repository;
        private readonly IRepository<OrcamentoDetalhe> _repositoryDetalhe;
        private readonly IRepository<OrcamentoPagamento> _repositoryPagamento;
        private readonly IRepository<Exame> _repositoryExames;
        private readonly IRepository<FormaPagamento> _repositoryFormaPagamentos;
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Permissao> _repositoryPermissao;
        private readonly IRepository<Modulo> _repositoryModulo;


        public OrcamentoService(ILoggerService loggerService
            , IRepository<OrcamentoCabecalho> repository
            , IRepository<OrcamentoDetalhe> repositoryDetalhe
            , IRepository<OrcamentoPagamento> repositoryPagamento
            , IRepository<Exame> repositoryExames
            , IRepository<FormaPagamento> repositoryFromaPagamentos
            , IRepository<Usuario> repositoryUsuario
            , IRepository<Permissao> repositoryPermissao
            , IRepository<Modulo> repositoryModulo
            )
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryDetalhe = repositoryDetalhe;
            _repositoryPagamento = repositoryPagamento;
            _repositoryExames = repositoryExames;
            _repositoryFormaPagamentos = repositoryFromaPagamentos;
            _repositoryUsuario = repositoryUsuario;
            _repositoryPermissao = repositoryPermissao;
            _repositoryModulo = repositoryModulo;
        }

        public async Task<IEnumerable<OrcamentoCabecalho>> GetItemsCabecalho()
        {
            return await _repository.GetItems();
        }

        public async Task<OrcamentoCabecalho> GetItemCabecalho(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<List<OrcamentoDetalhe>> GetItemsDetalhe(int idCabecacalho)
        {
            return await _repositoryDetalhe.Query().Where(x=>x.OrcamentoId==idCabecacalho).ToListAsync();
        }

        public async Task<List<OrcamentoPagamento>> GetItemsPagamentos(int idCabecacalho)
        {
            return await _repositoryPagamento.Query().Where(x => x.OrcamentoId == idCabecacalho).ToListAsync();
        }

        public async Task<List<Exame>> GetExamesList(int idCabecalho)
        {
            // Filtra OrcamentoDetalhe pelo OrcamentoId e inclui Exame
            var exameIds = await _repositoryDetalhe.Query()
                .Where(od => od.OrcamentoId == idCabecalho)
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
                .Where(od => od.OrcamentoId == idCabecalho)
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

        public async Task Put(OrcamentoCabecalho item)
        {
            await _repository.Put(item);
        }
        public async Task PutDetalhe(OrcamentoDetalhe item)
        {
            await _repositoryDetalhe.Put(item);
        }

        public async Task PutPagamento(OrcamentoPagamento item)
        {
            await _repositoryPagamento.Put(item);
        }

        public async Task<OrcamentoCabecalho> PostCabecalho(OrcamentoCabecalho item)
        {
            return await _repository.Post(item);
        }

        public async Task<OrcamentoDetalhe> PostDetalhe(OrcamentoDetalhe item)
        {
            return await _repositoryDetalhe.Post(item);
        }

        public async Task<OrcamentoPagamento> PostPagamento(OrcamentoPagamento item)
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

        public async Task RemoveContexCabecalho(OrcamentoCabecalho item)
        {
            _repository.RemoveContex(item);
        }
        public async Task RemoveContexDetalhe(OrcamentoDetalhe item)
        {
            _repositoryDetalhe.RemoveContex(item);
        }
        public async Task RemoveContexPagamento(OrcamentoPagamento item)
        {
            _repositoryPagamento.RemoveContex(item);
        }
    }
}