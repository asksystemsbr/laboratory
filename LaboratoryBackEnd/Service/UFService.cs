using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class UFService : IUFService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<UF> _repository;

        public UFService(ILoggerService loggerService, IRepository<UF> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<UF>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<UF> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(UF item)
        {
            await _repository.Put(item);
        }

        public async Task<UF> Post(UF item)
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

        public async Task RemoveContex(UF item)
        {
            _repository.RemoveContex(item);
        }
    }
}