using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class OrdenCompraDTO
    {
        public int IdOrdenCompra { get; set; }

        public string? RutProveedor { get; set; }

        public string? FechaOrdenCompra { get; set; }

        public virtual ICollection<DetalleOrdenCompraDTO> detalleOrdenCompra { get; set; } = new List<DetalleOrdenCompraDTO>(); 
    }
}
