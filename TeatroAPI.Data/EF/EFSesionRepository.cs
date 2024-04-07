using TeatroAPI.Model;
using TeatroAPI.DTOs;

namespace TeatroAPI.Data
{
    public class EFSesionRepository : ISesionRepository
    {
        private readonly TeatroAPIContext _context;

        public EFSesionRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public SesionDto GetSesionPorToken(string token)
        {
            var sesion = _context.Sesiones
                .Where(s => s.Token == token)
                .Select(s => new SesionDto
                {
                    SessionID = s.SessionID,
                    UserID = s.UserID,
                    Token = s.Token,
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin
                }).FirstOrDefault();

            return sesion;
        }

        public UsuarioSimpleDto GetUsuarioPorToken(string token)
        {
            var sesion = _context.Sesiones
                .Where(s => s.Token == token)
                .Select(s => new SesionDto
                {
                    SessionID = s.SessionID,
                    UserID = s.UserID,
                    Token = s.Token,
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin,
                }).FirstOrDefault();

            if (sesion == null)
            {
                return null;
            }

            var usuario = _context.Usuarios
                .Where(u => u.UserID == sesion.UserID)
                .Select(u => new UsuarioSimpleDto
                {
                    UserID = u.UserID,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Rol = u.Rol
                }).FirstOrDefault();

            return usuario;
        }

        public List<SesionDto> GetSesionesPorId(int id)
        {
            var sesion = _context.Sesiones
                .Where(s => s.UserID == id)
                .Select(s => new SesionDto
                {
                    SessionID = s.SessionID,
                    UserID = s.UserID,
                    Token = s.Token,
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin
                }).ToList();

            return sesion;
        }

        public void CrearSesion(Sesion sesion)
        {
            _context.Sesiones.Add(sesion);
            _context.SaveChanges();
        }

        public void FinalizarSesion(string token)
        {
            var sesion = _context.Sesiones.FirstOrDefault(s => s.Token == token);
            if (sesion != null)
            {
                sesion.FechaFin = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}