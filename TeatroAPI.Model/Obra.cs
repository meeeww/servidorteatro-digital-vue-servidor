using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Obra
    {
        [Key]
        public int ObraID { get; set; }
        [Required]
        public string? Titulo{ get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public DateTime? FechaInicio { get; set; }
        [Required]
        public DateTime? FechaFin { get; set; }
        [Required]
        public string? Imagen {  get; set; }
        [Required]
        public string? Director { get; set; }
        public virtual ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    }
}