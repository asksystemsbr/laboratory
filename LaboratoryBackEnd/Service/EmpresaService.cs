using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;

namespace LaboratoryBackEnd.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepository<Empresa> _repository;
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Endereco> _repositoryEndereco;

        public EmpresaService(ILoggerService loggerService,
            IRepository<Empresa> repository,
            IRepository<Endereco> repositoryEndereco)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<IEnumerable<Empresa>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<Empresa> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Empresa item)
        {
            await _repository.Put(item);
            if (item.EnderecoId > 0)
            {
                item.Endereco.ID = item.EnderecoId;
                await _repositoryEndereco.Put(item.Endereco);
            }
        }

        public async Task<Empresa> Post(Empresa item)
        {
            return await _repository.Post(item);
        }

        public async Task Delete(int id, int idEndereco)
        {
            await _repository.Delete(id);
            if (idEndereco > 0)
                await _repositoryEndereco.Delete(idEndereco);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(Empresa item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}