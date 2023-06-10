using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class ProveedorDTO
    {
        public string RutProveedor { get; set; } = null!;

        public string? NombreProveedor { get; set; }

        public string? CorreoProveedor { get; set; }

        public string? TelefonoProveedor { get; set; }
    }
}
