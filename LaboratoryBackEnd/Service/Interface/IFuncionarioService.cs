using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetItems();
        Task<Funcionario> GetItem(int id);
        Task Put(Funcionario item);
        Task<Funcionario> Post(Funcionario item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Funcionario item);
        Task<int> GetLasdOrOne();
    }
}