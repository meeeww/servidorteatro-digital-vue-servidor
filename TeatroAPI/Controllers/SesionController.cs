using TeatroAPI.DTOs;
using TeatroAPI.Model;
using TeatroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;

namespace TeatroAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly SesionService _sesionService;
        private readonly UsuarioService _usuarioService;

        public SesionController(SesionService sesionService, UsuarioService usuarioService)
        {
            _sesionService = sesionService;
            _usuarioService = usuarioService;
        }

        [HttpGet("{token}")]
        public IActionResult GetSesionPorToken(string token)
        {
            try
            {
                var sesion = _sesionService.GetSesionPorToken(token);
                if (sesion == null)
                {
                    return NotFound();
                }
                return Ok(sesion);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la sesion.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSesionesPorId(int id)
        {
            try
            {
                var sesion = _sesionService.GetSesionesPorId(id);
                if (sesion == null)
                {
                    return NotFound();
                }
                return Ok(sesion);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la sesion.", error = ex.ToString() });
            }
        }

        [AllowAnonymous]
        [HttpPost("iniciar")]
        public IActionResult IniciarSesion([FromBody] SesionInsertDto credenciales)
        {
            try
            {
                if (credenciales == null)
                    return BadRequest("El usuario no puede ser nulo.");

                //if (contra != null)
                //    return Conflict("La contraseña es incorrecta.");

                //verify user con throw en service

                var usuario = _usuarioService.GetUsuarioContraByEmail(credenciales.Email);

                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                //hashear sha-256
                if (!(BCrypt.Net.BCrypt.Verify(credenciales.Contra, usuario.Contra)))
                {
                    return Unauthorized("La contraseña es incorrecta.");
                }

                //bool isValidPassword = BCrypt.Net.BCrypt.Verify(passwordEnTextoPlano, hashAlmacenado);

                var sesion = new Sesion
                {
                    UserID = credenciales.UserID,
                    Token = credenciales.Token,
                    FechaInicio = credenciales.FechaInicio,
                    IP = credenciales.IP,
                    Dispositivo = credenciales.Dispositivo,
                };

                _sesionService.CrearSesion(sesion);

                return CreatedAtAction(nameof(GetSesionPorToken), new { token = sesion.Token }, credenciales);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el usuario.", error = ex.Message });
            }
        }

        [HttpPost("cerrar")]
        public IActionResult CerrarSesion([FromBody] SesionInsertDto sesionDto)
        {
            try
            {
                _sesionService.FinalizarSesion(sesionDto.Token);
                return Ok(new { message = "Sesión cerrada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al cerrar la sesión.", error = ex.ToString() });
            }
        }
    }
}