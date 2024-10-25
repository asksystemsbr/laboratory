using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<FormaPagamento> _repository;

        public FormaPagamentoService(ILoggerService loggerService, IRepository<FormaPagamento> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<FormaPagamento>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<FormaPagamento> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(FormaPagamento item)
        {
            await _repository.Put(item);
        }

        public async Task<FormaPagamento> Post(FormaPagamento item)
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

        public async Task RemoveContex(FormaPagamento item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}