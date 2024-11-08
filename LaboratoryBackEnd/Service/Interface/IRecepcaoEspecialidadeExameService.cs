using LaboratoryBackEnd.DTOs;
using LaboratoryBackEnd.Models;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IRecepcaoEspecialidadeExameService
    {
        Task<IEnumerable<RecepcaoEspecialidadeExameDto>> GetItemsByRecepcao(int recepcaoId);
        Task AddOrUpdateAsync(int recepcaoId, List<RecepcaoEspecialidadeExame> especialidadesExames);
        Task DeleteAllForReception(int recepcaoId, int especialidadeId);
    }
}
