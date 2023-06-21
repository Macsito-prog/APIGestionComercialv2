using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComercial.DTO
{
    public class TransbankConfirmDTO
    {
        public decimal? monto { get; set; }  
        public string estado { get; set; }  
        public DateTime? fechaTransaccion { get; set; }
    }
}
