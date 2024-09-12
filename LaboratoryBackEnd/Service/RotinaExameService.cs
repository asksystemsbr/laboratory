using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class RotinaExameService : IRotinaExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<RotinaExame> _repository;

        public RotinaExameService(ILoggerService loggerService, IRepository<RotinaExame> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<RotinaExame>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<RotinaExame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(RotinaExame item)
        {
            await _repository.Put(item);
        }

        public async Task<RotinaExame> Post(RotinaExame item)
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

        public async Task RemoveContex(RotinaExame item)
        {
            _repository.RemoveContex(item);
        }
    }
}