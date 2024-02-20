using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data
{

    public class EfPedidosRepository : IPedidosRepository
    {
        private readonly BankAPIContext _context;

        public EfPedidosRepository(BankAPIContext context)
        {
            _context = context;
        }

        public List<PedidoDto> GetPedidos()
        {
            var pedidos = _context.Pedidos
                    .Include(pedido => pedido.DetallePedidos)
                    .ToList();

            var pedidosDto = pedidos.Select(p => new PedidoDto
            {
                ID_Pedido = p.ID_Pedido,
                Fecha = p.Fecha,
                Total = p.Total,
                Enviado = p.Enviado,
                MetodoPago = p.MetodoPago,
                ID_Cliente = p.ID_Cliente,

                DetallePedidos = p.DetallePedidos.Select(dp => new DetallePedidosSimpleDto
                {
                    ID_DetallePedido = dp.ID_DetallePedido,
                    Cantidad = dp.Cantidad,
                    Subtotal = dp.Subtotal,
                    FechaCreacion = dp.FechaCreacion,
                    FechaModificacion = dp.FechaModificacion,
                    ID_Pedido = dp.ID_Pedido,
                    ID_Producto = dp.ID_Producto
                }).ToList()
            }).ToList();

            return pedidosDto;
        }

        public PedidoDto GetPedidoById(int id)
        {
            var pedidos = _context.Pedidos
                    .Where(pedido => pedido.ID_Pedido == id)
                    .Include(pedido => pedido.DetallePedidos)
                    .ToList();

            var pedidosDto = pedidos.Select(p => new PedidoDto
            {
                ID_Pedido = p.ID_Pedido,
                Fecha = p.Fecha,
                Total = p.Total,
                Enviado = p.Enviado,
                MetodoPago = p.MetodoPago,
                ID_Cliente = p.ID_Cliente,

                DetallePedidos = p.DetallePedidos.Select(dp => new DetallePedidosSimpleDto
                {
                    ID_DetallePedido = dp.ID_DetallePedido,
                    Cantidad = dp.Cantidad,
                    Subtotal = dp.Subtotal,
                    FechaCreacion = dp.FechaCreacion,
                    FechaModificacion = dp.FechaModificacion,
                    ID_Pedido = dp.ID_Pedido,
                    ID_Producto = dp.ID_Producto
                }).ToList()
            }).FirstOrDefault();

            return pedidosDto;
        }

        public PedidoDto GetPedidoByDate(DateTime fecha)
        {
            var pedidos = _context.Pedidos
                     .Where(pedido => pedido.Fecha == fecha)
                     .Include(pedido => pedido.DetallePedidos)
                     .ToList();

            var pedidosDto = pedidos.Select(p => new PedidoDto
            {
                ID_Pedido = p.ID_Pedido,
                Fecha = p.Fecha,
                Total = p.Total,
                Enviado = p.Enviado,
                MetodoPago = p.MetodoPago,
                ID_Cliente = p.ID_Cliente,

                DetallePedidos = p.DetallePedidos.Select(dp => new DetallePedidosSimpleDto
                {
                    ID_DetallePedido = dp.ID_DetallePedido,
                    Cantidad = dp.Cantidad,
                    Subtotal = dp.Subtotal,
                    FechaCreacion = dp.FechaCreacion,
                    FechaModificacion = dp.FechaModificacion,
                    ID_Pedido = dp.ID_Pedido,
                    ID_Producto = dp.ID_Producto
                }).ToList()
            }).FirstOrDefault();

            return pedidosDto;
        }

        public void InsertPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            SaveChanges();
        }

        public void UpdatePedido(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeletePedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}