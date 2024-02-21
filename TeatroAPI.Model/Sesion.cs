using System.ComponentModel.DataAnnotations;

namespace TeatroAPI.Model
{
    public class Sesion
    {
        [Key]
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string IP { get; set; }
        public string Dispositivo { get; set; }
    }
}