using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class MetodosPagamentoService : IMetodosPagamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<MetodosPagamento> _repository;

        public MetodosPagamentoService(ILoggerService loggerService, IRepository<MetodosPagamento> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<MetodosPagamento>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<MetodosPagamento> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(MetodosPagamento item)
        {
            await _repository.Put(item);
        }

        public async Task<MetodosPagamento> Post(MetodosPagamento item)
        {
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

        public async Task RemoveContex(MetodosPagamento item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}