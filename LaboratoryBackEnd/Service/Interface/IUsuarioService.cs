using LaboratoryBackEnd.Extensions;
using LaboratoryBackEnd.Models;
using LaboratoryBackEnd.ViewModel;
using System.Security.Claims;

namespace LaboratoryBackEnd.Service.Interface
{
    public interface IUsuarioService
    {
        Task<LoginCredentials> Authenticate(LoginCredentials credentials);
        Task<LoginCredentials> AuthenticatePortal(LoginCredentials credentials);

        Task<IEnumerable<Usuario>> GetUsuarioByrGrupo(int grupoId);

        Task<IEnumerable<Usuario>> GetItems();

        Task<Usuario> GetItem(int id);

        Task Put(Usuario item);

        Task<Usuario> Post(Usuario item);

        Task Delete(int id);

        bool Exists(int id);

        Task RemoveContex(Usuario item);

    }
}
