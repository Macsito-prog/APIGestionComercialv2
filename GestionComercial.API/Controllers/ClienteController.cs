using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using GestionComercial.API.Utilidad;
using GestionComercial.BLL.Servicios;
using Microsoft.AspNetCore.Routing.Patterns;

namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.Lista();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }



        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] ClienteDTO cliente)
        {
            var rsp = new Response<ClienteDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.Crear(cliente);
            }
            catch(Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ClienteDTO cliente)
        {


            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.Editar(cliente);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);

        }

        [HttpDelete]
        [Route("Eliminar/rut:string")]
        public async Task<IActionResult> Eliminar(string rut)
        {


            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _clienteService.Eliminar(rut);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);

        }
    }
}
