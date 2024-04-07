using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Sesion
    {
        [Key]
        public int SessionID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime? FechaFin { get; set; }
        public Usuario Usuario { get; set; }
    }
}