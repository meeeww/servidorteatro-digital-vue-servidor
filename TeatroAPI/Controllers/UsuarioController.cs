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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize(Policy = "EsAdmin")]
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

        [HttpGet("{idUsuario}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult GetUsuarioById(int idUsuario)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioById(idUsuario);
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

        [HttpGet("email/{email}")]
        [Authorize(Policy = "EsAdmin")]
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

        [HttpGet("telefono/{telefono}")]
        [Authorize(Policy = "EsAdmin")]
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

        [HttpGet("rol/{rol}")]
        [Authorize(Policy = "EsAdmin")]
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
        [Authorize(Policy = "EsAdmin")]
        public IActionResult InsertUsuario([FromBody] UsuarioInsertDto usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

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
                    Contra = usuarioDto.Contra,
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
        [Authorize(Policy = "EsAdmin")]
        public IActionResult UpdateUsuario([FromBody] UsuarioUpdateDto usuarioDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuarioExistente = _usuarioService.GetUsuarioByEmail(usuarioDto.Email);

                if (usuarioExistente == null)
                    return NotFound("Usuario no encontrado.");

                var usuario = new Usuario
                {
                    UserID = usuarioExistente.UserID,
                    Nombre = usuarioDto.Nombre,
                    Apellido = usuarioDto.Apellido,
                    Email = usuarioDto.Email,
                    Telefono = usuarioDto.Telefono,
                    Contra = usuarioDto.Contra,
                    Rol = usuarioDto.Rol
                };

                _usuarioService.UpdateUsuario(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                _usuarioService.DeleteUsuario(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
