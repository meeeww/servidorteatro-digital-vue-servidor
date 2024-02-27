using TeatroAPI.Model;

namespace TeatroAPI.DTOs
{
    public class FuncionDto
    {
        public int FuncionID { get; set; }
        public int? ObraID { get; set; }
        public int? SalaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Precio { get; set; }
        public Obra? Obra { get; set; }
        public Sala? Sala { get; set; }
    }

    public class FuncionSimpleDto
    {
        public int FuncionID { get; set; }
        public int? ObraID { get; set; }
        public int? SalaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Precio { get; set; }
    }

    public class FuncionInsertDto
    {
        public int? ObraID { get; set; }
        public int? SalaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Precio { get; set; }
    }

    public class FuncionUpdateDto
    {
        public int FuncionID { get; set; }
        public int? ObraID { get; set; }
        public int? SalaID { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Precio { get; set; }
    }
}
