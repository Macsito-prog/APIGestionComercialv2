using GestionComercial.BLL.Servicios;
using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
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
    public class ProductoProveedorController : ControllerBase
    {
        private readonly  IProductoProveedorService _ppService;

        public ProductoProveedorController(IProductoProveedorService ppService)
        {
            _ppService = ppService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ProductoPorProveedorDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _ppService.Lista();
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
