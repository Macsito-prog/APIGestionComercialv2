using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class TransbankDTO
    {

        public string buyOrder { get; set; }
        public string sessionId { get; set; }
        public decimal amount  { get; set; }
        public string returnUrl { get; set; }


    }
}
