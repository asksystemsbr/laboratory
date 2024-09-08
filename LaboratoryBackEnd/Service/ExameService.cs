using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ExameService : IExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Exame> _repository;

        public ExameService(ILoggerService loggerService, IRepository<Exame> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Exame>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Exame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Exame item)
        {
            await _repository.Put(item);
        }

        public async Task<Exame> Post(Exame item)
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

        public async Task RemoveContex(Exame item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}
