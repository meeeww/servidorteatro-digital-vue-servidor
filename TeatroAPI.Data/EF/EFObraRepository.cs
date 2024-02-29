using TeatroAPI.Model;
using TeatroAPI.DTOs;
using BCrypt.Net;

namespace TeatroAPI.Data
{
    public class EFObraRepository : IObraRepository
    {
        private readonly TeatroAPIContext _context;

        public EFObraRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<ObraSimpleDto> GetObras()
        {
            var obras = _context.Obras
                .ToList();

            var obrasDto = obras.Select(o => new ObraSimpleDto
            {
                ObraID = o.ObraID,
                Titulo = o.Titulo,
                Descripcion = o.Descripcion,
                FechaInicio = o.FechaInicio,
                FechaFin = o.FechaFin,
                Director = o.Director,
            }).ToList();

            return obrasDto;
        }

        public ObraSimpleDto GetObraById(int id)
        {
            var obra = _context.Obras
                .Where(obra => obra.ObraID == id)
                .Select(o => new ObraSimpleDto
                {
                    ObraID = o.ObraID,
                    Titulo = o.Titulo,
                    Descripcion = o.Descripcion,
                    FechaInicio = o.FechaInicio,
                    FechaFin = o.FechaFin,
                    Director = o.Director,
                }).FirstOrDefault();

            return obra;
        }

        public void InsertObra(Obra obra)
        {
            _context.Obras.Add(obra);
            SaveChanges();
        }

        public void UpdateObra(Obra obra)
        {
            var existingObra = _context.Obras.FirstOrDefault(o => o.ObraID == obra.ObraID);
            if (existingObra != null)
            {
                existingObra.Titulo = obra.Titulo;
                existingObra.Descripcion = obra.Descripcion;
                existingObra.FechaInicio = obra.FechaInicio;
                existingObra.FechaFin = obra.FechaFin;
                existingObra.Director = obra.Director;

                _context.SaveChanges();
            }
        }

        public void DeleteObra(int id)
        {
            var obra = _context.Obras.Find(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}