using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class TipoSolicianteService : ITipoSolicitanteService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<TipoSolicitante> _repository;

        public TipoSolicianteService(ILoggerService loggerService, IRepository<TipoSolicitante> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<TipoSolicitante>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<TipoSolicitante> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(TipoSolicitante item)
        {
            await _repository.Put(item);
        }

        public async Task<TipoSolicitante> Post(TipoSolicitante item)
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

        public async Task RemoveContex(TipoSolicitante item)
        {
            _repository.RemoveContex(item);
        }
    }
}