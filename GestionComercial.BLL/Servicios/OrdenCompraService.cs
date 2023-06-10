using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.DTO;
using GestionComercial.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GestionComercial.BLL.Servicios
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly IGenericRepository<OrdenCompra> _ordenCompraGenerico;


        private readonly IMapper _mapper;
        private readonly IOrdenCompraRepository _ordenCompraRepository;

        public OrdenCompraService(IGenericRepository<DetalleOrdenCompra> detalleOrdenRepositorio, IMapper mapper, IOrdenCompraRepository ordenCompraRepository)
        {
            
            _mapper = mapper;
            _ordenCompraRepository = ordenCompraRepository;
        }


        public async Task<OrdenCompraDTO> Registrar(OrdenCompraDTO modelo)
        {
            try
            {
                var ordenGenerada = await _ordenCompraRepository.RegistrarOC(_mapper.Map<OrdenCompra>(modelo));
                if(ordenGenerada.IdOrdenCompra == 0) 
                    throw new TaskCanceledException("No se pudo generar");
                return _mapper.Map<OrdenCompraDTO>(ordenGenerada);
            }
            catch
            {
                throw;
            }
        }

    }
}
