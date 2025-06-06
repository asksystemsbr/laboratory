﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Plano> _repository;
        private readonly IRepository<RecepcaoConvenioPlano> _repositoryRecepcaoConvenioPlano;

        public PlanoService(ILoggerService loggerService
            , IRepository<Plano> repository
            , IRepository<RecepcaoConvenioPlano> repositoryRecepcaoConvenioPlano)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryRecepcaoConvenioPlano = repositoryRecepcaoConvenioPlano;
        }

        public async Task<IEnumerable<Plano>> GetItems()
        {
            var items = await _repository.GetItems();
            return items.OrderBy(x => x.Descricao);
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

        public async Task<List<Plano>> GetListByConvenioAndRecepcao(int id,int recepcaoId)
        {
            // Obtém os IDs que devem ser excluídos
            var deleteIds = await _repositoryRecepcaoConvenioPlano
                .Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.PlanoId != null)
                .Select(x => x.PlanoId)  // Seleciona apenas os IDs
                .ToListAsync();

            var itens= await _repository.Query()
                .Where(x => x.ConvenioId == id && !deleteIds.Contains(x.ID))
                .ToListAsync();

            return itens;
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