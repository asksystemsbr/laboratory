using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ContasService : IContasService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Contas> _repository;

        public ContasService(ILoggerService loggerService,
            IRepository<Contas> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Contas>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Contas> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task Put(Contas item)
        {
            await _repository.Put(item);
        }

        public async Task<Contas> Post(Contas item)
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

        public async Task RemoveContex(Contas item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
       
    }
}
