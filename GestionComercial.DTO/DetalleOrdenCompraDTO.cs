using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class DetalleOrdenCompraDTO
    {
        public int IdDetalleOrden { get; set; }

        public int? IdOrdenCompra { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public int? Precio { get; set; }
    }
}
