﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class OperationLogService : IOperationLogService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OperationLog> _repository;

        public OperationLogService(ILoggerService loggerService, IRepository<OperationLog> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OperationLog>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OperationLog> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OperationLog item)
        {
            await _repository.Put(item);
        }

        public async Task<OperationLog> Post(OperationLog item)
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

        public async Task RemoveContex(OperationLog item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}