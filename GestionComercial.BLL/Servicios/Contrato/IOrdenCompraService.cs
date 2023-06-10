﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.DTO;

namespace GestionComercial.BLL.Servicios.Contrato
{
    public interface IOrdenCompraService
    {
        Task<OrdenCompraDTO> Registrar(OrdenCompraDTO modelo);

    }
}
