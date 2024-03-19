using TeatroAPI.DTOs;
using TeatroAPI.Model;
using TeatroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TeatroAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _salaService;

        public SalaController(SalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSalas()
        {
            try
            {
                return Ok(_salaService.GetSalas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener las salas.", error = ex.ToString() });
            }
        }

        [HttpGet("{idSala}")]
        [AllowAnonymous]
        public IActionResult GetSalaById(int idSala)
        {
            try
            {
                var sala = _salaService.GetSalaById(idSala);
                if (sala == null)
                {
                    return NotFound();
                }
                return Ok(sala);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la sala.", error = ex.ToString() });
            }
        }

        [HttpGet("name/{name}")]
        [AllowAnonymous]
        public IActionResult GetSalaByName(string name)
        {
            try
            {
                var sala = _salaService.GetSalaByName(name);
                if (sala == null)
                {
                    return NotFound();
                }
                return Ok(sala);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la sala.", error = ex.ToString() });
            }
        }

        [HttpPost]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult InsertSala([FromBody] SalaInsertDto salaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var sala = new Sala
                {
                    Nombre = salaDto.Nombre,
                    Capacidad = salaDto.Capacidad,
                };

                _salaService.InsertSala(sala);

                return CreatedAtAction(nameof(GetSalaById), new { id = sala.SalaID }, salaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear la sala.", error = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult UpdateSala([FromBody] SalaUpdateDto salaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var salaExistente = _salaService.GetSalaByName(salaDto.Nombre);

                if (salaExistente == null)
                    return NotFound("Sala no encontrada.");

                var sala = new Sala
                {
                    Nombre = salaDto.Nombre,
                    Capacidad = salaDto.Capacidad,
                };

                _salaService.UpdateSala(sala);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult DeleteSala(int id)
        {
            try
            {
                _salaService.DeleteSala(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
