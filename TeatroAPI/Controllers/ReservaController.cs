using TeatroAPI.DTOs;
using TeatroAPI.Model;
using TeatroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TeatroAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetReservas()
        {
            try
            {
                return Ok(_reservaService.GetReservas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener las reservas.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetReservaById(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.SerialNumber)?.Value;
                var userRol = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                var reserva = _reservaService.GetReservaById(id);
                if (reserva == null)
                {
                    return NotFound();
                }

                if (reserva.UserID.ToString() != userId || int.Parse(userRol) == 0)
                {
                    return Forbid();
                }

                return Ok(reserva);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la reserva.", error = ex.ToString() });
            }
        }

        [HttpGet("funcion={funcion}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetReservasByFuncion(int funcion)
        {
            try
            {
                var reserva = _reservaService.GetReservasByFuncion(funcion);
                if (reserva == null)
                {
                    return NotFound();
                }
                return Ok(reserva);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la reserva.", error = ex.ToString() });
            }
        }

        [HttpGet("cliente={cliente}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetReservasByCliente(int cliente)
        {
            try
            {
                var reserva = _reservaService.GetReservasByCliente(cliente);
                if (reserva == null)
                {
                    return NotFound();
                }
                return Ok(reserva);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la reserva.", error = ex.ToString() });
            }
        }

        [HttpPost]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult InsertReserva([FromBody] ReservaInsertDto reservaDto)
        {
            try
            {
                if (reservaDto == null)
                    return BadRequest("La reserva no puede ser nula.");


                var reserva = new Reserva
                {
                    FuncionID = reservaDto.FuncionID,
                    UserID = reservaDto.UserID,
                    FechaReserva = reservaDto.FechaReserva,
                };

                _reservaService.InsertReserva(reserva);

                return CreatedAtAction(nameof(GetReservaById), new { id = reserva.ReservaID }, reservaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear la reserva.", error = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult UpdateReserva([FromBody] ReservaUpdateDto reservaDto)
        {
            try
            {
                if (reservaDto == null)
                    return BadRequest("La reserva no puede ser nula.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var reservaExistente = _reservaService.GetReservaById(reservaDto.ReservaID);

                if (reservaExistente == null)
                    return NotFound("Reserva no encontrada.");

                var reserva = new Reserva
                {
                    FuncionID = reservaDto.FuncionID,
                    UserID = reservaDto.UserID,
                    FechaReserva = reservaDto.FechaReserva,
                };

                _reservaService.UpdateReserva(reserva);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult DeleteReserva(int id)
        {
            try
            {
                _reservaService.DeleteReserva(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
