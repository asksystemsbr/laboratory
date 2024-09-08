using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class PermissaoService : IPermissaoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Permissao> _repository;

        public PermissaoService(ILoggerService loggerService, IRepository<Permissao> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Permissao>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Permissao> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Permissao item)
        {
            await _repository.Put(item);
        }

        public async Task<Permissao> Post(Permissao item)
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

        public async Task RemoveContex(Permissao item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}