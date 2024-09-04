using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IBoletoService
    {
        Task<IEnumerable<Boleto>> GetItems();
        Task<Boleto> GetItem(int id);
        Task Put(Boleto item);
        Task<Boleto> Post(Boleto item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Boleto item);
        Task<int> GetLasdOrOne();
    }
}
