using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Plano> _repository;

        public PlanoService(ILoggerService loggerService, IRepository<Plano> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Plano>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Plano> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<Plano?> GetItemByConvenio(int id)
        {
            return await _repository.Query().Where(x=>x.ConvenioId==id).FirstOrDefaultAsync();
        }

        public async Task<List<Plano>> GetListByConvenio(int id)
        {
            return await _repository.Query().Where(x => x.ConvenioId == id).ToListAsync();
        }

        public async Task Put(Plano item)
        {
            await _repository.Put(item);
        }

        public async Task<Plano> Post(Plano item)
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

        public async Task RemoveContex(Plano item)
        {
            _repository.RemoveContex(item);
        }
    }
}