using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public List<ReservaSimpleDto> GetReservas()
        {
            return _reservaRepository.GetReservas();
        }

        public ReservaSimpleDto GetReservaById(int id)
        {
            return _reservaRepository.GetReservaById(id);
        }

        public List<ReservaSimpleDto> GetReservasByFuncion(int funcion)
        {
            return _reservaRepository.GetReservasByFuncion(funcion);
        }

        public List<ReservaSimpleDto> GetReservasByCliente(int cliente)
        {
            return _reservaRepository.GetReservasByCliente(cliente);
        }

        public Reserva InsertReserva(Reserva reserva)
        {
            _reservaRepository.InsertReserva(reserva);

            return reserva;
        }

        public void UpdateReserva(Reserva reserva)
        {
            _reservaRepository.InsertReserva(reserva);
        }

        public void DeleteReserva(int id)
        {
            _reservaRepository.DeleteReserva(id);
        }
    }
}

