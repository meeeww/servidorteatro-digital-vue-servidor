using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Funcion
    {
        [Key]
        public int FuncionID { get; set; }
        [Required]
        public int? ObraID { get; set; }
        [Required]
        public int? SalaID { get; set; }
        [Required]
        public DateTime? FechaHora { get; set; }
        [Required]
        public int? Precio { get; set; }
        public Obra? Obra { get; set; }
        public Sala? Sala { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}