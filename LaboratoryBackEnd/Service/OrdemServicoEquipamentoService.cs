using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class OrdemServicoEquipamentoService : IOrdemServicoEquipamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrdemServicoEquipamento> _repository;

        public OrdemServicoEquipamentoService(ILoggerService loggerService, IRepository<OrdemServicoEquipamento> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OrdemServicoEquipamento>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OrdemServicoEquipamento> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OrdemServicoEquipamento item)
        {
            await _repository.Put(item);
        }

        public async Task<OrdemServicoEquipamento> Post(OrdemServicoEquipamento item)
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

        public async Task RemoveContex(OrdemServicoEquipamento item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}