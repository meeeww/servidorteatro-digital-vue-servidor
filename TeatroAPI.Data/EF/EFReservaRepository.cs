using TeatroAPI.Model;
using TeatroAPI.DTOs;
using BCrypt.Net;

namespace TeatroAPI.Data
{
    public class EFReservaRepository : IReservaRepository
    {
        private readonly TeatroAPIContext _context;

        public EFReservaRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<ReservaSimpleDto> GetReservas()
        {
            var reservas = _context.Reservas
                .ToList();

            var reservasDto = reservas.Select(r => new ReservaSimpleDto
            {
                ReservaID = r.ReservaID,
                FuncionID = r.FuncionID,
                UserID = r.UserID,
                FechaReserva = r.FechaReserva,
            }).ToList();

            return reservasDto;
        }

        public ReservaSimpleDto GetReservaById(int id)
        {
            var reserva = _context.Reservas
                .Where(reserva => reserva.ReservaID == id)
                .Select(r => new ReservaSimpleDto
                {
                    ReservaID = r.ReservaID,
                    FuncionID = r.FuncionID,
                    UserID = r.UserID,
                    FechaReserva = r.FechaReserva,
                }).FirstOrDefault();

            return reserva;
        }

        public List<ReservaSimpleDto> GetReservasByFuncion(int funcion)
        {
            var reservas = _context.Reservas
                .Where(r => r.FuncionID == funcion)
                .ToList();

            var reservasDto = reservas.Select(r => new ReservaSimpleDto
            {
                ReservaID = r.ReservaID,
                FuncionID = r.FuncionID,
                UserID = r.UserID,
                FechaReserva = r.FechaReserva,
            }).ToList();

            return reservasDto;
        }

        public List<ReservaSimpleDto> GetReservasByCliente(int cliente)
        {
            var reservas = _context.Reservas
                .Where(r => r.UserID == cliente)
                .ToList();

            var reservasDto = reservas.Select(r => new ReservaSimpleDto
            {
                ReservaID = r.ReservaID,
                FuncionID = r.FuncionID,
                UserID = r.UserID,
                FechaReserva = r.FechaReserva,
            }).ToList();

            return reservasDto;
        }

        public void InsertReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            SaveChanges();
        }

        public void UpdateReserva(Reserva reserva)
        {
            var existingReserva = _context.Reservas.FirstOrDefault(r => r.ReservaID == reserva.ReservaID);
            if (existingReserva != null)
            {
                existingReserva.FuncionID = reserva.FuncionID;
                existingReserva.UserID = reserva.UserID;
                existingReserva.FechaReserva = reserva.FechaReserva;

                _context.SaveChanges();
            }
        }

        public void DeleteReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}