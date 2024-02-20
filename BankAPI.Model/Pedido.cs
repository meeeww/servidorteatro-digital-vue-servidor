using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class Pedido
    {
        [Key]
        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public string MetodoPago { get; set; }
        public int ID_Cliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}