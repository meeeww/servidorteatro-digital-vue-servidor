using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IDetallePedidosRepository
    {
        List<DetallePedidosDto> GetDetallesPedido();
        DetallePedidosDto GetDetallePedidoById(int id);
        void InsertDetallePedido(DetallePedido detallePedido);
        void UpdateDetallePedido(DetallePedido detallePedido);
        void DeleteDetallePedido(int id);
    }
}
