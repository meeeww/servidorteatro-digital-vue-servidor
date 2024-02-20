using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IEmpleadosRepository
    {
        List<EmpleadoDto> GetEmpleados();
        EmpleadoDto GetEmpleadoById(int id);
        void InsertEmpleado(Empleado empleado);
        void UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(int id);
    }
}
