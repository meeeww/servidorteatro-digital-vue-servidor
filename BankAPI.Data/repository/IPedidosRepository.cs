using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IPedidosRepository
    {
        List<PedidoDto> GetPedidos();
        PedidoDto GetPedidoById(int id);
        PedidoDto GetPedidoByDate(DateTime fecha);
        void InsertPedido(Pedido pedido);
        void UpdatePedido(Pedido pedido);
        void DeletePedido(int id);
    }
}