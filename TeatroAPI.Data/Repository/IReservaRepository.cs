using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IReservaRepository
    {
        List<ReservaSimpleDto> GetReservas();
        ReservaSimpleDto GetReservaById(int id);
        List<ReservaSimpleDto> GetReservasByFuncion(int funcion);
        List<ReservaSimpleDto> GetReservasByCliente(int cliente);
        Reserva InsertReserva(Reserva reserva);
        void UpdateReserva(Reserva reserva);
        void DeleteSala(int id);
    }
}