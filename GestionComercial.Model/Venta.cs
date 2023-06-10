using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string? RutCliente { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? TipoPago { get; set; }

    public int? Total { get; set; }

    public DateTime? FechaRegistroVenta { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Cliente? RutClienteNavigation { get; set; }
}
