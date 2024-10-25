using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LaboratoryBackEnd.Service
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<OrcamentoCabecalho> _repository;

        public OrcamentoService(ILoggerService loggerService, IRepository<OrcamentoCabecalho> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<OrcamentoCabecalho>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<OrcamentoCabecalho> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(OrcamentoCabecalho item)
        {
            await _repository.Put(item);
        }

        public async Task<OrcamentoCabecalho> Post(OrcamentoCabecalho item)
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

        public async Task RemoveContex(OrcamentoCabecalho item)
        {
            _repository.RemoveContex(item);
        }
    }
}