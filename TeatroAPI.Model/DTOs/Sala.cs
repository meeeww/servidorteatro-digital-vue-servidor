namespace TeatroAPI.DTOs
{
    public class SalaDto
    {
        public int SalaID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad { get; set; }
    }

    public class SalaSimpleDto
    {
        public int SalaID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad { get; set; }
    }

    public class SalaInsertDto
    {
        public string? Nombre { get; set; }
        public int? Capacidad { get; set; }
    }

    public class SalaUpdateDto
    {
        public int SalaID { get; set; }
        public string? Nombre { get; set; }
        public int? Capacidad { get; set; }
    }
}
