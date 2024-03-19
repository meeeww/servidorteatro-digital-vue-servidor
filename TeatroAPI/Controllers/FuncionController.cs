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
    public class FuncionController : ControllerBase
    {
        private readonly FuncionService _funcionService;

        public FuncionController(FuncionService funcionService)
        {
            _funcionService = funcionService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFunciones()
        {
            try
            {
                return Ok(_funcionService.GetFunciones());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener las funciones.", error = ex.ToString() });
            }
        }

        [HttpGet("{idFuncion}")]
        [AllowAnonymous]
        public IActionResult GetFuncionById(int idFuncion)
        {
            try
            {
                var funcion = _funcionService.GetFuncionById(idFuncion);
                if (funcion == null)
                {
                    return NotFound();
                }
                return Ok(funcion);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la funcion.", error = ex.ToString() });
            }
        }

        [HttpPost]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult InsertFuncion([FromBody] FuncionInsertDto funcionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var funcion = new Funcion
                {
                    ObraID = funcionDto.ObraID,
                    SalaID = funcionDto.SalaID,
                    FechaHora = funcionDto.FechaHora,
                    Precio = funcionDto.Precio,
                };

                _funcionService.InsertFuncion(funcion);

                return CreatedAtAction(nameof(GetFuncionById), new { id = funcion.FuncionID }, funcionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear la funcion.", error = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult UpdateFuncion([FromBody] FuncionUpdateDto funcionDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var funcionExistente = _funcionService.GetFuncionById(funcionDto.FuncionID);

                if (funcionExistente == null)
                    return NotFound("Funcion no encontrada.");

                var funcion = new Funcion
                {
                    ObraID = funcionDto.ObraID,
                    SalaID = funcionDto.SalaID,
                    FechaHora = funcionDto.FechaHora,
                    Precio = funcionDto.Precio,
                };

                _funcionService.UpdateFuncion(funcion);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult DeleteFuncion(int id)
        {
            try
            {
                _funcionService.DeleteFuncion(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
