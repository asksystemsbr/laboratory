using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Endereco> _repository;

        public EnderecoService(ILoggerService loggerService, IRepository<Endereco> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Endereco>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Endereco> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Endereco item)
        {
            await _repository.Put(item);
        }

        public async Task<Endereco> Post(Endereco item)
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

        public async Task RemoveContex(Endereco item)
        {
            _repository.RemoveContex(item);
        }
    }
}