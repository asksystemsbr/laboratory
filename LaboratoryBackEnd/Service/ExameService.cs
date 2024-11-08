using AutoMapper;
using LaboratoryBackEnd.Data.DTO;
using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class ExameService : IExameService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<Exame> _repository;
        private readonly IRepository<Plano> _repositoryPlano;
        private readonly IRepository<TabelaPrecoItens> _repositoryTabelaPrecoItens;
        private readonly IRepository<RecepcaoEspecialidadeExame> _repositoryRecepcaoEspecialidadeExame;
        private readonly IMapper _mapper;

        public ExameService(ILoggerService loggerService
            , IRepository<Exame> repository
            , IRepository<Plano> repositoryPlano
            , IRepository<TabelaPrecoItens> repositoryTabelaPrecoItens
            , IRepository<RecepcaoEspecialidadeExame> repositoryRecepcaoEspecialidadeExame
            , IMapper mapper)
        {
            _loggerService = loggerService;
            _repository = repository;
            _repositoryPlano = repositoryPlano;
            _repositoryTabelaPrecoItens = repositoryTabelaPrecoItens;
            _repositoryRecepcaoEspecialidadeExame = repositoryRecepcaoEspecialidadeExame;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Exame>> GetItems()
        {
            var items= await _repository.GetItems();
            return items.OrderBy(x => x.NomeExame);
        }
        public async Task<Exame> GetItemsByCodigo(string codigoExame)
        {
            return await _repository
                .Query()
                .Where(x=>x.CodigoExame.ToLower()==codigoExame.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exame>> GetExameByRecepcao(int recepcaoId)
        {
            var deleteIds = await _repositoryRecepcaoEspecialidadeExame
                .Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.ExameId != null)
                .Select(x => x.ExameId)  // Seleciona apenas os IDs
                .ToListAsync();

            // Filtra os items excluindo os IDs de deleteIds
            var items = await _repository.Query()
                .Where(x => !deleteIds.Contains(x.ID))  // Exclui os itens com IDs em deleteIds
                .OrderBy(x => x.NomeExame)
                .ToListAsync();

            return items;
        }
        
        public async Task<ExameDTO> GetPrecoByPlanoExame(string codigoExame,string codigoPlano)
        {
            ExameDTO exameDTO = null;
            // 1. Obter o Exame pelo código
            var exame = await _repository
                .Query()
                .Where(x => x.CodigoExame.ToLower() == codigoExame.ToLower())
                .FirstOrDefaultAsync();

            if (exame == null)
            {
                return null;
            }

            // 2. Obter o Plano pelo código
            var plano = await _repositoryPlano.Query()
                .Where(p => p.ID == Convert.ToInt32(codigoPlano))
                .FirstOrDefaultAsync();

            if (plano == null)
            {
                return null;
            }

            // 3. Consultar TabelaPrecoItens com ExameId e TabelaPrecoId correspondentes
            var precoItem = await _repositoryTabelaPrecoItens.Query()
                .Where(tpi => tpi.ExameId == exame.ID && tpi.TabelaPrecoId == plano.TabelaPrecoId)
                .FirstOrDefaultAsync();

            exameDTO = _mapper.Map<ExameDTO>(exame);

            if (precoItem == null)
                exameDTO.Preco = 0;
            else
                exameDTO.Preco = precoItem.Valor;

            return exameDTO;
        }

        public async Task<Exame> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task Put(Exame item)
        {
            await _repository.Put(item);
        }

        public async Task<Exame> Post(Exame item)
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

        public async Task RemoveContex(Exame item)
        {
            _repository.RemoveContex(item);
        }

        public async Task<int> GetLasdOrOne()
        {
            return _repository.GetLasdOrOne();
        }
    }
}
