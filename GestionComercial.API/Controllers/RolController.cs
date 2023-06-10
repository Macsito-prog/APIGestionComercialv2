using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using GestionComercial.API.Utilidad;


namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        //se crea el servicio a implementar
        //se hace referencia al servicio, siempre.
        

        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RolDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _rolService.Lista();
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
