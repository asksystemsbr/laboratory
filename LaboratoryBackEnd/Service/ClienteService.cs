using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Cliente> _repository;
        private readonly IRepository<StatusCliente> _repositorySituacaoCliente;
        private readonly IRepository<Endereco> _repositoryEndereco;

        public ClienteService(ILoggerService loggerService,
            IRepository<Cliente> repository,
            IRepository<StatusCliente> repositorySituacaoCliente,
            IRepository<Endereco> repositoryEndereco)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositorySituacaoCliente = repositorySituacaoCliente;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<IEnumerable<Cliente>> GetItems()
        {
            var items= await _repository.GetItems();
            return items.OrderBy(x => x.Nome);
        }

        public async Task<Cliente> GetItem(int id)
        {
            var item = await _repository.GetItem(id);
            return item;
        }

        public async Task<Cliente> GetItemByCPF(string cpf)
        {
            string noMaks = cpf.Replace(".", "").Replace("-", "");
            return await _repository.Query()
                .Where(x => x.CpfCnpj != null && (x.CpfCnpj == cpf || x.CpfCnpj== noMaks) )
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetItemByRG(string rg)
        {
            string noMaks = rg.Replace(".", "").Replace("-", "");
            return await _repository.Query()
                .Where(x => x.RG != null && (x.RG == rg || x.RG==noMaks))
                .FirstOrDefaultAsync();
        }
        public async Task Put(Cliente item)
        {
            await _repository.Put(item);
            if (item.EnderecoId.HasValue)
            {
                if (item.EnderecoId.Value > 0)
                {
                    item.Endereco.ID = item.EnderecoId.Value;
                    await _repositoryEndereco.Put(item.Endereco);
                }
            }
        }

        public async Task<Cliente> Post(Cliente item)
        {
            return await _repository.Post(item);
        }

        public async Task Delete(int id,int idEndereco)
        {
            await _repository.Delete(id);
            if(idEndereco>0)
                await _repositoryEndereco.Delete(idEndereco);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }

        public async Task RemoveContex(Cliente item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
       
    }
}
