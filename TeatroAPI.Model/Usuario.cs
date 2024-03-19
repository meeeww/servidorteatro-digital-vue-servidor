using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Usuario
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Contra { get; set; }
        [Required]
        public int Rol { get; set; }

        public virtual ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}