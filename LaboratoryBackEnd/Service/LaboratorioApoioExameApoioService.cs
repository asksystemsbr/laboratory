using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class LaboratorioApoioExameApoioService : ILaboratorioApoioExameApoioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<LaboratorioApoioExameApoio> _repository;
        private readonly IRepository<ExameApoio> _repositoryExameApoio;

        public LaboratorioApoioExameApoioService(ILoggerService loggerService
            , IRepository<LaboratorioApoioExameApoio> repository
            , IRepository<ExameApoio> repositoryExameApoio)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryExameApoio = repositoryExameApoio;
        }

        public async Task<IEnumerable<LaboratorioApoioExameApoio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<LaboratorioApoioExameApoio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<List<LaboratorioApoioExameApoio>> GetItemByLaboratorio(int id)
        {
            return await _repository.Query().Where(x => x.LaboratorioApoioId == id).ToListAsync();
        }

        public async Task<List<ExameApoio>> GetExameApoioItemByLaboratorio(int laboratorioApoioId)
        {

            // Executa a query para pegar a lista de MaterialApoio baseado no LaboratorioApoioId
            var query = from labMat in _repository.Query() // Tabela LaboratorioApoioMateriais
                        join exameApoio in _repositoryExameApoio.Query() // Tabela MaterialApoio
                        on labMat.ExameApoioId equals exameApoio.ID // Join pelo campo MaterialApoioId
                        where labMat.LaboratorioApoioId == laboratorioApoioId // Filtra pelo LaboratorioApoioId
                        select exameApoio; // Seleciona o MaterialApoio

            // Retorna a lista
            return (await _repositoryExameApoio.GenericQuery(query)).ToList();
        }

        public async Task Put(LaboratorioApoioExameApoio item)
        {
            await _repository.Put(item);
        }

        public async Task<LaboratorioApoioExameApoio> Post(LaboratorioApoioExameApoio item)
        {
            return await _repository.Post(item);
        }

        public async Task DeleteByLaboratorio(int id)
        {
            var items = await GetItemByLaboratorio(id);
            if (items != null)
            {
                foreach (var item in items)
                {
                    await _repository.Delete(item.ID);
                }
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(LaboratorioApoioExameApoio item)
        {
            _repository.RemoveContex(item);
        }
    }
}