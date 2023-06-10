using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    //Permite recibir las credenciales
    public class LoginDTO
    {
        public string Correo { get; set; }
        
        public string Clave { get; set; }       
    }
}
