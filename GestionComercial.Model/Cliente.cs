using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Cliente
{
    public string RutCliente { get; set; } = null!;

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public string? FonoCliente { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
