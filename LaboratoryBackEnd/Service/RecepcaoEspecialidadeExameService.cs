using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class RecepcaoEspecialidadeExameService : IRecepcaoEspecialidadeExameService
    {
        private readonly IRepository<RecepcaoEspecialidadeExame> _repository;

        public RecepcaoEspecialidadeExameService(IRepository<RecepcaoEspecialidadeExame> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecepcaoEspecialidadeExameDto>> GetItemsByRecepcao(int recepcaoId)
        {
            var items = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId)
                .ToListAsync();

            var resultado = items.GroupBy(x => x.EspecialidadeId)
                .Select(g => new RecepcaoEspecialidadeExameDto
                {
                    RecepcaoId = recepcaoId,
                    EspecialidadeId = g.Key,
                    ExamesId = g.Where(x => x.ExameId.HasValue).Select(x => x.ExameId.Value).ToList()
                });

            return resultado;
        }

        public async Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoEspecialidadeExameDto> especialidadesExames)
        {
            foreach (var especialidadeExame in especialidadesExames)
            {
                await DeleteAllForReception(recepcaoId, especialidadeExame.EspecialidadeId);

                foreach (var exameId in especialidadeExame.ExamesId)
                {
                    var newEntry = new RecepcaoEspecialidadeExame
                    {
                        RecepcaoId = recepcaoId,
                        EspecialidadeId = especialidadeExame.EspecialidadeId,
                        ExameId = exameId
                    };
                    await _repository.Post(newEntry);
                }
            }
        }

        public async Task DeleteAllForReception(int recepcaoId, int especialidadeId)
        {
            var itemsToDelete = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.EspecialidadeId == especialidadeId)
                .ToListAsync();

            foreach (var item in itemsToDelete)
            {
                await _repository.Delete(item.ID);
            }
        }
    }
}