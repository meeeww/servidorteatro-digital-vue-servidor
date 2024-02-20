using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioSimpleDto> GetUsuarios()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public UsuarioSimpleDto GetUsuarioById(int id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }

        public UsuarioSimpleDto GetUsuarioByEmail(string email)
        {
            return _usuarioRepository.GetUsuarioByEmail(email);
        }

        public UsuarioSimpleDto GetUsuarioByTelefono(string email)
        {
            return _usuarioRepository.GetUsuarioByTelefono(email);
        }

        public UsuarioSimpleDto GetUsuarioByRol(int rol)
        {
            return _usuarioRepository.GetUsuarioByRol(rol);
        }

        public Usuario InsertUsuario(Usuario usuario)
        {
            _usuarioRepository.InsertUsuario(usuario);

            return usuario;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void DeleteUsuario(int id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }
    }
}

