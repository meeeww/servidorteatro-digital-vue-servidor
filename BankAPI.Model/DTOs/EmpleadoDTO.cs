using BankAPI.Model;

namespace BankAPI.DTOs
{
    public class EmpleadoDto
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public List<RegistroVentasDto> RegistroVentas { get; set; } = new List<RegistroVentasDto>();
    }

    public class EmpleadoSimpleDto
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
    }

    public class EmpleadoUpdateDto
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
    }

}
