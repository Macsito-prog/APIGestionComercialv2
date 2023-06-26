using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionComercial.Model;

public partial class Fiado
{
    [Key]
    public int? IdVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string? RutCliente { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? TipoPago { get; set; }

    public int? Total { get; set; }

    public DateTime? FechaRegistroVenta { get; set; }

    public DateTime? fechaPago { get; set; }

    public bool? pagado { get; set; }
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Cliente? RutClienteNavigation { get; set; }
}
