using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionComercial.DTO;
using System.Threading.Tasks;

namespace GestionComercial.BLL.Servicios.Contrato
{
    public interface IDetalleOrdenCompraService
    {
        Task<List<DetalleOrdenCompraDTO>> Lista();
        Task<DetalleOrdenCompraDTO> Crear(DetalleOrdenCompraDTO modelo);

       
    }
}
