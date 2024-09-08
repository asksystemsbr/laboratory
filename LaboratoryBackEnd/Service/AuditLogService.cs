using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class AuditLogService : IAuditLogService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<AuditLog> _repository;

        public AuditLogService(ILoggerService loggerService, IRepository<AuditLog> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<AuditLog>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<AuditLog> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(AuditLog item)
        {
            await _repository.Put(item);
        }

        public async Task<AuditLog> Post(AuditLog item)
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

        public async Task RemoveContex(AuditLog item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}