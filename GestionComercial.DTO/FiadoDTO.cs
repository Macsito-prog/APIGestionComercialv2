using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class FiadoDTO
    {
        public int? IdVenta { get; set; }

        public int? IdUsuario { get; set; }

        public string? RutCliente { get; set; }

        public string? NumeroDocumento { get; set; }

        public string? TipoPago { get; set; }

        public int? Total { get; set; }

        public string? FechaRegistroVenta { get; set; }

        public string? fechaPago { get; set; }

        public bool? pagado { get; set; }
    }
}
