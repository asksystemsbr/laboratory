using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ConvenioService : IConvenioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Convenio> _repository;
        private readonly IRepository<Endereco> _repositoryEndereco; 

        public ConvenioService(ILoggerService loggerService
            , IRepository<Convenio> repository
            , IRepository<Endereco> repositoryEndereco)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<IEnumerable<Convenio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Convenio> GetItem(int id)
        {
            return await _repository.GetItem(id);
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