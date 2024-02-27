using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Obra
    {
        [Key]
        public int ObraID { get; set; }
        public string? Titulo{ get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Director { get; set; }
    }
}