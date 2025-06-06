﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Service
{
    public class SolicianteService : ISolicitanteService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Solicitante> _repository;
        private readonly IRepository<RecepcaoEspecialidadeExame> _repositoryRecepcaoEspecialidadeExame;

        public SolicianteService(ILoggerService loggerService
            , IRepository<Solicitante> repository
            , IRepository<RecepcaoEspecialidadeExame> repositoryRecepcaoEspecialidadeExame)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryRecepcaoEspecialidadeExame = repositoryRecepcaoEspecialidadeExame;
        }

        public async Task<IEnumerable<Solicitante>> GetItems()
        {
            var items= await _repository.GetItems();
            return items.OrderBy(x => x.Descricao);
        }

        public async Task<Solicitante> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<Solicitante> GetItemByCPF(string cpf)
        {
            string noMaks = cpf.Replace(".", "").Replace("-", "");
            return await _repository.Query()
                .Where(x => x.Cpf != null && (x.Cpf == cpf || x.Cpf == noMaks))
                .FirstOrDefaultAsync();

        }

        public async Task<Solicitante> GetItemByCRM(string crm)
        {
            string noMaks = crm.Replace(".", "").Replace("-", "");
            return await _repository.Query()
                .Where(x => x.Crm != null && (x.Crm == crm || x.Crm == noMaks))
                .FirstOrDefaultAsync();
        }        
        public async Task<Solicitante> GetSolicitanteByCRMAndRecepcao(string crm,int recepcaoId)
        {
            string noMaks = crm.Replace(".", "").Replace("-", "");

            var deleteIds = await _repositoryRecepcaoEspecialidadeExame
                .Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.ExameId == null)
                .Select(x => x.EspecialidadeId)  // Seleciona apenas os IDs
                .ToListAsync();

            // Filtra os items excluindo os IDs de deleteIds
            var items = await _repository.Query()
                .Where(x => !deleteIds.Contains(x.EspecialidadeId) // Exclui os itens com IDs em deleteIds
                            && (x.Crm != null && (x.Crm == crm || x.Crm == noMaks)))  
                .OrderBy(x => x.Descricao)
                .FirstOrDefaultAsync();

            return items;
        }

        public async Task<IEnumerable<Solicitante>> GetSolicitanteByRecepcao(int recepcaoId)
        {
            var deleteIds = await _repositoryRecepcaoEspecialidadeExame
                .Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.ExameId == null)
                .Select(x => x.EspecialidadeId)  // Seleciona apenas os IDs
                .ToListAsync();

            // Filtra os items excluindo os IDs de deleteIds
            var items = await _repository.Query()
                .Where(x => !deleteIds.Contains(x.EspecialidadeId))  // Exclui os itens com IDs em deleteIds
                .OrderBy(x => x.Descricao)
                .ToListAsync();

            return items;
        }

        public async Task Put(Solicitante item)
        {
            await _repository.Put(item);
        }

        public async Task<Solicitante> Post(Solicitante item)
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

        public async Task RemoveContex(Solicitante item)
        {
            _repository.RemoveContex(item);
        }
    }
}