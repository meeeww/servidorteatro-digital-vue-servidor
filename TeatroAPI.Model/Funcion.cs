using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Funcion
    {
        [Key]
        public int FuncionID { get; set; }
        public int? ObraID { get; set; }
        public int? SalaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Precio { get; set; }
        public Obra? Obra { get; set; }
        public Sala? Sala { get; set; }
    }
}