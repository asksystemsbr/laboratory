﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class RecipienteAmostraService : IRecipienteAmostraService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<RecipienteAmostra> _repository;

        public RecipienteAmostraService(ILoggerService loggerService, IRepository<RecipienteAmostra> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<RecipienteAmostra>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<RecipienteAmostra> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(RecipienteAmostra item)
        {
            await _repository.Put(item);
        }

        public async Task<RecipienteAmostra> Post(RecipienteAmostra item)
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

        public async Task RemoveContex(RecipienteAmostra item)
        {
            _repository.RemoveContex(item);
        }
    }
}