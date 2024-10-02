using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ModuloService : IModuloService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Modulo> _repository;

        public ModuloService(ILoggerService loggerService, IRepository<Modulo> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Modulo>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Modulo> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Modulo item)
        {
            await _repository.Put(item);
        }

        public async Task<Modulo> Post(Modulo item)
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

        public async Task RemoveContex(Modulo item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}