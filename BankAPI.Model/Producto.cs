using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}