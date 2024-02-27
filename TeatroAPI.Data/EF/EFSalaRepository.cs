using TeatroAPI.Model;
using TeatroAPI.DTOs;
using BCrypt.Net;

namespace TeatroAPI.Data
{
    public class EFSalaRepository : ISalaRepository
    {
        private readonly TeatroAPIContext _context;

        public EFSalaRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<SalaSimpleDto> GetSalas()
        {
            var salas = _context.Salas
                .ToList();

            var salasDto = salas.Select(s => new SalaSimpleDto
            {
                SalaID = s.SalaID,
                Nombre = s.Nombre,
                Capacidad = s.Capacidad,
            }).ToList();

            return salasDto;
        }

        public SalaSimpleDto GetSalaById(int id)
        {
            var sala = _context.Salas
                .Where(sala => sala.SalaID == id)
                .Select(s => new SalaSimpleDto
                {
                    SalaID = s.SalaID,
                    Nombre = s.Nombre,
                    Capacidad = s.Capacidad,
                }).FirstOrDefault();

            return sala;
        }

        public SalaSimpleDto GetSalaByName(string name)
        {
            var sala = _context.Salas
                .Where(sala => sala.Nombre == name)
                .Select(s => new SalaSimpleDto
                {
                    SalaID = s.SalaID,
                    Nombre = s.Nombre,
                    Capacidad = s.Capacidad,
                }).FirstOrDefault();

            return sala;
        }

        public void InsertSala(Sala sala)
        {
            _context.Salas.Add(sala);
            SaveChanges();
        }

        public void UpdateSala(Sala sala)
        {
            var existingSala = _context.Salas.FirstOrDefault(s => s.SalaID == sala.SalaID);
            if (existingSala != null)
            {
                existingSala.Nombre = sala.Nombre;
                existingSala.Capacidad = sala.Capacidad;

                _context.SaveChanges();
            }
        }

        public void DeleteSala(int id)
        {
            var sala = _context.Salas.Find(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}