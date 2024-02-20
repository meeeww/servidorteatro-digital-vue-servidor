using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Model
{
    public class RegistroVentas
    {
        [Key]
        public int ID_RegistroVentas { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public decimal TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }
        public int ID_Empleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
