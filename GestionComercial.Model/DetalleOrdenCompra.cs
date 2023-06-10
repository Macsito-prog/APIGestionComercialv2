using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class DetalleOrdenCompra
{
    public int IdDetalleOrden { get; set; }

    public int? IdOrdenCompra { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public int? Precio { get; set; }

    public virtual OrdenCompra? IdOrdenCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
