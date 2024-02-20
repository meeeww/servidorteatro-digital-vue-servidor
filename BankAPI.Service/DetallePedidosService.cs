using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Services
{
    public class DetallePedidosService
    {
        private readonly IDetallePedidosRepository _detallePedidoRepository;

        public DetallePedidosService(IDetallePedidosRepository detallePedidosRepository)
        {
            _detallePedidoRepository = detallePedidosRepository;
        }

        public List<DetallePedidosDto> GetDetallesPedido()
        {
            return _detallePedidoRepository.GetDetallesPedido();
        }

        public DetallePedidosDto GetDetallePedidoById(int id)
        {
            return _detallePedidoRepository.GetDetallePedidoById(id);
        }

        public DetallePedido InsertDetallePedido(DetallePedido detallePedido)
        {
            _detallePedidoRepository.InsertDetallePedido(detallePedido);

            return detallePedido;
        }

        public void UpdateDetallePedido(DetallePedido detallePedido)
        {
            _detallePedidoRepository.UpdateDetallePedido(detallePedido);
        }

        public void DeleteDetallePedido(int id)
        {
            _detallePedidoRepository.DeleteDetallePedido(id);
        }
    }
}