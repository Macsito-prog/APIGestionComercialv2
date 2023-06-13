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
    public class ProveedorService : IProveedorService
    {
        private readonly IGenericRepository<Proveedor> _proveedorRepository;
        private readonly IMapper _mapper;

        public ProveedorService(IGenericRepository<Proveedor> proveedorRepository, IMapper mapper)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        public async Task<ProveedorDTO> Crear(ProveedorDTO modelo)
        {
            try
            {
                var proveedorCreado = await _proveedorRepository.Crear(_mapper.Map<Proveedor>(modelo));

                if (proveedorCreado.RutProveedor == "0")
                    throw new TaskCanceledException("No se pudo crear");
                return _mapper.Map<ProveedorDTO>(proveedorCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProveedorDTO modelo)
        {
            try
            {
                var proveedorModelo = _mapper.Map<Proveedor>(modelo);
                var proveedorEncontrado = await _proveedorRepository.Obtener(p => p.RutProveedor == modelo.RutProveedor);

                if (proveedorEncontrado == null)
                    throw new TaskCanceledException("Proveedor no existe");
                proveedorEncontrado.NombreProveedor = proveedorModelo.NombreProveedor;
                proveedorEncontrado.CorreoProveedor = proveedorModelo.CorreoProveedor;
                proveedorEncontrado.TelefonoProveedor = proveedorModelo.TelefonoProveedor;

                bool respuesta = await _proveedorRepository.Editar(proveedorEncontrado);
                if (respuesta == false)
                    throw new TaskCanceledException("No se pudo editar");
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(string rut)
        {
            try
            {
                var proveedorEncontrado = await _proveedorRepository.Obtener(p => p.RutProveedor == rut);
                if (proveedorEncontrado == null)
                    throw new TaskCanceledException("No encontrado el proveedor");
                bool respuesta = await _proveedorRepository.Eliminar(proveedorEncontrado);

                if (!respuesta) throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProveedorDTO>> Lista()
        {
            try
            {
                var listaProveedor = await _proveedorRepository.Consultar();

                return _mapper.Map<List<ProveedorDTO>>(listaProveedor);
            }
            catch { throw; }
        }
    }
}
