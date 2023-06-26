using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.DTO;


namespace GestionComercial.BLL.Servicios.Contrato
{
    public interface IListaFiadosService
    {
        Task<bool> CambiarEstado(FiadoDTO fiado);
        Task<bool> Editar(FiadoDTO modelo);
        Task<List<FiadoDTO>> Lista();
    }
}
