using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class LaboratorioApoioService : ILaboratorioApoioService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<LaboratorioApoio> _repository;
        private readonly IRepository<Endereco> _repositoryEndereco;

        public LaboratorioApoioService(ILoggerService loggerService
            , IRepository<LaboratorioApoio> repository
            , IRepository<Endereco> repositoryEndereco)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryEndereco = repositoryEndereco;
        }

        public async Task<IEnumerable<LaboratorioApoio>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task<LaboratorioApoio> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(LaboratorioApoio item)
        {
            await _repository.Put(item);
            if (item.EnderecoId > 0)
            {
                item.Endereco.ID = item.EnderecoId;
                await _repositoryEndereco.Put(item.Endereco);
            }
        }

        public async Task<LaboratorioApoio> Post(LaboratorioApoio item)
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

        public async Task RemoveContex(LaboratorioApoio item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<LaboratorioApoio> GetItemByCNPJ(string cnpj)
        {
            // Remover todos os caracteres não numéricos do CNPJ recebido
            string onlyNumbersCnpj = string.Concat(cnpj.Where(char.IsDigit));

            // Buscar todos os registros que tenham um CNPJ, e filtrar na aplicação
            var items = await _repository.Query()
                .Where(x => x.CpfCnpj != null) // Trazer registros que tenham um CNPJ
                .ToListAsync();

            // Filtrar o CNPJ manualmente no código (já que LINQ não suporta manipulação de strings como IsDigit)
            return items.FirstOrDefault(x => string.Concat(x.CpfCnpj.Where(char.IsDigit)) == onlyNumbersCnpj);
        }
    }
}