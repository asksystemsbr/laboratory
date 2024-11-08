using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class ConvenioService : IConvenioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Convenio> _repository;
        private readonly IRepository<Endereco> _repositoryEndereco;
        private readonly IRepository<RecepcaoConvenioPlano> _repositoryRecepcaoConvenioPlano;


        public ConvenioService(ILoggerService loggerService
            , IRepository<Convenio> repository
            , IRepository<Endereco> repositoryEndereco
            , IRepository<RecepcaoConvenioPlano> repositoryRecepcaoConvenioPlano)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
            _repositoryRecepcaoConvenioPlano = repositoryRecepcaoConvenioPlano;
        }

        public async Task<IEnumerable<Convenio>> GetItems()
        {
            var items= await _repository.GetItems();
            return items.OrderBy(x => x.Descricao);
        }

        public async Task<Convenio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<Convenio> GetItemByCodigo(string codigo)
        {
            return await _repository
                .Query()
                .Where(x=>x.CodOperadora==codigo)
                .FirstOrDefaultAsync();
        }
        public async Task<Convenio> GetConvenioByCodigoRecepcao(string codigoConvenio,int recepcaoId)
        {
            var deleteIds = await _repositoryRecepcaoConvenioPlano
                .Query()
                .Where(x => x.RecepcaoId == recepcaoId
                            && x.PlanoId == null)
                 .Select(x => x.ConvenioId)
                .ToListAsync();

            if (deleteIds.Contains(recepcaoId))
                return null;

            var items = await _repository.Query()
                .Where(x => !deleteIds.Contains(x.ID) && x.CodOperadora==codigoConvenio)
                .OrderBy(x => x.Descricao)
                .FirstOrDefaultAsync();

            return items;
        }
        

        public async Task<IEnumerable<Convenio>> GetConveniosByRecepcao(int codigo)
        {
            var deleteIds = await _repositoryRecepcaoConvenioPlano
                .Query()
                .Where(x=> x.RecepcaoId==codigo
                            && x.PlanoId==null)
                 .Select(x => x.ConvenioId)
                .ToListAsync();

            var items = await _repository.Query().Where(x=>!deleteIds.Contains(x.ID))
                .OrderBy(x=>x.Descricao)
                .ToListAsync();

            return items;
        }


        public async Task Put(Convenio item)
        {
            await _repository.Put(item);
            if (item.EnderecoId > 0)
            {
                item.Endereco.ID = item.EnderecoId;
                await _repositoryEndereco.Put(item.Endereco);
            }
        }

        public async Task<Convenio> Post(Convenio item)
        {
            return await _repository.Post(item);
        }

        public async Task Delete(int id,int idEndereco)
        {
            await _repository.Delete(id);
            if (idEndereco > 0)
                await _repositoryEndereco.Delete(idEndereco);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(Convenio item)
        {
            _repository.RemoveContex(item);
        }
    }
}