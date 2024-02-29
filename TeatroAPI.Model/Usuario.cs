using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Usuario
    {
        [Key]
        public int UserID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Contra { get; set; }
        public int Rol { get; set; }

        public virtual ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}