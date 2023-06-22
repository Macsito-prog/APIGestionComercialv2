using System;
using System.Collections.Generic;

namespace GestionComercial.Model;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? IdCategoria { get; set; }

    public int? Stock { get; set; }

    public int? Precio { get; set; }

    public bool? EsActivoProducto { get; set; }
    public int precioCompra { get; set; }   

    public DateTime? FechaRegistroProducto { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Proveedor> RutProveedors { get; set; } = new List<Proveedor>();


}
