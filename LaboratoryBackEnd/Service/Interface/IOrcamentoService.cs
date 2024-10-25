using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrcamentoService
    {
        Task<IEnumerable<OrcamentoCabecalho>> GetItems();
        Task<OrcamentoCabecalho> GetItem(int id);
        Task Put(OrcamentoCabecalho item);
        Task<OrcamentoCabecalho> Post(OrcamentoCabecalho item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrcamentoCabecalho item);
    }
}