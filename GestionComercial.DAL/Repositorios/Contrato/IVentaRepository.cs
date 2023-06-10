﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.Model;

namespace GestionComercial.DAL.Repositorios.Contrato
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        //considerar los cambios que hizo el profe
        Task<Venta> Registrar(Venta modelo);

    }
}
