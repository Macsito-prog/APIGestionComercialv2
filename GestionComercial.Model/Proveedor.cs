using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Proveedor
{
    public string RutProveedor { get; set; } = null!;

    public string? NombreProveedor { get; set; }

    public string? CorreoProveedor { get; set; }

    public string? TelefonoProveedor { get; set; }

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();
}
