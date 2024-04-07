using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Sala
    {
        [Key]
        public int SalaID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int? Capacidad { get; set; }

        public virtual ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    }
}