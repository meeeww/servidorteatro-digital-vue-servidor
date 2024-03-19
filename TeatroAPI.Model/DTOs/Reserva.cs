using TeatroAPI.Model;

namespace TeatroAPI.DTOs
{
    public class ReservaDto
    {
        public int ReservaID { get; set; }
        public int FuncionID { get; set; }
        public int UserID { get; set; }
        public int Asiento { get; set; }
        public DateTime FechaReserva { get; set; }
        public Funcion? Funcion { get; set; }
        public Usuario? Usuario { get; set; }
    }

    public class ReservaSimpleDto
    {
        public int ReservaID { get; set; }
        public int FuncionID { get; set; }
        public int UserID { get; set; }
        public int Asiento { get; set; }
        public DateTime FechaReserva { get; set; }
    }

    public class ReservaInsertDto
    {
        public int FuncionID { get; set; }
        public int UserID { get; set; }
        public int Asiento { get; set; }
        public DateTime FechaReserva { get; set; }
    }

    public class ReservaUpdateDto
    {
        public int ReservaID { get; set; }
        public int FuncionID { get; set; }
        public int UserID { get; set; }
        public int Asiento { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
