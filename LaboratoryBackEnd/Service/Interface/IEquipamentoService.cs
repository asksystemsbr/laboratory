namespace LaboratoryBackEnd.Service.Interface
{
    public interface IEquipamentoService
    {
        Task<IEnumerable<Equipamento>> GetItems();
        Task<Equipamento> GetItem(int id);
        Task Put(Equipamento item);
        Task<Equipamento> Post(Equipamento item);
        Task Delete(int id);
        bool Exists(int id);
        Task RemoveContex(Equipamento item);
        Task<int> GetLasdOrOne();
    }
}