using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class SetorService : ISetorService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Setor> _repository;

        public SetorService(ILoggerService loggerService, IRepository<Setor> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Setor>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Setor> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Setor item)
        {
            await _repository.Put(item);
        }

        public async Task<Setor> Post(Setor item)
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

        public async Task RemoveContex(Setor item)
        {
            _repository.RemoveContex(item);
        }
    }
}