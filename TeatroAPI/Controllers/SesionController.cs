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

        [HttpGet("token/{token}")]
        [AllowAnonymous]
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

        [HttpGet("usuario/{token}")]
        [AllowAnonymous]
        public IActionResult GetUsuarioPorToken(string token)
        {
            try
            {
                var usuario = _sesionService.GetUsuarioPorToken(token);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la sesion.", error = ex.ToString() });
            }
        }

        [HttpGet("id/{idSesion}")]
        [Authorize]
        public IActionResult GetSesionesPorId(int idSesion)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.SerialNumber)?.Value;

            if (userIdClaim == null || idSesion.ToString() != userIdClaim)
            {
                return Forbid();
            }

            try
            {
                var sesion = _sesionService.GetSesionesPorId(idSesion);
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

        [HttpPost("iniciar")]
        [AllowAnonymous]
        public IActionResult IniciarSesion([FromBody] SesionIniciarDto credenciales)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //verify user con throw en service

                var usuario = _usuarioService.GetUsuarioContraByEmail(credenciales.Email);

                if (usuario == null)
                    return NotFound("Usuario no encontrado.");

                if(credenciales.Contra != usuario.Contra)
                    return Unauthorized("Credenciales incorrectas.");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.SerialNumber, usuario.UserID.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString())
                };

                var fechaExpiracion = DateTime.UtcNow.AddHours(2);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = fechaExpiracion,
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
                    FechaFin = fechaExpiracion
                };

                _sesionService.CrearSesion(sesion);

                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el usuario.", error = ex.Message });
            }
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public IActionResult RegistrarSesion([FromBody] UsuarioInsertDto credenciales)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuarioExistente = _usuarioService.GetUsuarioContraByEmail(credenciales.Email);

                if (usuarioExistente != null)
                {
                    return Conflict("El usuario ya existe.");
                }

                var usuarioInsert = new Usuario
                {
                    Nombre = credenciales.Nombre,
                    Apellido = credenciales.Apellido,
                    Email = credenciales.Email,
                    Telefono = credenciales.Telefono,
                    Contra = credenciales.Contra,
                    Rol = credenciales.Rol,
                };

                var nuevoUsuario = _usuarioService.InsertUsuario(usuarioInsert);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.SerialNumber, nuevoUsuario.UserID.ToString()),
                    new Claim(ClaimTypes.Email, nuevoUsuario.Email),
                    new Claim(ClaimTypes.Role, credenciales.Rol.ToString())
                };

                var fechaExpiracion = DateTime.UtcNow.AddHours(2);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = fechaExpiracion,
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var sesion = new Sesion
                {
                    UserID = nuevoUsuario.UserID,
                    Token = tokenString,
                    FechaInicio = DateTime.UtcNow,
                    FechaFin = fechaExpiracion
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
        [Authorize]
        public IActionResult CerrarSesion([FromBody] SesionInsertDto sesionDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.SerialNumber)?.Value;

            if (userIdClaim == null || sesionDto.UserID.ToString() != userIdClaim)
            {
                return Forbid();
            }

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