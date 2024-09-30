using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class TabelaPrecoItensService : ITabelaPrecoItensService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<TabelaPrecoItens> _repository;

        public TabelaPrecoItensService(ILoggerService loggerService, IRepository<TabelaPrecoItens> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<TabelaPrecoItens>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<TabelaPrecoItens> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(TabelaPrecoItens item)
        {
            await _repository.Put(item);
        }

        public async Task<TabelaPrecoItens> Post(TabelaPrecoItens item)
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

        public async Task RemoveContex(TabelaPrecoItens item)
        {
            _repository.RemoveContex(item);
        }
    }
}