using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Equipamento> _repository;

        public EquipamentoService(ILoggerService loggerService, IRepository<Equipamento> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Equipamento>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Equipamento> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Equipamento item)
        {
            await _repository.Put(item);
        }

        public async Task<Equipamento> Post(Equipamento item)
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

        public async Task RemoveContex(Equipamento item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}