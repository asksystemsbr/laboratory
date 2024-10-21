using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class RecepcaoConvenioPlanoService : IRecepcaoConvenioPlanoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<RecepcaoConvenioPlano> _repository;

        public RecepcaoConvenioPlanoService(ILoggerService loggerService, IRepository<RecepcaoConvenioPlano> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<RecepcaoConvenioPlanoDto>> GetItems()
        {
            return await _repository.Query()
             .Select(x => new RecepcaoConvenioPlanoDto
             {
                 ID = x.ID,
                 RecepcaoId = x.RecepcaoId,
                 ConvenioId = x.ConvenioId,
                 PlanoId = x.PlanoId
                 //NomeRecepcao = x.Recepcao.NomeRecepcao,
                 //DescricaoConvenio = x.Convenio.Descricao,
                 //DescricaoPlano = x.Plano.Descricao
             })
             .ToListAsync();
        }

        public async Task<RecepcaoConvenioPlano> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<IEnumerable<RecepcaoConvenioPlano>> GetItemsByRecepcao(int recepcaoId)
        {
            return await _repository.Query().Where(x => x.RecepcaoId == recepcaoId).ToListAsync();
        }

        public async Task Put(RecepcaoConvenioPlano item)
        {
            await _repository.Put(item);
        }

        public async Task<RecepcaoConvenioPlano> Post(RecepcaoConvenioPlano item)
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

        public async Task RemoveContex(RecepcaoConvenioPlano item)
        {
            _repository.RemoveContex(item);
        }

        public async Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoConvenioPlano> conveniosPlanos)
        {
           
                // Primeiro, deletamos todos os registros existentes para esta recepção
                await DeleteAllForReception(recepcaoId);

                foreach (var item in conveniosPlanos)
                {
                    item.RecepcaoId = recepcaoId;
                    await Post(item);
                }
            

            //var existingItems = await _repository.Query()
            //                            .AsNoTracking()
            //                            .Where(x => x.RecepcaoId == recepcaoId)
            //                            .ToListAsync();
            //var itemsToRemove = existingItems.Where(e => !conveniosPlanos.Any(cp => cp.ID == e.ID)).ToList();

            //foreach (var item in itemsToRemove)
            //{
            //    await Delete(item.ID);
            //}

            foreach (var item in conveniosPlanos)
            {
                if (item.ID == 0)
                {
                    item.RecepcaoId = recepcaoId;
                    await Post(item);
                }
                else
                {
                    await Put(item);
                }
            }
        }

        public async Task DeleteAllForReception(int recepcaoId)
        {
            var itemsToDelete = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId)
                .ToListAsync();

            foreach (var item in itemsToDelete)
            {
                await Delete(item.ID);
            }
        }

        //public async Task UpdateRestricao(int recepcaoId, bool restricaoValue)
        //{
        //    var itemsToUpdate = await _repository.Query()
        //        .Where(x => x.RecepcaoId == recepcaoId)
        //        .ToListAsync();

        //    foreach (var item in itemsToUpdate)
        //    {
        //        item.Restricao = restricaoValue;
        //        await _repository.Put(item);
        //    }
        //}
    }
}