using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.DTO;
using GestionComercial.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;


namespace GestionComercial.BLL.Servicios
{
    public class ProductoProveedorService : IProductoProveedorService
    {
        private readonly IGenericRepository<ProductoPorProveedor> _ppRepository;
        private readonly IMapper _mapper;

        public ProductoProveedorService(IGenericRepository<ProductoPorProveedor> ppRepository, IMapper mapper)
        {
            _ppRepository = ppRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoPorProveedorDTO>> Lista()
        {
            try
            {
                var queryPP = await _ppRepository.Consultar();
                var productosPorProveedorDTOs = _mapper.Map<List<ProductoPorProveedorDTO>>(queryPP.ToList());
                return productosPorProveedorDTOs;
            }
            catch { throw; }
        }
    }
}
