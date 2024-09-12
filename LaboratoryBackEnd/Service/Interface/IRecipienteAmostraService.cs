using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRecipienteAmostraService
    {
        Task<IEnumerable<RecipienteAmostra>> GetItems();
        Task<RecipienteAmostra> GetItem(int id);
        Task Put(RecipienteAmostra item);
        Task<RecipienteAmostra> Post(RecipienteAmostra item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(RecipienteAmostra item);
    }
}