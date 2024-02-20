using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data
{
    public class EfEmpleadosRepository : IEmpleadosRepository
    {
        private readonly BankAPIContext _context;

        public EfEmpleadosRepository(BankAPIContext context)
        {
            _context = context;
        }

        public List<EmpleadoDto> GetEmpleados()
        {
            var empleados = _context.Empleados
                .Include(empleado => empleado.RegistroVentas)
                .ToList();

            var empleadosDto = empleados.Select(e => new EmpleadoDto
            {
                ID_Empleado = e.ID_Empleado,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Cargo = e.Cargo,
                Salario = e.Salario,
                FechaEntrada = e.FechaEntrada,
                FechaSalida = e.FechaSalida,

                RegistroVentas = e.RegistroVentas.Select(em => new RegistroVentasDto
                {
                    ID_RegistroVentas = em.ID_RegistroVentas,
                    Fecha = em.Fecha,
                    TotalVentas = em.TotalVentas,
                    TotalCostos = em.TotalCostos,
                    TotalImpuestos = em.TotalImpuestos,
                    ID_Empleado = em.ID_Empleado,
                }).ToList()
            }).ToList();

            return empleadosDto;
        }

        public EmpleadoDto GetEmpleadoById(int id)
        {
            var empleado = _context.Empleados
                .Where(empleado => empleado.ID_Empleado == id)
                .Include(empleado => empleado.RegistroVentas)
                .Select(e => new EmpleadoDto
                {
                    ID_Empleado = e.ID_Empleado,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Cargo = e.Cargo,
                    Salario = e.Salario,
                    FechaEntrada = e.FechaEntrada,
                    FechaSalida = e.FechaSalida,

                    RegistroVentas = e.RegistroVentas.Select(em => new RegistroVentasDto
                    {
                        ID_RegistroVentas = em.ID_RegistroVentas,
                        Fecha = em.Fecha,
                        TotalVentas = em.TotalVentas,
                        TotalCostos = em.TotalCostos,
                        TotalImpuestos = em.TotalImpuestos,
                        ID_Empleado = em.ID_Empleado,
                    }).ToList()
                }).FirstOrDefault();

            return empleado;
        }

        public void InsertEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            SaveChanges();
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            var existingEmpleado = _context.Empleados.FirstOrDefault(e => e.ID_Empleado == empleado.ID_Empleado);
            if (existingEmpleado != null)
            {
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.Apellido = empleado.Apellido;
                existingEmpleado.Cargo = empleado.Cargo;
                existingEmpleado.Salario = empleado.Salario;
                existingEmpleado.FechaEntrada = empleado.FechaEntrada;
                existingEmpleado.FechaSalida = empleado.FechaSalida;

                _context.SaveChanges();
            }
        }

        public void DeleteEmpleado(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}