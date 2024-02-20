using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class Empleado
    {
        [Key]
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public ICollection<RegistroVentas> RegistroVentas { get; set; }
    }
}
