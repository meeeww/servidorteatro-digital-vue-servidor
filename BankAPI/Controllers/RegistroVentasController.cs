using BankAPI.DTOs;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Cursor;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVentasController : ControllerBase
    {
        private readonly RegistroVentasService _registroVentasService;

        public RegistroVentasController(RegistroVentasService registroVentasService)
        {
            _registroVentasService = registroVentasService;
        }

        [HttpGet]
        public IActionResult GetRegistroVentas()
        {
            try
            {
                return Ok(_registroVentasService.GetRegistrosVentas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los registro de ventas.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroVentasById(int id)
        {
            try
            {
                var cliente = _registroVentasService.GetRegistroVentasById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el registro de venta.", error = ex.ToString() });
            }
        }

        [HttpGet("empleado={id}")]
        public IActionResult GetRegistroVentasByIdEmpleado(int id)
        {
            try
            {
                var cliente = _registroVentasService.GetRegistroVentasByIdEmpleado(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el registro de venta.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertRegistroVentas([FromBody] RegistroVentasSimpleDto registroVentaDto)
        {
            try
            {
                if (registroVentaDto == null)
                    return BadRequest("El registro de venta no puede ser nulo.");

                var venta = new RegistroVentas
                {
                    Fecha = registroVentaDto.Fecha,
                    TotalVentas = registroVentaDto.TotalVentas,
                    TotalCostos = registroVentaDto.TotalCostos,
                    TotalImpuestos = registroVentaDto.TotalImpuestos,
                    ID_Empleado = registroVentaDto.ID_Empleado,
                };

                _registroVentasService.InsertRegistroVentas(venta);

                return CreatedAtAction(nameof(GetRegistroVentasById), new { id = venta.ID_RegistroVentas}, registroVentaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el registro de venta.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCliente([FromBody] RegistroVentaUpdateDto registroVentaDto)
        {
            try
            {
                if (registroVentaDto == null)
                    return BadRequest("El registro de venta no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var registro = new RegistroVentas
                {
                    ID_RegistroVentas = registroVentaDto.ID_RegistroVentas,
                    Fecha = registroVentaDto.Fecha,
                    TotalCostos = registroVentaDto.TotalCostos,
                    TotalVentas = registroVentaDto.TotalVentas,
                    TotalImpuestos = registroVentaDto.TotalImpuestos,
                    ID_Empleado = registroVentaDto.ID_Empleado
                };

                _registroVentasService.UpdateRegistroVentas(registro);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegistroVentas(int id)
        {
            try
            {
                _registroVentasService.DeleteRegistroVentas(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
