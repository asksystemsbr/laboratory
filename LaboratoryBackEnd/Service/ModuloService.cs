using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ModuloService : IModuloService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Modulos> _repository;

        public ModuloService(ILoggerService loggerService, IRepository<Modulos> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Modulos>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Modulos> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Modulos item)
        {
            await _repository.Put(item);
        }

        public async Task<Modulos> Post(Modulos item)
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

        public async Task RemoveContex(Modulos item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}