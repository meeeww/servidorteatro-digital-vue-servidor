using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }
        public int FuncionID { get; set; }
        public int UserID { get; set; }
        public int Asiento {  get; set; }
        public DateTime FechaReserva { get; set; }
        public Funcion? Funcion { get; set; }
        public Usuario? Usuario { get; set; }
    }
}