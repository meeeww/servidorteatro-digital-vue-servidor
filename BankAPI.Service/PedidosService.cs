using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Services
{

    public class PedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosService(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public List<PedidoDto> GetPedidos()
        {
            return _pedidosRepository.GetPedidos();
        }
        public PedidoDto GetPedidoById(int id)
        {
            return _pedidosRepository.GetPedidoById(id);
        }
        public PedidoDto GetPedidoByDate(DateTime fecha)
        {
            return _pedidosRepository.GetPedidoByDate(fecha);
        }
        public Pedido InsertPedido(Pedido pedido)
        {
            _pedidosRepository.InsertPedido(pedido);
            return pedido;
        }
        public void UpdatePedido(Pedido pedido)
        {
            _pedidosRepository.UpdatePedido(pedido);
        }
        public void DeletePedido(int id)
        {
            _pedidosRepository.DeletePedido(id);
        }

    }
}