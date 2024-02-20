using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IRegistroVentasRepository
    {
        List<RegistroVentasDto> GetRegistrosVentas();
        RegistroVentasDto GetRegistroVentasById(int id);
        List<RegistroVentasDto> GetRegistroVentasByIdEmpleado(int id);
        void InsertRegistroVentas(RegistroVentas registroVentas);
        void UpdateRegistroVentas(RegistroVentas registroVentas);
        void DeleteRegistroVentas(int id);
    }
}
