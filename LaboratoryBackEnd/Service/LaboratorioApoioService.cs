using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class LaboratorioApoioService : ILaboratorioApoioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<LaboratorioApoio> _repository;

        public LaboratorioApoioService(ILoggerService loggerService, IRepository<LaboratorioApoio> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<LaboratorioApoio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<LaboratorioApoio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(LaboratorioApoio item)
        {
            await _repository.Put(item);
        }

        public async Task<LaboratorioApoio> Post(LaboratorioApoio item)
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

        public async Task RemoveContex(LaboratorioApoio item)
        {
            _repository.RemoveContex(item);
        }
    }
}