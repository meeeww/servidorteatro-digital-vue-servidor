using BankAPI.Model;

namespace BankAPI.DTOs
{
    public class PedidoDto
    {
        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public string MetodoPago { get; set; }
        public int ID_Cliente { get; set; }
        public List<DetallePedidosSimpleDto> DetallePedidos { get; set; } = new List<DetallePedidosSimpleDto>();
    }

    public class PedidoSimpleDto
    {
        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public string MetodoPago { get; set; }
        public int ID_Cliente { get; set; }
    }

    public class PedidoUpdateDto
    {
        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public string MetodoPago { get; set; }
        public int ID_Cliente { get; set; }
    }
}
