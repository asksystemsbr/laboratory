using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ConvenioService : IConvenioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Convenio> _repository;

        public ConvenioService(ILoggerService loggerService, IRepository<Convenio> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Convenio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Convenio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Convenio item)
        {
            await _repository.Put(item);
        }

        public async Task<Convenio> Post(Convenio item)
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

        public async Task RemoveContex(Convenio item)
        {
            _repository.RemoveContex(item);
        }
    }
}