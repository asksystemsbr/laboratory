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

        public async Task Put(RecepcaoEspecialidadeExame item)
        {
            await _repository.Put(item);
        }

        public async Task<RecepcaoEspecialidadeExame> Post(RecepcaoEspecialidadeExame item)
        {
            return await _repository.Post(item);
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

        public async Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoEspecialidadeExame> especialidadesExames)
        {
            foreach (var especialidadesExame in especialidadesExames)
            {
                if (especialidadesExame.EspecialidadeId.HasValue)
                {
                    await DeleteAllForReception(recepcaoId, especialidadesExame.EspecialidadeId.Value);
                }

                if (especialidadesExame.ExamesId != null && especialidadesExame.ExamesId.Count > 0)
                {
                    foreach (var exameId in especialidadesExame.ExamesId)
                    {
                        await Post(new RecepcaoEspecialidadeExame
                        {
                            RecepcaoId = recepcaoId,
                            EspecialidadeId = especialidadesExame.EspecialidadeId,
                            ExameId = exameId
                        });
                    }
                }
                else
                {
                    await Post(new RecepcaoEspecialidadeExame
                    {
                        RecepcaoId = recepcaoId,
                        EspecialidadeId = especialidadesExame.EspecialidadeId.Value,
                        ExameId = especialidadesExame.ExameId
                    });
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