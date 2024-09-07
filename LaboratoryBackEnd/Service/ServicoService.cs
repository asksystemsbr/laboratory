using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class ServicoService : IServicoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Servico> _repository;

        public ServicoService(ILoggerService loggerService, IRepository<Servico> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Servico>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Servico> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Servico item)
        {
            await _repository.Put(item);
        }

        public async Task<Servico> Post(Servico item)
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

        public async Task RemoveContex(Servico item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}