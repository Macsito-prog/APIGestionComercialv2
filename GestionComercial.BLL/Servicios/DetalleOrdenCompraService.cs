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



namespace GestionComercial.BLL.Servicios
{
    public class DetalleOrdenCompraService : IDetalleOrdenCompraService
    {
        private readonly IGenericRepository<DetalleOrdenCompra> _ordenRepositorio;
        private readonly IMapper _mapper;

        public DetalleOrdenCompraService(IGenericRepository<DetalleOrdenCompra> ordenRepositorio, IMapper mapper)
        {
            _ordenRepositorio = ordenRepositorio;
            _mapper = mapper;
        }

        public async Task<DetalleOrdenCompraDTO> Crear(DetalleOrdenCompraDTO modelo)
        {
            try
            {
                var ordenGenerada = await _ordenRepositorio.Crear(_mapper.Map<DetalleOrdenCompra>(modelo));
                if (ordenGenerada.IdDetalleOrden == 0)
                    throw new TaskCanceledException("No se pudo generar");
                return _mapper.Map<DetalleOrdenCompraDTO>(ordenGenerada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DetalleOrdenCompraDTO>> Lista()
        {
            try
            {
                var queryDetalle = await _ordenRepositorio.Consultar();
                var listaOrdenes = queryDetalle
                    .Include(detalle => detalle.IdProductoNavigation)
                    .ToList();

                return _mapper.Map<List<DetalleOrdenCompraDTO>>(listaOrdenes);
            }
            catch
            {
                throw;
            }
        }

    }
}
