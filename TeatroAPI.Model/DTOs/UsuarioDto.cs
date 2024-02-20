namespace TeatroAPI.DTOs
{
    public class UsuarioDto
    {
        public int UserID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Contra { get; set; }
        public int Rol { get; set; }
        // añadir reservas en un futuro
    }

    public class UsuarioSimpleDto
    {
        public int UserID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Contra { get; set; }
        public int Rol { get; set; }
    }

    public class UsuarioUpdateDto
    {
        public string UserID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Contra { get; set; }
        public int Rol { get; set; }
    }

}
