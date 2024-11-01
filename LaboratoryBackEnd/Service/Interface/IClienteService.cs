namespace LaboratoryBackEnd.Service.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetItems();
        Task<Cliente> GetItem(int id);
        Task<Cliente> GetItemByCPF(string cpf);
        Task<Cliente> GetItemByRG(string rg);
        Task Put(Cliente item);
        Task<Cliente> Post(Cliente item);
        Task Delete(int id, int idEndereco);
        bool Exists(int id);
        Task RemoveContex(Cliente item);
        Task<int> GetLasdOrOne();
    }
}
