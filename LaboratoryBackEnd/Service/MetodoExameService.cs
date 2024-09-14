using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class MetodoExameService : IMetodoExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<MetodoExame> _repository;

        public MetodoExameService(ILoggerService loggerService, IRepository<MetodoExame> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<MetodoExame>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<MetodoExame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(MetodoExame item)
        {
            await _repository.Put(item);
        }

        public async Task<MetodoExame> Post(MetodoExame item)
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

        public async Task RemoveContex(MetodoExame item)
        {
            _repository.RemoveContex(item);
        }
    }
}