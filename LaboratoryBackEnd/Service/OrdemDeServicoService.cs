using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class OrdemDeServicoService : IOrdemDeServicoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrdemDeServico> _repository;

        public OrdemDeServicoService(ILoggerService loggerService, IRepository<OrdemDeServico> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OrdemDeServico>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OrdemDeServico> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OrdemDeServico item)
        {
            await _repository.Put(item);
        }

        public async Task<OrdemDeServico> Post(OrdemDeServico item)
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

        public async Task RemoveContex(OrdemDeServico item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}