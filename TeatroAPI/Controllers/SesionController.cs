using TeatroAPI.DTOs;
using TeatroAPI.Model;
using TeatroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Configuration;

namespace TeatroAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly SesionService _sesionService;
        private readonly UsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public SesionController(SesionService sesionService, UsuarioService usuarioService, IConfiguration configuration)
        {
            _sesionService = sesionService;
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("token/{token}")]
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
        
        [HttpGet("id/{id}")]
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
                //if (!(BCrypt.Net.BCrypt.Verify(credenciales.Contra, usuario.Contra)))
                //{
                //    return Unauthorized("La contraseña es incorrecta.");
                //}

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.SerialNumber, usuario.UserID.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(2),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var sesion = new Sesion
                {
                    UserID = usuario.UserID,
                    Token = tokenString,
                    FechaInicio = DateTime.UtcNow,
                    IP = credenciales.IP,
                    Dispositivo = credenciales.Dispositivo,
                };

                _sesionService.CrearSesion(sesion);

                return Ok(new { token = tokenString });
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