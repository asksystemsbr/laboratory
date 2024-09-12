using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Especialidade> _repository;

        public EspecialidadeService(ILoggerService loggerService, IRepository<Especialidade> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Especialidade>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Especialidade> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Especialidade item)
        {
            await _repository.Put(item);
        }

        public async Task<Especialidade> Post(Especialidade item)
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

        public async Task RemoveContex(Especialidade item)
        {
            _repository.RemoveContex(item);
        }
    }
}