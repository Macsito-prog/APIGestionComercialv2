using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.Model
{

    public partial class ProductoPorProveedor
    {

        public int IdProductoProveedor { get; set; }
        public string? RutProveedor { get; set; }
        public int? IdProducto { get; set; }

        public virtual Proveedor? RutProveedorNavigation { get; set; }   

        public virtual Producto? IdProductoNavigation { get; set; } 
    }
}
