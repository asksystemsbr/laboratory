using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IEmpresaCategoriaService
    {
        Task<IEnumerable<EmpresaCatagoria>> GetItems();
        Task<EmpresaCatagoria> GetItem(int id);
        Task Put(EmpresaCatagoria item);
        Task<EmpresaCatagoria> Post(EmpresaCatagoria item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(EmpresaCatagoria item);
    }
}