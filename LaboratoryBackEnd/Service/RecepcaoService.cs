using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class RecepcaoService : IRecepcaoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Recepcao> _repository;

        public RecepcaoService(ILoggerService loggerService, IRepository<Recepcao> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Recepcao>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Recepcao> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Recepcao item)
        {
            await _repository.Put(item);
        }

        public async Task<Recepcao> Post(Recepcao item)
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

        public async Task RemoveContex(Recepcao item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}