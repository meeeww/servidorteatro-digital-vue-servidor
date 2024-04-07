namespace TeatroAPI.DTOs
{
    public class SesionDto
    {
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }

    public class SesionSimpleDto
    {
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }

    public class SesionInsertDto
    {
        public int UserID { get; set; }
        public string? Email { get; set; }
        public string? Contra { get; set; }
        public string Token { get; set; }
        public DateTime FechaInicio { get; set; }
    }

    public class SesionIniciarDto
    {
        public string? Email { get; set; }
        public string? Contra { get; set; }
    }

    public class SesionUpdateDto
    {
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
