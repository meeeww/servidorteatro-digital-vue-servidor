using BankAPI.DTOs;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _empleadoService;

        public EmpleadosController(EmpleadosService empleadosService)
        {
            _empleadoService = empleadosService;
        }

        [HttpGet]
        public IActionResult GetEmpleados()
        {
            try
            {
                return Ok(_empleadoService.GetEmpleados());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los empleados.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmpleadoById(int id)
        {
            try
            {
                var empleado = _empleadoService.GetEmpleadoById(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                return Ok(empleado);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el empleado.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertEmpleado([FromBody] EmpleadoSimpleDto empleadoDto)
        {
            try
            {
                if (empleadoDto == null)
                    return BadRequest("El empleado no puede ser nulo.");

                var empleado = new Empleado
                {
                    Nombre = empleadoDto.Nombre,
                    Apellido = empleadoDto.Apellido,
                    Cargo = empleadoDto.Cargo,
                    Salario = empleadoDto.Salario,
                    FechaEntrada = empleadoDto.FechaEntrada,
                    FechaSalida = empleadoDto.FechaSalida
                };

                _empleadoService.InsertEmpleado(empleado);

                return CreatedAtAction(nameof(GetEmpleadoById), new { id = empleado.ID_Empleado }, empleadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el cliente.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateEmpleado([FromBody] EmpleadoUpdateDto empleadoDto)
        {
            try
            {
                if (empleadoDto == null)
                    return BadRequest("El empleado no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var empleado = new Empleado
                {
                    ID_Empleado = empleadoDto.ID_Empleado,
                    Nombre = empleadoDto.Nombre,
                    Apellido = empleadoDto.Apellido,
                    Cargo = empleadoDto.Cargo,
                    Salario = empleadoDto.Salario,
                    FechaEntrada = empleadoDto.FechaEntrada,
                    FechaSalida = empleadoDto.FechaSalida
                };

                _empleadoService.UpdateEmpleado(empleado);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            try
            {
                _empleadoService.DeleteEmpleado(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
