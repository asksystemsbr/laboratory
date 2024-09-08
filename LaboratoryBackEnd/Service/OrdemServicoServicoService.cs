using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class OrdemServicoServicoService : IOrdemServicoServicoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrdemServicoServico> _repository;

        public OrdemServicoServicoService(ILoggerService loggerService, IRepository<OrdemServicoServico> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OrdemServicoServico>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OrdemServicoServico> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OrdemServicoServico item)
        {
            await _repository.Put(item);
        }

        public async Task<OrdemServicoServico> Post(OrdemServicoServico item)
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

        public async Task RemoveContex(OrdemServicoServico item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}