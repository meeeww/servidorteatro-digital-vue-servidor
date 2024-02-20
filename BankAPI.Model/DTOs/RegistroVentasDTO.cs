using BankAPI.Model;

namespace BankAPI.DTOs
{
    public class RegistroVentasDto
    {
        public int ID_RegistroVentas { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public decimal TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }
        public int ID_Empleado { get; set; }
        public EmpleadoSimpleDto Empleado { get; set; }
    }

    public class RegistroVentasSimpleDto
    {
        public int ID_RegistroVentas { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public decimal TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }
        public int ID_Empleado { get; set; }
    }

    public class RegistroVentaUpdateDto
    {
        public int ID_RegistroVentas { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public decimal TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }
        public int ID_Empleado { get; set; }
    }

}
