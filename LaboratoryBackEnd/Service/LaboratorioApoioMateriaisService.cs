using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class LaboratorioApoioMateriaisService : ILaboratorioApoioMateriaisService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<LaboratorioApoioMateriais> _repository;
        private readonly IRepository<MaterialApoio> _repositoryMaterial;

        public LaboratorioApoioMateriaisService(ILoggerService loggerService
            , IRepository<LaboratorioApoioMateriais> repository
            , IRepository<MaterialApoio> repositoryMaterial)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryMaterial = repositoryMaterial;
        }

        public async Task<IEnumerable<LaboratorioApoioMateriais>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<LaboratorioApoioMateriais> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<List<LaboratorioApoioMateriais>> GetItemByLaboratorio(int id)
        {
            return await _repository.Query().Where(x => x.LaboratorioApoioId==id).ToListAsync();
        }

        public async Task<List<MaterialApoio>> GetMaterialItemByLaboratorio(int laboratorioApoioId)
        {
            // Executa a query para pegar a lista de MaterialApoio baseado no LaboratorioApoioId
            var query = from labMat in _repository.Query() // Tabela LaboratorioApoioMateriais
                        join material in _repositoryMaterial.Query() // Tabela MaterialApoio
                        on labMat.MaterialApoioId equals material.ID // Join pelo campo MaterialApoioId
                        where labMat.LaboratorioApoioId == laboratorioApoioId // Filtra pelo LaboratorioApoioId
                        select material; // Seleciona o MaterialApoio

            // Retorna a lista
            return (await _repositoryMaterial.GenericQuery(query)).ToList();
        }

        public async Task Put(LaboratorioApoioMateriais item)
        {
            await _repository.Put(item);
        }

        public async Task<LaboratorioApoioMateriais> Post(LaboratorioApoioMateriais item)
        {
            return await _repository.Post(item);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
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


        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(LaboratorioApoioMateriais item)
        {
            _repository.RemoveContex(item);
        }
    }
}