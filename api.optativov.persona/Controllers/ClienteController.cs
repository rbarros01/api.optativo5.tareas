using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Implementations;
using Repository.Modelos;
using Services;

namespace api.optativov.persona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private IConfiguration configuration;
        private ClienteService clienteService;

        /*public CuentaController()*/
        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteService = new ClienteService(new ClienteRepository(configuration.GetConnectionString("postgresDB")));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(ClienteDTO cliente)
        {
            try
            {
                if (clienteService.add(cliente))
                    return Ok("Cliente agregada correctamente");
                else
                    return BadRequest("Error al agregar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult update(ClienteDTO cliente)
        {
            try
            {
                if (clienteService.update(cliente))
                    return Ok("Cliente actualizada correctamente");
                else
                    return BadRequest("Error al actualizar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(int id)
        {
            try
            {
                if (clienteService.remove(id))
                    return Ok("Cliente eliminada correctamente");
                else
                    return BadRequest("Error al eliminar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult get(int id)
        {
            try
            {
                var cliente = clienteService.get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return BadRequest("Cliente no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            try
            {
                var clientes = clienteService.list();
                if (clientes != null)
                    return Ok(clientes);
                else
                    return BadRequest("No hay clientes registradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
