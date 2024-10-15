using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EmpresaCategoriaService : IEmpresaCategoriaService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<EmpresaCatagoria> _repository;

        public EmpresaCategoriaService(ILoggerService loggerService, IRepository<EmpresaCatagoria> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<EmpresaCatagoria>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<EmpresaCatagoria> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(EmpresaCatagoria item)
        {
            await _repository.Put(item);
        }

        public async Task<EmpresaCatagoria> Post(EmpresaCatagoria item)
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

        public async Task RemoveContex(EmpresaCatagoria item)
        {
            _repository.RemoveContex(item);
        }
    }
}