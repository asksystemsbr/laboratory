using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Fornecedor> _repository;

        public FornecedorService(ILoggerService loggerService, IRepository<Fornecedor> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Fornecedor>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Fornecedor> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Fornecedor item)
        {
            await _repository.Put(item);
        }

        public async Task<Fornecedor> Post(Fornecedor item)
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

        public async Task RemoveContex(Fornecedor item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}