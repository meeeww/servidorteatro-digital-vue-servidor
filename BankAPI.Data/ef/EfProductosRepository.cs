using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data;

public class EfProductosRepository : IProductosRepository
{
    private readonly BankAPIContext _context;

    public EfProductosRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<ProductoDto> GetProductos()
    {
        var productos = _context.Productos
                .Include(producto => producto.DetallePedidos)
                .ToList();

        var productosDto = productos.Select(p => new ProductoDto
        {
            ID_Producto = p.ID_Producto,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
            Stock = p.Stock,
            Imagen = p.Imagen,

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

        return productosDto;
    }

    public ProductoDto GetProductoById(int id)
    {
        var productos = _context.Productos
                .Where(producto => producto.ID_Producto == id)
                .Include(producto => producto.DetallePedidos)
                .ToList();

        var productosDto = productos.Select(p => new ProductoDto
        {
            ID_Producto = p.ID_Producto,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
            Stock = p.Stock,
            Imagen = p.Imagen,

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

        return productosDto;
    }

    public void InsertProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        SaveChanges();
    }

    public void UpdateProducto(Producto producto)
    {
        _context.Entry(producto).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteProducto(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
