using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class UsuarioRecepcaoService : IUsuarioRecepcaoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<UsuarioRecepcao> _repository;

        public UsuarioRecepcaoService(ILoggerService loggerService, IRepository<UsuarioRecepcao> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioRecepcao>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<UsuarioRecepcao> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(UsuarioRecepcao item)
        {
            await _repository.Put(item);
        }

        public async Task<UsuarioRecepcao> Post(UsuarioRecepcao item)
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

        public async Task RemoveContex(UsuarioRecepcao item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}