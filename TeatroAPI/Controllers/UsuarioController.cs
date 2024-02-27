using TeatroAPI.DTOs;
using TeatroAPI.Model;
using TeatroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeatroAPI.Utils;

namespace TeatroAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            try
            {
                return Ok(_usuarioService.GetUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los usuarios.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioById(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el usuario.", error = ex.ToString() });
            }
        }

        [HttpGet("email={email}")]
        public IActionResult GetUsuarioByEmail(string email)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioByEmail(email);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el usuario.", error = ex.ToString() });
            }
        }

        [HttpGet("telefono={telefono}")]
        public IActionResult GetUsuarioByTelefono(string telefono)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioByTelefono(telefono);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el usuario.", error = ex.ToString() });
            }
        }

        [HttpGet("rol={rol}")]
        public IActionResult GetUsuarioByRol(int rol)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioByRol(rol);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener el usuario.", error = ex.ToString() });
            }
        }

        [HttpPost]
        public IActionResult InsertUsuario([FromBody] UsuarioInsertDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return BadRequest("El usuario no puede ser nulo.");

                var emailExistente = _usuarioService.GetUsuarioByEmail(usuarioDto.Email);
                var telefonoExistente = _usuarioService.GetUsuarioByTelefono(usuarioDto.Telefono);

                if (emailExistente != null)
                    return Conflict("El correo ya está en uso.");

                if (telefonoExistente != null)
                    return Conflict("El teléfono ya está en uso.");


                var usuario = new Usuario
                {
                    Nombre = usuarioDto.Nombre,
                    Apellido = usuarioDto.Apellido,
                    Email = usuarioDto.Email,
                    Telefono = usuarioDto.Telefono,
                    Contra = Hashing.ToSHA256(usuarioDto.Contra),
                    Rol = usuarioDto.Rol,
                };

                _usuarioService.InsertUsuario(usuario);

                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.UserID }, usuarioDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el usuario.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateUsuario([FromBody] UsuarioUpdateDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return BadRequest("El usuario no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuarioExistente = _usuarioService.GetUsuarioByEmail(usuarioDto.Email);

                if (usuarioExistente == null)
                    return NotFound("Usuario no encontrado.");

                var usuario = new Usuario
                {
                    Nombre = usuarioDto.Nombre,
                    Apellido = usuarioDto.Apellido,
                    Email = usuarioDto.Email,
                    Telefono = usuarioDto.Telefono,
                    Contra = usuarioDto.Contra,
                    Rol = usuarioDto.Rol
                };

                _usuarioService.UpdateUsuario(usuario);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                _usuarioService.DeleteUsuario(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
