using BankAPI.Services;
using BankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;
using BankAPI.DTOs;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosService _pedidosService;

        public PedidosController(PedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet]
        public IActionResult GetPedidos()
        {
            try
            {
                return Ok(_pedidosService.GetPedidos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los pedidos.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            try
            {
                var pedido = _pedidosService.GetPedidoById(id);
                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el pedido.", error = ex.ToString() });
            }
        }

        [HttpGet("fecha={fecha}")]
        public IActionResult GetPedidoByDate(DateTime fecha)
        {
            try
            {
                var pedido = _pedidosService.GetPedidoByDate(fecha);
                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el pedido.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertPedido([FromBody] PedidoSimpleDto pedidoDto)
        {
            try
            {
                if (pedidoDto == null)
                    return BadRequest("El pedido no puede ser nulo.");

                var pedido = new Pedido
                {
                    Fecha = pedidoDto.Fecha,
                    Total = pedidoDto.Total,
                    Enviado = pedidoDto.Enviado,
                    MetodoPago = pedidoDto.MetodoPago,
                    ID_Cliente = pedidoDto.ID_Cliente
    };

                _pedidosService.InsertPedido(pedido);

                return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.ID_Pedido}, pedidoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el pedido.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdatePedido([FromBody] PedidoUpdateDto pedidoDto)
        {
            try
            {
                if (pedidoDto == null)
                    return BadRequest("El pedido no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var pedido = new Pedido
                {
                    ID_Pedido = pedidoDto.ID_Pedido,
                    Fecha = pedidoDto.Fecha,
                    Total = pedidoDto.Total,
                    Enviado = pedidoDto.Enviado,
                    MetodoPago = pedidoDto.MetodoPago,
                    ID_Cliente = pedidoDto.ID_Cliente
                };

                _pedidosService.UpdatePedido(pedido);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            try
            {
                _pedidosService.DeletePedido(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
