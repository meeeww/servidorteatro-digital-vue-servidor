using BankAPI.Model;

namespace BankAPI.DTOs
{
    public class DetallePedidosDto
    {
        public int ID_DetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int ID_Pedido { get; set; }
        public PedidoDto Pedido { get; set; }
        public int ID_Producto { get; set; }
        public ProductoDto Producto { get; set; }
    }

    public class DetallePedidosSimpleDto
    {
        public int ID_DetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
    }

    public class DetallePedidosUpdateDto
    {
        public int ID_DetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
    }

    public class DetallePedidosCreateDto
    {
        public int ID_DetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
    }
}
