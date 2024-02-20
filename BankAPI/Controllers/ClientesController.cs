using BankAPI.DTOs;
using BankAPI.Model;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok(_clientesService.GetClientes());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los clientes.", error = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            try
            {
                var cliente = _clientesService.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al obtener los clientes.", error = ex.ToString() });
            }
        }

        [HttpGet("email={email}")]
        public IActionResult GetClienteByEmail(string email)
        {
            try
            {
                var cliente = _clientesService.GetClienteByEmail(email);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult InsertCliente([FromBody] ClienteSimpleDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return BadRequest("El cliente no puede ser nulo.");

                var cliente = new Cliente
                {
                    Nombre = clienteDto.Nombre,
                    Apellido = clienteDto.Apellido,
                    Email = clienteDto.Email,
                    Telefono = clienteDto.Telefono,
                    Direccion = clienteDto.Direccion,
                };

                _clientesService.InsertCliente(cliente);

                return CreatedAtAction(nameof(GetClienteById), new { id = cliente.ID_Cliente }, clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ocurrió un error al intentar crear el cliente.", error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCliente([FromBody] ClienteUpdateDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return BadRequest("El cliente no puede ser nulo.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cliente = new Cliente
                {
                    ID_Cliente = clienteDto.ID_Cliente,
                    Nombre = clienteDto.Nombre,
                    Apellido = clienteDto.Apellido,
                    Email = clienteDto.Email,
                    Telefono = clienteDto.Telefono,
                    Direccion = clienteDto.Direccion
                };

                _clientesService.UpdateCliente(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                _clientesService.DeleteCliente(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
