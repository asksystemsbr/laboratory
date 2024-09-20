using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ExameApoioService : IExameApoioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<ExameApoio> _repository;

        public ExameApoioService(ILoggerService loggerService, IRepository<ExameApoio> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<ExameApoio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<ExameApoio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(ExameApoio item)
        {
            await _repository.Put(item);
        }

        public async Task<ExameApoio> Post(ExameApoio item)
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

        public async Task RemoveContex(ExameApoio item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}
