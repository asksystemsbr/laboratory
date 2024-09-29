using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> GetItems();
        Task<Endereco> GetItem(int id);
        Task Put(Endereco item);
        Task<Endereco> Post(Endereco item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Endereco item);
    }
}