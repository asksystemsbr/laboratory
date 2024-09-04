using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ContasHistoricoService : IContasHistoricoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<ContasHistorico> _repository;

        public ContasHistoricoService(ILoggerService loggerService,
            IRepository<ContasHistorico> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<ContasHistorico>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<ContasHistorico> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task Put(ContasHistorico item)
        {
            await _repository.Put(item);
        }

        public async Task<ContasHistorico> Post(ContasHistorico item)
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

        public async Task RemoveContex(ContasHistorico item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }

    }
}
