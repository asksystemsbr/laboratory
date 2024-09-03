using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ClientService : IClientService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Cliente> _repository;
        private readonly IRepository<StatusCliente> _repositorySituacaoCliente;

        public ClientService(ILoggerService loggerService,
            IRepository<Cliente> repository,
            IRepository<StatusCliente> repositorySituacaoCliente)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositorySituacaoCliente = repositorySituacaoCliente;
        }

        public async Task<IEnumerable<Cliente>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Cliente> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task Put(Cliente item)
        {
            await _repository.Put(item);
        }

        public async Task<Cliente> Post(Cliente item)
        {
            if (item.ID == 0)
            {
                item.ID = await GetLasdOrOne();
                item.DataCadastro = DateTime.Now;
            }
            return await _repository.Post(item);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(Cliente item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
       
    }
}
