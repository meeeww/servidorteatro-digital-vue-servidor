using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IReservaRepository
    {
        List<ReservaSimpleDto> GetReservas();
        ReservaSimpleDto GetReservaById(int id);
        ReservaSimpleDto GetReservaByFuncionAsiento(int funcion, int asiento);
        List<ReservaSimpleDto> GetReservasByFuncion(int funcion);
        List<ReservaSimpleDto> GetReservasByCliente(int cliente);
        void InsertReserva(Reserva reserva);
        void UpdateReserva(Reserva reserva);
        void DeleteReserva(int id);
    }
}