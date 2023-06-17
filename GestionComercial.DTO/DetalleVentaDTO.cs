using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class DetalleVentaDTO
    {

        public int? IdProducto { get; set; }
        public string? DescripcionProducto { get; set; }

        public int? Cantidad { get; set; }

        public int? PrecioTexto { get; set; }

        public int? TotalTexto { get; set; }

        public int? EsFiado { get; set; }
    }
}
