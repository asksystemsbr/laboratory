using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class SubCategoriaService : ISubCategoriaService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<SubCategoria> _repository;

        public SubCategoriaService(ILoggerService loggerService, IRepository<SubCategoria> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<SubCategoria>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<SubCategoria> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(SubCategoria item)
        {
            await _repository.Put(item);
        }

        public async Task<SubCategoria> Post(SubCategoria item)
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

        public async Task RemoveContex(SubCategoria item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}