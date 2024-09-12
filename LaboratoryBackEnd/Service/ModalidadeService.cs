using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Modalidade> _repository;

        public ModalidadeService(ILoggerService loggerService, IRepository<Modalidade> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Modalidade>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Modalidade> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Modalidade item)
        {
            await _repository.Put(item);
        }

        public async Task<Modalidade> Post(Modalidade item)
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

        public async Task RemoveContex(Modalidade item)
        {
            _repository.RemoveContex(item);
        }
    }
}