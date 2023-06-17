using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DTO;
using GestionComercial.API.Utilidad;
using GestionComercial.BLL.Servicios;
using Microsoft.AspNetCore.Routing.Patterns;
using System.Data.SqlTypes;

namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ProveedorDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _proveedorService.Lista();
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

        public async Task<IActionResult> Guardar([FromBody] ProveedorDTO proveedor)
        {
            var rsp = new Response<ProveedorDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _proveedorService.Crear(proveedor);
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
        public async Task<IActionResult> Editar([FromBody] ProveedorDTO proveedor)
        {


            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _proveedorService.Editar(proveedor);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);

        }

        [HttpDelete]
        [Route("Eliminar/{rut}")]
        public async Task<IActionResult> Eliminar(string rut)
        {


            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _proveedorService.Eliminar(rut);
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
