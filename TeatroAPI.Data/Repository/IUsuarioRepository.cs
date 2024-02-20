using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IUsuarioRepository
    {
        List<UsuarioSimpleDto> GetUsuarios();
        UsuarioSimpleDto GetUsuarioById(int id);
        UsuarioSimpleDto GetUsuarioByEmail(string email);
        UsuarioSimpleDto GetUsuarioByTelefono(string telefono);
        UsuarioSimpleDto GetUsuarioByRol(int rol);
        void InsertUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
    }
}