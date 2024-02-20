using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IUsuarioRepository
    {
        List<UsuarioDto> GetUsuarios();
        UsuarioDto GetUsuarioById(int id);
        UsuarioDto GetUsuarioByEmail(string email);
        UsuarioDto GetUsuarioByTelefono(string email);
        UsuarioDto GetUsuarioByRol(string email);
        void InsertUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);
    }
}