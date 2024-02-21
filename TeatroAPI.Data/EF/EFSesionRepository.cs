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
                    FechaFin = s.FechaFin,
                    IP = s.IP,
                    Dispositivo = s.Dispositivo
                }).FirstOrDefault();

            return sesion;
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
                    FechaFin = s.FechaFin,
                    IP = s.IP,
                    Dispositivo = s.Dispositivo
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