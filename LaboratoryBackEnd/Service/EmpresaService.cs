using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepository<Empresa> _repository;
        private readonly ILoggerService _loggerService;

        public EmpresaService(ILoggerService loggerService,
            IRepository<Empresa> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Empresa>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Empresa> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Empresa item)
        {
            await _repository.Put(item);
        }

        public async Task<Empresa> Post(Empresa item)
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

        public async Task RemoveContex(Empresa item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}