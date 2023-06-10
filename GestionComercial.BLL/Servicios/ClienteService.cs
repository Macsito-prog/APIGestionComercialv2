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
using Microsoft.Identity.Client.Extensibility;

namespace GestionComercial.BLL.Servicios
{
    public class ClienteService : IClienteService
    {
        //segun el modelo se cambia el <>
        private readonly IGenericRepository<Cliente> _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Crear(ClienteDTO modelo)
        {
            try 
            {
                var clienteCreado = await _clienteRepositorio.Crear(_mapper.Map<Cliente>(modelo));

                if(clienteCreado.RutCliente == "0")
                {
                    throw new TaskCanceledException("Cliente no se pudo crear.");
                }
                var query = await _clienteRepositorio.Consultar(u => u.RutCliente == clienteCreado.RutCliente);
                return _mapper.Map<ClienteDTO>(query);

            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> Editar(ClienteDTO modelo)
        {
            try
            {
                var clienteModelo = _mapper.Map<Cliente>(modelo);
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.RutCliente == modelo.RutCliente);

                if (clienteEncontrado == null)
                {
                    throw new TaskCanceledException("Cliente no existe...");
                }

                clienteEncontrado.NombreCliente = clienteModelo.NombreCliente;
                clienteEncontrado.ApellidoCliente = clienteModelo.ApellidoCliente;
                clienteEncontrado.CorreoCliente = clienteModelo.CorreoCliente;
                clienteEncontrado.FonoCliente = clienteModelo.FonoCliente;

                bool respuesta = await _clienteRepositorio.Editar(clienteEncontrado);
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
                var clienteEncontrado = await _clienteRepositorio.Obtener(u => u.RutCliente == rut);
                if (clienteEncontrado == null)
                    throw new TaskCanceledException("Cliente no encontrado");
                bool respuesta = await _clienteRepositorio.Eliminar(clienteEncontrado);

                if (!respuesta) throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var queryCliente = await _clienteRepositorio.Consultar();

                return _mapper.Map<List<ClienteDTO>>(queryCliente);
            }
            catch { throw; }
        }
    }
}
