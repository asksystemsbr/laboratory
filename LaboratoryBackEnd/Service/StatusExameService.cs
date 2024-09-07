using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class StatusExameService : IStatusExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<StatusExame> _repository;

        public StatusExameService(ILoggerService loggerService, IRepository<StatusExame> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<StatusExame>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<StatusExame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(StatusExame item)
        {
            await _repository.Put(item);
        }

        public async Task<StatusExame> Post(StatusExame item)
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

        public async Task RemoveContex(StatusExame item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}