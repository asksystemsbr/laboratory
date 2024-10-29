using LaboratoryBackEnd.Models;
using System.Threading.Tasks;

namespace LaboratoryBackEnd.Data.Interface
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task<int> CountPlanosByConvenioAsync(int convenioId);
    }
}
