using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class GrupoUsuarioService : IGrupoUsuarioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<GrupoUsuario> _repository;

        public GrupoUsuarioService(ILoggerService loggerService, IRepository<GrupoUsuario> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<GrupoUsuario>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<GrupoUsuario> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(GrupoUsuario item)
        {
            await _repository.Put(item);
        }

        public async Task<GrupoUsuario> Post(GrupoUsuario item)
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

        public async Task RemoveContex(GrupoUsuario item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}