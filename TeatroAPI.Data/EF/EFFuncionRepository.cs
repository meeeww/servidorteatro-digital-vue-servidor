using TeatroAPI.Model;
using TeatroAPI.DTOs;
using BCrypt.Net;

namespace TeatroAPI.Data
{
    public class EFFuncionRepository : IFuncionRepository
    {
        private readonly TeatroAPIContext _context;

        public EFFuncionRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<FuncionSimpleDto> GetFunciones()
        {
            var funciones = _context.Funciones
                .ToList();

            var funcionesDto = funciones.Select(f => new FuncionSimpleDto
            {
                FuncionID = f.FuncionID,
                ObraID = f.ObraID,
                SalaID = f.SalaID,
                FechaHora = f.FechaHora,
                Precio = f.Precio,
            }).ToList();

            return funcionesDto;
        }

        public FuncionSimpleDto GetFuncionById(int id)
        {
            var funcion = _context.Funciones
                .Where(funcion => funcion.FuncionID == id)
                .Select(f => new FuncionSimpleDto
                {
                    FuncionID = f.FuncionID,
                    ObraID = f.ObraID,
                    SalaID = f.SalaID,
                    FechaHora = f.FechaHora,
                    Precio = f.Precio,
                }).FirstOrDefault();

            return funcion;
        }

        public void InsertFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            SaveChanges();
        }

        public void UpdateFuncion(Funcion funcion)
        {
            var existingFuncion = _context.Funciones.FirstOrDefault(f => f.FuncionID == funcion.FuncionID);
            if (existingFuncion != null)
            {
                existingFuncion.ObraID = funcion.ObraID;
                existingFuncion.SalaID = funcion.SalaID;
                existingFuncion.FechaHora = funcion.FechaHora;
                existingFuncion.Precio = funcion.Precio;

                _context.SaveChanges();
            }
        }

        public void DeleteFuncion(int id)
        {
            var funcion = _context.Funciones.Find(id);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}