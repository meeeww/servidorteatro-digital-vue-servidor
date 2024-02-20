using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;
using MySqlX.XDevAPI;
using Mysqlx.Cursor;

namespace BankAPI.Data;

public class EfRegistroVentasRepository : IRegistroVentasRepository
{
    private readonly BankAPIContext _context;

    public EfRegistroVentasRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<RegistroVentasDto> GetRegistrosVentas()
    {
        var ventas = _context.RegistroVentas
                .Include(venta => venta.Empleado)
                .ToList();

        var ventasDto = ventas.Select(v => new RegistroVentasDto
        {
            ID_RegistroVentas = v.ID_RegistroVentas,
            Fecha = v.Fecha,
            TotalVentas = v.TotalVentas,
            TotalCostos = v.TotalCostos,
            TotalImpuestos = v.TotalImpuestos,
            ID_Empleado = v.ID_Empleado,

            Empleado = new EmpleadoSimpleDto
            {
                ID_Empleado = v.Empleado.ID_Empleado,
                Nombre = v.Empleado.Nombre,
                Apellido = v.Empleado.Apellido,
                Cargo = v.Empleado.Cargo,
                Salario = v.Empleado.Salario,
                FechaEntrada = v.Empleado.FechaEntrada,
                FechaSalida = v.Empleado.FechaSalida
            }
        }).ToList();

        return ventasDto;
    }

    public RegistroVentasDto GetRegistroVentasById(int id)
    {
        var ventas = _context.RegistroVentas
                .Where(venta => venta.ID_RegistroVentas== id)
                .Include(venta => venta.Empleado)
                .ToList();

        var ventasDto = ventas.Select(v => new RegistroVentasDto
        {
            ID_RegistroVentas = v.ID_RegistroVentas,
            Fecha = v.Fecha,
            TotalVentas = v.TotalVentas,
            TotalCostos = v.TotalCostos,
            TotalImpuestos = v.TotalImpuestos,
            ID_Empleado = v.ID_Empleado,

            Empleado = new EmpleadoSimpleDto
            {
                ID_Empleado = v.Empleado.ID_Empleado,
                Nombre = v.Empleado.Nombre,
                Apellido = v.Empleado.Apellido,
                Cargo = v.Empleado.Cargo,
                Salario = v.Empleado.Salario,
                FechaEntrada = v.Empleado.FechaEntrada,
                FechaSalida = v.Empleado.FechaSalida
            }
        }).FirstOrDefault();

        return ventasDto;
    }

    public List<RegistroVentasDto> GetRegistroVentasByIdEmpleado(int id)
    {
        var ventas = _context.RegistroVentas
                .Where(venta => venta.ID_Empleado == id)
                .Include(venta => venta.Empleado)
                .ToList();

        var ventasDto = ventas.Select(v => new RegistroVentasDto
        {
            ID_RegistroVentas = v.ID_RegistroVentas,
            Fecha = v.Fecha,
            TotalVentas = v.TotalVentas,
            TotalCostos = v.TotalCostos,
            TotalImpuestos = v.TotalImpuestos,
            ID_Empleado = v.ID_Empleado,

            Empleado = new EmpleadoSimpleDto
            {
                ID_Empleado = v.Empleado.ID_Empleado,
                Nombre = v.Empleado.Nombre,
                Apellido = v.Empleado.Apellido,
                Cargo = v.Empleado.Cargo,
                Salario = v.Empleado.Salario,
                FechaEntrada = v.Empleado.FechaEntrada,
                FechaSalida = v.Empleado.FechaSalida
            }
        }).ToList();

        return ventasDto;
    }

    public void InsertRegistroVentas(RegistroVentas registroVenta)
    {
        Console.WriteLine($"Insertando RegistroVentas: ID_RegistroVentas={registroVenta.ID_RegistroVentas}, ID_Empleado={registroVenta.ID_Empleado}, Fecha={registroVenta.Fecha}, TotalVentas={registroVenta.TotalVentas}, TotalCostos={registroVenta.TotalCostos}, TotalImpuestos={registroVenta.TotalImpuestos}");
        _context.RegistroVentas.Add(registroVenta);
        SaveChanges();
    }

    public void UpdateRegistroVentas(RegistroVentas registroVenta)
    {
        var existingVenta = _context.RegistroVentas.FirstOrDefault(v => v.ID_RegistroVentas == registroVenta.ID_RegistroVentas);
        if (existingVenta != null)
        {
            existingVenta.ID_RegistroVentas = registroVenta.ID_RegistroVentas;
            existingVenta.Fecha = registroVenta.Fecha;
            existingVenta.TotalVentas = registroVenta.TotalVentas;
            existingVenta.TotalCostos = registroVenta.TotalCostos;
            existingVenta.TotalImpuestos = registroVenta.TotalImpuestos;
            existingVenta.ID_Empleado = registroVenta.ID_Empleado;

            _context.SaveChanges();
        }
    }

    public void DeleteRegistroVentas(int id)
    {
        var registroVenta = _context.RegistroVentas.Find(id);
        if (registroVenta != null)
        {
            _context.RegistroVentas.Remove(registroVenta);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
