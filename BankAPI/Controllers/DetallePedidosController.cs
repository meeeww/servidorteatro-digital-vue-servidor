<<<<<<< HEAD
using BankAPI.Data;
using BankAPI.Model;
using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
=======
>>>>>>> eb9a0e7107d962176a3faf5dfc776f1c6fea4eaa
using BankAPI.Data;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosService : ControllerBase
    {
        private readonly DetallePedidosService _detallePedidosService;

        public DetallePedidosService(DetallePedidosService detallePedidosService)
        {
            _detallePedidosService = detallePedidosService;
        }

        [HttpGet]
        public IActionResult GetDetallesPedidos()
        {
            try
            {
                return Ok(_detallePedidosService.GetDetallesPedido());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los detalles de los pedidos.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDetallePedidoById(int id)
        {
            try
            {
                var detallepedido = _detallePedidosService.GetDetallePedidoById(id);
                if (detallepedido == null)
                {
                    return NotFound();
                }
                return Ok(detallepedido);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el detallepedido.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertDetallePedido([FromBody] DetallePedidosCreateDto detallePedidosCreateDto)
        {
            try
            {
                if (detallePedidosCreateDto == null)
                    return BadRequest("El detalle del pedido no puede ser nulo.");

                var detallepedido = new DetallePedido
                {
                    Cantidad = detallePedidosCreateDto.Cantidad,
                    Subtotal = detallePedidosCreateDto.Subtotal,
                    FechaCreacion = DateTime.Now,
                    ID_Pedido = detallePedidosCreateDto.ID_Pedido,
                    ID_Producto = detallePedidosCreateDto.ID_Producto,
                };

                _detallePedidosService.InsertDetallePedido(detallepedido);

                return CreatedAtAction(nameof(GetDetallePedidoById), new { id = detallepedido.ID_DetallePedido }, detallePedidosCreateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el detalle pedido.", error = ex.Message });
            }
        }


        [HttpPut]
        public IActionResult UpdateDetallePedido([FromBody] DetallePedidosUpdateDto detallePedidoDto)
        {
            try
            {
                if (detallePedidoDto == null)
                    return BadRequest("El detalle pedido no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var detallepedido = new DetallePedido
                {
                    ID_DetallePedido = detallePedidoDto.ID_DetallePedido,
                    Cantidad = detallePedidoDto.Cantidad,
                    Subtotal = detallePedidoDto.Subtotal,
                    ID_Pedido = detallePedidoDto.ID_Pedido,
                    ID_Producto = detallePedidoDto.ID_Producto
                };

                _detallePedidosService.UpdateDetallePedido(detallepedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDetallePedidos(int id)
        {
            try
            {
                _detallePedidosService.DeleteDetallePedidos(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
