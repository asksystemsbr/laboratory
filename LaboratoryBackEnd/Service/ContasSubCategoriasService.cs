using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ContasSubCategoriasService : IContasSubCategoriasService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<ContasSubCategorias> _repository;

        public ContasSubCategoriasService(ILoggerService loggerService,
            IRepository<ContasSubCategorias> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<ContasSubCategorias>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<ContasSubCategorias> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task Put(ContasSubCategorias item)
        {
            await _repository.Put(item);
        }

        public async Task<ContasSubCategorias> Post(ContasSubCategorias item)
        {
            if (item.ID == 0)
            {
                item.ID = await GetLasdOrOne();
            }
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

        public async Task RemoveContex(ContasSubCategorias item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
       
    }
}
