namespace TeatroAPI.DTOs
{
    public class ObraDto
    {
        public int ObraID { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string Imagen {  get; set; }
    }

    public class ObraSimpleDto
    {
        public int ObraID { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string? Imagen { get; set; }
    }

    public class ObraReservaDto
    {
        public int ObraID { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string? Imagen { get; set; }
        public List<ReservaSimpleDto> Reservas { get; set; }
    }

    public class ObraInsertDto
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string? Imagen { get; set; }
    }

    public class ObraUpdateDto
    {
        public int ObraID { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaID { get; set; }
        public string? Imagen { get; set; }
    }
}
