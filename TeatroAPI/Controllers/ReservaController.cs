﻿using TeatroAPI.DTOs;
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

        [HttpGet("{idReserva}")]
        [Authorize]
        public IActionResult GetReservaById(int idReserva)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.SerialNumber)?.Value;
                var userRol = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                var reserva = _reservaService.GetReservaById(idReserva);
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

        [HttpGet("funcion/{idFuncion}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetReservasByFuncion(int idFuncion)
        {
            try
            {
                var reserva = _reservaService.GetReservasByFuncion(idFuncion);
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

        [HttpGet("cliente/{idCliente}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetReservasByCliente(int idCliente)
        {
            try
            {
                var reserva = _reservaService.GetReservasByCliente(idCliente);
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
        public IActionResult InsertReserva([FromBody] ReservaInsertDto reservaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var reservaExistente = _reservaService.GetReservaByFuncionAsiento(reservaDto.FuncionID, reservaDto.Asiento);

                if (reservaExistente != null)
                    return Conflict("La reserva ya existe.");

                var reserva = new Reserva
                {
                    FuncionID = reservaDto.FuncionID,
                    UserID = reservaDto.UserID,
                    Asiento = reservaDto.Asiento
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
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var reservaExistente = _reservaService.GetReservaById(reservaDto.ReservaID);

                if (reservaExistente == null)
                    return NotFound("Reserva no encontrada.");

                var reserva = new Reserva
                {
                    ReservaID = reservaExistente.ReservaID,
                    FuncionID = reservaDto.FuncionID,
                    UserID = reservaDto.UserID,
                    Asiento = reservaDto.Asiento
                };

                _reservaService.UpdateReserva(reserva);

                return Ok(reserva);
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

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
