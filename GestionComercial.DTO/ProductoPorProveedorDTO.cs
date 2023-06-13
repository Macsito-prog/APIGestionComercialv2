using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public  class ProductoPorProveedorDTO
    {
        public int IdProductoProveedor { get; set; }
        public string? RutProveedor { get; set; }
        public int? IdProducto { get; set; }
    }
}
