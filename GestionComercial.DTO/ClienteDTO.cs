using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class ClienteDTO
    {
        public string RutCliente { get; set; } = null!;

        public string? NombreCliente { get; set; }

        public string? ApellidoCliente { get; set; }

        public string? CorreoCliente { get; set; }

        public string? FonoCliente { get; set; }
    }
}
