using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Sala
    {
        [Key]
        public int SalaID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad { get; set; }
    }
}