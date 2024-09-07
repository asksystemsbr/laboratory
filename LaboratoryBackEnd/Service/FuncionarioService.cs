using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Funcionario> _repository;

        public FuncionarioService(ILoggerService loggerService, IRepository<Funcionario> repository)
        {
            _loggerService = loggerService;
            _repository = repository;
        }

        public async Task<IEnumerable<Funcionario>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Funcionario> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Funcionario item)
        {
            await _repository.Put(item);
        }

        public async Task<Funcionario> Post(Funcionario item)
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

        public async Task RemoveContex(Funcionario item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}