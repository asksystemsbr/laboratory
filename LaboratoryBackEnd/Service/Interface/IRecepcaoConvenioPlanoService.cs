using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRecepcaoConvenioPlanoService
    {
        Task<IEnumerable<RecepcaoConvenioPlano>> GetItems();
        Task<RecepcaoConvenioPlano> GetItem(int id);
        Task Put(RecepcaoConvenioPlano item);
        Task<RecepcaoConvenioPlano> Post(RecepcaoConvenioPlano item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(RecepcaoConvenioPlano item);
        //Task<int> GetLasdOrOne();
    }
}
