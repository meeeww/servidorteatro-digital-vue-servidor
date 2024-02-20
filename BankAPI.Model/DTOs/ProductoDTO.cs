using BankAPI.Model;

namespace BankAPI.DTOs
{
    public class ProductoDto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public List<DetallePedidosSimpleDto> DetallePedidos { get; set; } = new List<DetallePedidosSimpleDto>();
    }

    public class ProductoSimpleDto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }

    public class ProductoUpdateDto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }
}
