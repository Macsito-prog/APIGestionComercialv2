using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public string? RutProveedor { get; set; }

    public DateTime? FechaOrdenCompra { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Proveedor? RutProveedorNavigation { get; set; }
}
