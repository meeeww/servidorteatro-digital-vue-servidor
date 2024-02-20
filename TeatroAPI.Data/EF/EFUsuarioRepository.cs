using Microsoft.EntityFrameworkCore;
using TeatroAPI.Model;
using TeatroAPI.DTOs;

namespace TeatroAPI.Data
{
    public class EFUsuarioRepository : IUsuarioRepository
    {
        private readonly TeatroAPIContext _context;

        public EFUsuarioRepository(TeatroAPIContext context)
        {
            _context = context;
        }

        public List<UsuarioDto> GetUsuarios()
        {
            var clientes = _context.Clientes
                .Include(cliente => cliente.Pedidos)
                .ToList();

            var clientesDto = clientes.Select(p => new ClienteDto
            {
                ID_Cliente = p.ID_Cliente,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Email = p.Email,
                Telefono = p.Telefono,
                Direccion = p.Direccion,

                Pedidos = p.Pedidos.Select(pi => new PedidoDto
                {
                    ID_Pedido = pi.ID_Pedido,
                    Fecha = pi.Fecha,
                    Total = pi.Total,
                    Enviado = pi.Enviado,
                    MetodoPago = pi.MetodoPago
                }).ToList()
            }).ToList();

            return clientesDto;
        }

        public ClienteDto GetClienteById(int id)
        {
            var cliente = _context.Clientes
                .Where(cliente => cliente.ID_Cliente == id)
                .Include(cliente => cliente.Pedidos)
                .Select(c => new ClienteDto
                {
                    ID_Cliente = c.ID_Cliente,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    Pedidos = c.Pedidos.Select(p => new PedidoDto
                    {
                        ID_Pedido = p.ID_Pedido,
                        Fecha = p.Fecha,
                        Total = p.Total,
                        Enviado = p.Enviado,
                        MetodoPago = p.MetodoPago
                    }).ToList()
                }).FirstOrDefault();

            return cliente;
        }

        public ClienteDto GetClienteByEmail(string email)
        {
            var cliente = _context.Clientes
                .Where(cliente => cliente.Email == email)
                .Include(cliente => cliente.Pedidos)
                .Select(c => new ClienteDto
                {
                    ID_Cliente = c.ID_Cliente,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion,
                    Pedidos = c.Pedidos.Select(p => new PedidoDto
                    {
                        ID_Pedido = p.ID_Pedido,
                        Fecha = p.Fecha,
                        Total = p.Total,
                        Enviado = p.Enviado,
                        MetodoPago = p.MetodoPago
                    }).ToList()
                }).FirstOrDefault();

            return cliente;
        }

        public void InsertCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            var existingCliente = _context.Clientes.FirstOrDefault(c => c.ID_Cliente == cliente.ID_Cliente);
            if (existingCliente != null)
            {
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Apellido = cliente.Apellido;
                existingCliente.Email = cliente.Email;
                existingCliente.Telefono = cliente.Telefono;
                existingCliente.Direccion = cliente.Direccion;

                _context.SaveChanges();
            }
        }

        public void DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}