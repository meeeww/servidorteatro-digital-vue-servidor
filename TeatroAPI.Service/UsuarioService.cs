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

        public List<UsuarioDto> GetUsuario()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public UsuarioDto GetUsuarioById(int id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }

        public UsuarioDto GetUsuarioByEmail(string email)
        {
            return _usuarioRepository.GetUsuarioByEmail(email);
        }

        public UsuarioDto GetUsuarioByTelefono(string email)
        {
            return _usuarioRepository.GetUsuarioByTelefono(email);
        }

        public UsuarioDto GetUsuarioByRol(string email)
        {
            return _usuarioRepository.GetUsuarioByRol(email);
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

