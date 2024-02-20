using BankAPI.DTOs;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _productosService;

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            try
            {
                return Ok(_productosService.GetProductos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los productos.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductoById(int id)
        {
            try
            {
                var cliente = _productosService.GetProductoById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el producto.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertProducto([FromBody] ProductoSimpleDto productoDto)
        {
            try
            {
                if (productoDto == null)
                    return BadRequest("El producto no puede ser nulo.");

                var producto = new Producto
                {
                    Nombre = productoDto.Nombre,
                    Descripcion = productoDto.Descripcion,
                    Precio = productoDto.Precio,
                    Stock = productoDto.Stock,
                    Imagen = productoDto.Imagen,
                };

                _productosService.InsertProducto(producto);

                return CreatedAtAction(nameof(GetProductoById), new { id = producto.ID_Producto }, productoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el producto.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateProducto([FromBody] ProductoUpdateDto productoDto)
        {
            try
            {
                if (productoDto == null)
                    return BadRequest("El producto no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var producto = new Producto
                {
                    ID_Producto = productoDto.ID_Producto,
                    Nombre = productoDto.Nombre,
                    Descripcion = productoDto.Descripcion,
                    Precio = productoDto.Precio,
                    Stock = productoDto.Stock,
                    Imagen = productoDto.Imagen,
                };

                _productosService.UpdateProducto(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            try
            {
                _productosService.DeleteProducto(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
