using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRecepcaoConvenioPlanoService
    {
        Task<IEnumerable<RecepcaoConvenioPlanoDto>> GetItems();
        Task<RecepcaoConvenioPlano> GetItem(int id);
        Task Put(RecepcaoConvenioPlano item);
        Task<RecepcaoConvenioPlano> Post(RecepcaoConvenioPlano item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(RecepcaoConvenioPlano item);
        Task<IEnumerable<RecepcaoConvenioPlano>> GetItemsByRecepcao(int recepcaoId);
        Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoConvenioPlano> conveniosPlanos);
        //Task<int> GetLasdOrOne();
    }
}
