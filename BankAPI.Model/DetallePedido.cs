using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class DetallePedido
    {
        [Key]
        public int ID_DetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int ID_Pedido { get; set; }
        public Pedido Pedido { get; set; }
        public int ID_Producto { get; set; }
        public Producto Producto { get; set; }

    }
}
