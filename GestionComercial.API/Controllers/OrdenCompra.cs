using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using GestionComercial.API.Utilidad;
using GestionComercial.BLL.Servicios;



namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompra : ControllerBase
    {

        private readonly IOrdenCompraService _ordenCompraService;

        public OrdenCompra(IOrdenCompraService ordenCompraService)
        {
            _ordenCompraService = ordenCompraService;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Guardar([FromBody] OrdenCompraDTO ordenCompra)
        {

            {
                var rsp = new Response<OrdenCompraDTO>();

                try
                {
                    rsp.status = true;
                    rsp.value = await _ordenCompraService.Registrar(ordenCompra);
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
}
