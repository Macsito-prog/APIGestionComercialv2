using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.Model;


namespace GestionComercial.DAL.Repositorios.Contrato
{
    public interface IOrdenCompraRepository
    {
        Task<OrdenCompra> RegistrarOC(OrdenCompra modelo);

    }
}
