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
    public class ListaFiadosController : ControllerBase
    {
        private readonly IListaFiadosService _listaFiadosService;

        public ListaFiadosController(IListaFiadosService listaFiadosService)
        {
            _listaFiadosService = listaFiadosService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<FiadoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _listaFiadosService.Lista();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] FiadoDTO fiado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _listaFiadosService.Editar(fiado);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg=ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("CambiarEstado")]
        public async Task<IActionResult> CambiarEstado([FromBody] FiadoDTO fiado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _listaFiadosService.CambiarEstado(fiado);
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
