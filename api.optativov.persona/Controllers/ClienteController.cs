using Microsoft.AspNetCore.Mvc;
using Repository.Modelos;
using Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace api.optativov.persona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IConfiguration configuration, ClienteService clienteService) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly ClienteService _clienteService = clienteService;

        [HttpPost]
        [Route("AgregarCliente")]
        public async Task<IActionResult> Add(ClienteDTO cliente)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _clienteService.Add(cliente))
                    return Ok("Cliente agregado correctamente");
                else
                    return BadRequest($"Cliente con CI {cliente.Documento} ya existe");
            }
            catch (Exception)
            {
                return BadRequest("Error al agregar cliente");
            }
        }

        [HttpPut]
        [Route("ActualizarCliente")]
        public async Task<IActionResult> Update(ClienteDTO cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _clienteService.Update(cliente))
                    return Ok("Cliente actualizado correctamente");
                else
                    return BadRequest($"Cliente con id {cliente.Id} no existe o el numero de documento ya esta en uso");
            }
            catch (Exception)
            {
                return BadRequest(("Error al actualizar cliente"));
            }
        }

        [HttpDelete]
        [Route("EliminarCliente/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _clienteService.Remove(id))
                    return Ok("Cliente eliminado correctamente");
                else
                    return BadRequest("Error al eliminar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerCliente/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cliente = await _clienteService.Get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return NotFound("Cliente no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarCliente")]
        public async Task<IActionResult> List()
        {
            try
            {
                var clientes = await _clienteService.List();
                if (clientes != null)
                    return Ok(clientes);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
