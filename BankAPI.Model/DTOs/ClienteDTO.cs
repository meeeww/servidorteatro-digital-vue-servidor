namespace BankAPI.DTOs
{
    public class ClienteDto
    {
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<PedidoDto> Pedidos { get; set; } = new List<PedidoDto>();
    }

    public class ClienteSimpleDto
    {
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

    public class ClienteUpdateDto
    {
        public int ID_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

}
