using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionComercial.BLL;
using GestionComercial.DTO;
using GestionComercial.BLL.Servicios;
using GestionComercial.BLL.Servicios.Contrato;

namespace GestionComercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransbankController : ControllerBase
    {
        private readonly ITransbankService transbankService;

        public TransbankController(ITransbankService transbankService)
        {
            this.transbankService = transbankService;
        }

        [HttpPost]
        [Route("crearTransaccion")]
        public IActionResult createTransaction([FromBody] TransbankDTO payload)
        {
            var rsp = transbankService.createTransaction(payload);

            return Ok(rsp);
        }


        [HttpGet]
        [Route("confirmarTransaccion/{token}")]

        public IActionResult confirmarTransaccion(string token)
        {
            var rsp = transbankService.confirmar(token);

            return Ok(rsp);
        }
    }
}
