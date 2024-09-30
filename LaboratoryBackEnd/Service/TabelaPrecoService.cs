using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class TabelaPrecoService : ITabelaPrecoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<TabelaPreco> _repository;

        public TabelaPrecoService(ILoggerService loggerService, IRepository<TabelaPreco> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<TabelaPreco>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<TabelaPreco> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(TabelaPreco item)
        {
            await _repository.Put(item);
        }

        public async Task<TabelaPreco> Post(TabelaPreco item)
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

        public async Task RemoveContex(TabelaPreco item)
        {
            _repository.RemoveContex(item);
        }
    }
}