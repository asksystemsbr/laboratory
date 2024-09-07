using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class StatusClienteService : IStatusClienteService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<StatusCliente> _repository;

        public StatusClienteService(ILoggerService loggerService, IRepository<StatusCliente> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<StatusCliente>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<StatusCliente> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(StatusCliente item)
        {
            await _repository.Put(item);
        }

        public async Task<StatusCliente> Post(StatusCliente item)
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

        public async Task RemoveContex(StatusCliente item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}
