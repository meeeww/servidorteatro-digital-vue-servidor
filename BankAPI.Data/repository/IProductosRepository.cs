using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IProductosRepository
    {
        List<ProductoDto> GetProductos();
        ProductoDto GetProductoById(int id);
        void InsertProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
    }
}