﻿using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryBackEnd.Service
{
    public class RecepcaoConvenioPlanoService : IRecepcaoConvenioPlanoService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRepository<RecepcaoConvenioPlano> _repository;
        private readonly IPlanoRepository _planoRepository;

        public RecepcaoConvenioPlanoService(ILoggerService loggerService, IRepository<RecepcaoConvenioPlano> repository, IPlanoRepository planoRepository)
        {
            _loggerService = loggerService;
            _repository = repository;
            _planoRepository = planoRepository;
        }

        public async Task<IEnumerable<RecepcaoConvenioPlanoDto>> GetItems()
        {
            return await _repository.Query()
             .Select(x => new RecepcaoConvenioPlanoDto
             {
                 ID = x.ID,
                 RecepcaoId = x.RecepcaoId,
                 ConvenioId = x.ConvenioId,
                 PlanoId = x.PlanoId
                 //NomeRecepcao = x.Recepcao.NomeRecepcao,
                 //DescricaoConvenio = x.Convenio.Descricao,
                 //DescricaoPlano = x.Plano.Descricao
             })
             .ToListAsync();
        }

        public async Task<RecepcaoConvenioPlano> GetItem(int id)
        {
            return await _repository.GetItem(id);
        }

        public async Task<IEnumerable<RecepcaoConvenioPlanoDto>> GetItemsByRecepcao(int recepcaoId)
        {
            var items = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId)
                .ToListAsync();

            var resultado = new List<RecepcaoConvenioPlanoDto>();

            foreach (var item in items)
            {
                if (item.PlanoId == null)
                {
                    var planos = await _planoRepository.Query()
                        .Where(p => p.ConvenioId == item.ConvenioId)
                        .Select(p => new RecepcaoConvenioPlanoDto
                        {
                            ID = item.ID,
                            RecepcaoId = item.RecepcaoId,
                            ConvenioId = item.ConvenioId,
                            PlanoId = p.ID
                        })
                        .ToListAsync();
                    resultado.AddRange(planos);
                }
                else
                {
                    resultado.Add(new RecepcaoConvenioPlanoDto
                    {
                        ID = item.ID,
                        RecepcaoId = item.RecepcaoId,
                        ConvenioId = item.ConvenioId,
                        PlanoId = item.PlanoId
                    });
                }
            }

            return resultado;
        }




        public async Task Put(RecepcaoConvenioPlano item)
        {
            await _repository.Put(item);
        }

        public async Task<RecepcaoConvenioPlano> Post(RecepcaoConvenioPlano item)
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

        public async Task RemoveContex(RecepcaoConvenioPlano item)
        {
            _repository.RemoveContex(item);
        }

        public async Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoConvenioPlano> conveniosPlanos)
        {
            await DeleteAllForReception(recepcaoId);
            foreach (var convenioPlano in conveniosPlanos)
            {
                // Verifica se ConvenioId tem valor antes de chamar DeleteAllForReception
                //if (convenioPlano.ConvenioId.HasValue)
                //{
                //    await DeleteAllForReception(recepcaoId, convenioPlano.ConvenioId.Value);
                //}

                // Verifica se PlanosId está preenchido
                if (convenioPlano.PlanosId != null && convenioPlano.PlanosId.Count > 0)
                {
                    // Cria uma entrada para cada planoId na lista PlanosId
                    foreach (var planoId in convenioPlano.PlanosId)
                    {
                        await Post(new RecepcaoConvenioPlano
                        {
                            RecepcaoId = recepcaoId,
                            ConvenioId = convenioPlano.ConvenioId ?? null, // Usa .Value aqui pois já verificamos que não é nulo
                            PlanoId = planoId
                        });
                    }
                }
                else
                {
                    // Insere o convênio com um único PlanoId ou PlanoId nulo
                    await Post(new RecepcaoConvenioPlano
                    {
                        RecepcaoId = recepcaoId,
                        ConvenioId = convenioPlano.ConvenioId ?? null, // Usa .Value pois ConvenioId não é nulo nesse ponto
                        PlanoId = convenioPlano.PlanoId ?? null
                    });
                }
            }
        }


        public async Task DeleteAllForReception(int recepcaoId, int convenioId)
        {
            var itemsToDelete = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId && x.ConvenioId == convenioId)
                .ToListAsync();

            foreach (var item in itemsToDelete)
            {
                await Delete(item.ID);
            }
        }

        public async Task DeleteAllForReception(int recepcaoId)
        {
            var itemsToDelete = await _repository.Query()
                .Where(x => x.RecepcaoId == recepcaoId)
                .ToListAsync();

            foreach (var item in itemsToDelete)
            {
                await Delete(item.ID);
            }
        }
    }
}