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
                Imagen = o.Imagen,
                CategoriaID = o.CategoriaID
            }).ToList();

            return obrasDto;
        }

        public ObraReservaDto GetObraById(int id)
        {
            var reservasList = _context.Reservas
                .Where(reserva => reserva.Funcion!.ObraID == id)
                .Select(r => new ReservaSimpleDto
                {
                    ReservaID = r.ReservaID,
                    FuncionID = r.FuncionID,
                    UserID = r.UserID,
                    Asiento = r.Asiento
                })
                .ToList();

            var obra = _context.Obras
                .Where(obra => obra.ObraID == id)
                .Select(o => new ObraReservaDto
                {
                    ObraID = o.ObraID,
                    Titulo = o.Titulo,
                    Descripcion = o.Descripcion,
                    Imagen = o.Imagen,
                    CategoriaID = o.CategoriaID,
                    Reservas = reservasList
                }).FirstOrDefault();

            return obra;
        }

        public List<ObraSimpleDto> GetObraCategoriaById(int categoriaId)
        {
            var obras = _context.Obras
                .Where(o => o.CategoriaID == categoriaId)
                .ToList();

            var obrasDto = obras.Select(o => new ObraSimpleDto
            {
                ObraID = o.ObraID,
                Titulo = o.Titulo,
                Descripcion = o.Descripcion,
                Imagen = o.Imagen,
                
                CategoriaID = o.CategoriaID
            }).ToList();

            return obrasDto;
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
                existingObra.Imagen = obra.Imagen;
                existingObra.CategoriaID = obra.CategoriaID;

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