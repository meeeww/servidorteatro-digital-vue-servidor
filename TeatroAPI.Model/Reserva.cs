using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }
        [Required]
        public int FuncionID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int Asiento {  get; set; }
        [Required]
        public DateTime FechaReserva { get; set; }
        public Funcion? Funcion { get; set; }
        public Usuario? Usuario { get; set; }
    }
}