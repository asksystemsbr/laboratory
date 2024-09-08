namespace LaboratoryBackEnd.Service.Interface
{
    public interface IClientService
    {
        Task<IEnumerable<Cliente>> GetItems();
        Task<Cliente> GetItem(int id);
        Task Put(Cliente item);
        Task<Cliente> Post(Cliente item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Cliente item);
        Task<int> GetLasdOrOne();
    }
}
