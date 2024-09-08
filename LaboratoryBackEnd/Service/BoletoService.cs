using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class BoletoService : IBoletoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Boleto> _repository;

        public BoletoService(ILoggerService loggerService,
            IRepository<Boleto> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Boleto>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Boleto> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task Put(Boleto item)
        {
            await _repository.Put(item);
        }

        public async Task<Boleto> Post(Boleto item)
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

        public async Task RemoveContex(Boleto item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
       
    }
}
