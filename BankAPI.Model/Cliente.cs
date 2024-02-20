using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class Cliente
    {
        [Key]
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}