using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class StatusPagamentoService : IStatusPagamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<StatusPagamento> _repository;

        public StatusPagamentoService(ILoggerService loggerService, IRepository<StatusPagamento> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<StatusPagamento>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<StatusPagamento> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(StatusPagamento item)
        {
            await _repository.Put(item);
        }

        public async Task<StatusPagamento> Post(StatusPagamento item)
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

        public async Task RemoveContex(StatusPagamento item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}