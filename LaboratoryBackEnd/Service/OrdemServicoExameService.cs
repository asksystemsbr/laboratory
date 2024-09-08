using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class OrdemServicoExameService : IOrdemServicoExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrdemServicoExame> _repository;

        public OrdemServicoExameService(ILoggerService loggerService, IRepository<OrdemServicoExame> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OrdemServicoExame>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OrdemServicoExame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OrdemServicoExame item)
        {
            await _repository.Put(item);
        }

        public async Task<OrdemServicoExame> Post(OrdemServicoExame item)
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

        public async Task RemoveContex(OrdemServicoExame item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}