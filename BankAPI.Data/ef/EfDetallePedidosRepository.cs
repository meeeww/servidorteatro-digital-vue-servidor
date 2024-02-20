using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data
{
    public class EfDetallePedidosRepository : IDetallePedidosRepository
    {
        private readonly BankAPIContext _context;

        public EfDetallePedidosRepository(BankAPIContext context)
        {
            _context = context;
        }

        public List<DetallePedidosDto> GetDetallesPedido()
        {
            var detallePedidoDto = _context.DetallePedidos
            .Include(dp => dp.Pedido)
            .Include(dp => dp.Producto)
            .Select(dp => new DetallePedidosDto
            {
                ID_DetallePedido = dp.ID_DetallePedido,
                Cantidad = dp.Cantidad,
                Subtotal = dp.Subtotal,
                FechaCreacion = dp.FechaCreacion,
                FechaModificacion = dp.FechaModificacion,
                ID_Pedido = dp.ID_Pedido,
                Pedido = new PedidoDto
                {
                    ID_Pedido = dp.Pedido.ID_Pedido,
                    Fecha = dp.Pedido.Fecha,
                    Total = dp.Pedido.Total,
                    Enviado = dp.Pedido.Enviado,
                    MetodoPago = dp.Pedido.MetodoPago,
                },
                ID_Producto = dp.ID_Producto,
                Producto = new ProductoDto
                {
                    ID_Producto = dp.Producto.ID_Producto,
                    Nombre = dp.Producto.Nombre,
                    Descripcion = dp.Producto.Descripcion,
                    Precio = dp.Producto.Precio,
                    Stock = dp.Producto.Stock,
                    Imagen = dp.Producto.Imagen,
                }
            }).ToList();

            return detallePedidoDto;
        }

        public DetallePedidosDto GetDetallePedidoById(int id)
        {
            var detallePedidoDto = _context.DetallePedidos
            .Where(dp => dp.ID_DetallePedido == id)
            .Include(dp => dp.Pedido)
            .Include(dp => dp.Producto)
            .Select(dp => new DetallePedidosDto
            {
                ID_DetallePedido = dp.ID_DetallePedido,
                Cantidad = dp.Cantidad,
                Subtotal = dp.Subtotal,
                FechaCreacion = dp.FechaCreacion,
                FechaModificacion = dp.FechaModificacion,
                ID_Pedido = dp.ID_Pedido,
                Pedido = new PedidoDto
                {
                    ID_Pedido = dp.Pedido.ID_Pedido,
                    Fecha = dp.Pedido.Fecha,
                    Total = dp.Pedido.Total,
                    Enviado = dp.Pedido.Enviado,
                    MetodoPago = dp.Pedido.MetodoPago,
                },
                ID_Producto = dp.ID_Producto,
                Producto = new ProductoDto
                {
                    ID_Producto = dp.Producto.ID_Producto,
                    Nombre = dp.Producto.Nombre,
                    Descripcion = dp.Producto.Descripcion,
                    Precio = dp.Producto.Precio,
                    Stock = dp.Producto.Stock,
                    Imagen = dp.Producto.Imagen,
                }
            }).FirstOrDefault();

            return detallePedidoDto;
        }


        public void InsertDetallePedido(DetallePedido detallePedido)
        {
            _context.DetallePedidos.Add(detallePedido);
            SaveChanges();
        }

        public void UpdateDetallePedido(DetallePedido detallePedido)
        {
            var existingDetallePedido = _context.DetallePedidos.FirstOrDefault(dp => dp.ID_DetallePedido == detallePedido.ID_DetallePedido);
            if (existingDetallePedido != null)
            {
                existingDetallePedido.Cantidad = detallePedido.Cantidad;
                existingDetallePedido.Subtotal = detallePedido.Subtotal;
                existingDetallePedido.FechaModificacion = DateTime.Now;
                existingDetallePedido.ID_Pedido = detallePedido.ID_Pedido;
                existingDetallePedido.ID_Producto = detallePedido.ID_Producto;

                _context.SaveChanges();
            }
        }

        public void DeleteDetallePedido(int id)
        {
            var detalle = _context.DetallePedidos.Find(id);
            if (detalle != null)
            {
                _context.DetallePedidos.Remove(detalle);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}