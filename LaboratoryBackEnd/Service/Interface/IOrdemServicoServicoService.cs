namespace LaboratoryBackEnd.Service.Interface
{
    public interface IOrdemServicoServicoService
    {
        Task<IEnumerable<OrdemServicoServico>> GetItems();
        Task<OrdemServicoServico> GetItem(int id);
        Task Put(OrdemServicoServico item);
        Task<OrdemServicoServico> Post(OrdemServicoServico item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(OrdemServicoServico item);
        Task<int> GetLasdOrOne();
    }
}