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
    public class ObraController : ControllerBase
    {
        private readonly ObraService _obraService;

        public ObraController(ObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetObras()
        {
            try
            {
                return Ok(_obraService.GetObras());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener las obras.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetObraById(int id)
        {
            try
            {
                var obra = _obraService.GetObraById(id);
                if (obra == null)
                {
                    return NotFound();
                }
                return Ok(obra);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la obra.", error = ex.ToString() });
            }
        }

        [HttpGet("categoria/{categoriaId}")]
        [AllowAnonymous]
        public IActionResult GetObraCategoriaById(int categoriaId)
        {
            try
            {
                return Ok(_obraService.GetObraCategoriaById(categoriaId));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener la obra.", error = ex.ToString() });
            }
        }

        [HttpPost]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult InsertObra([FromBody] ObraInsertDto obraDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var obra = new Obra
                {

                    Titulo = obraDto.Titulo,
                    Descripcion = obraDto.Descripcion,
                    FechaInicio = obraDto.FechaInicio,
                    FechaFin = obraDto.FechaFin,
                    Director = obraDto.Director,
                };

                _obraService.InsertObra(obra);

                return CreatedAtAction(nameof(GetObraById), new { id = obra.ObraID }, obraDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear la obra.", error = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult UpdateObra([FromBody] ObraUpdateDto obraDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var obraExistente = _obraService.GetObraById(obraDto.ObraID);

                if (obraExistente == null)
                    return NotFound("Obra no encontrada.");

                var obra = new Obra
                {
                    Titulo = obraDto.Titulo,
                    Descripcion = obraDto.Descripcion,
                    FechaInicio = obraDto.FechaInicio,
                    FechaFin = obraDto.FechaFin,
                    Director = obraDto.Director,
                };

                _obraService.UpdateObra(obra);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EsAdmin")]
        public IActionResult DeleteObra(int id)
        {
            try
            {
                _obraService.DeleteObra(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
