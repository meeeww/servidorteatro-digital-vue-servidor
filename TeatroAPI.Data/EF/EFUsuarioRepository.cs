using Microsoft.EntityFrameworkCore;
using TeatroAPI.Model;
using TeatroAPI.DTOs;

namespace TeatroAPI.Data
{
    public class EFUsuarioRepository : IUsuarioRepository
    {
        private readonly TeatroAPIContext _context;

        public EFUsuarioRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<UsuarioSimpleDto> GetUsuarios()
        {
            var usuarios = _context.Usuarios
                .ToList();

            var usuariosDto = usuarios.Select(u => new UsuarioSimpleDto
            {
                UserID = u.UserID,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol,

            }).ToList();

            return usuariosDto;
        }

        public UsuarioSimpleDto GetUsuarioById(int id)
        {
            var usuario = _context.Usuarios
                .Where(usuario => usuario.UserID == id)
                .Select(u => new UsuarioSimpleDto
                {
                    UserID = u.UserID,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Rol = u.Rol,
                }).FirstOrDefault();

            return usuario;
        }

        public UsuarioSimpleDto GetUsuarioByEmail(string email)
        {
            var usuario = _context.Usuarios
                .Where(usuario => usuario.Email == email)
                .Select(u => new UsuarioSimpleDto
                {
                    UserID = u.UserID,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Rol = u.Rol,
                }).FirstOrDefault();

            return usuario;
        }

        public UsuarioSimpleDto GetUsuarioByTelefono(string telefono)
        {
            var usuario = _context.Usuarios
                .Where(usuario => usuario.Telefono == telefono)
                .Select(u => new UsuarioSimpleDto
                {
                    UserID = u.UserID,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Rol = u.Rol,
                }).FirstOrDefault();

            return usuario;
        }

        public List<UsuarioSimpleDto> GetUsuarioByRol(int rol)
        {
            var usuario = _context.Usuarios
                .Where(usuario => usuario.Rol == rol)
                .Select(u => new UsuarioSimpleDto
                {
                    UserID = u.UserID,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Rol = u.Rol,
                }).ToList();

            return usuario;
        }

        public void InsertUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.FirstOrDefault(u => u.UserID == usuario.UserID);
            if (existingUsuario != null)
            {
                existingUsuario.Nombre = usuario.Nombre;
                existingUsuario.Apellido = usuario.Apellido;
                existingUsuario.Email = usuario.Email;
                existingUsuario.Telefono = usuario.Telefono;
                existingUsuario.Contra = usuario.Contra;
                existingUsuario.Rol = usuario.Rol;

                _context.SaveChanges();
            }
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}