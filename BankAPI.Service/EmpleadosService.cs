using BankAPI.Data;
using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Services
{
    public class EmpleadosService
    {
        private readonly IEmpleadosRepository _empleadosRepository;

        public EmpleadosService(IEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }

        public List<EmpleadoDto> GetEmpleados()
        {
            return _empleadosRepository.GetEmpleados();
        }

        public EmpleadoDto GetEmpleadoById(int id)
        {
            return _empleadosRepository.GetEmpleadoById(id);
        }

        public Empleado InsertEmpleado(Empleado empleado)
        {
            _empleadosRepository.InsertEmpleado(empleado);

            return empleado;
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            _empleadosRepository.UpdateEmpleado(empleado);
        }
        public void DeleteEmpleado(int id)
        {
            _empleadosRepository.DeleteEmpleado(id);
        }
    }
}

