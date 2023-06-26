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


namespace GestionComercial.BLL.Servicios
{
    public class ListaFiadosService : IListaFiadosService
    {
        private readonly IGenericRepository<Fiado> _fiadosRepository;
        private readonly IMapper _mapper;

        public ListaFiadosService(IGenericRepository<Fiado> fiadosRepository, IMapper mapper)
        {
            _fiadosRepository = fiadosRepository;
            _mapper = mapper;
        }

        public async Task<List<FiadoDTO>> Lista()
        {
            try
            {
                var listaFiados = await _fiadosRepository.Consultar();
                return _mapper.Map<List<FiadoDTO>>(listaFiados.ToList());
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Editar(FiadoDTO modelo)
        {
            try
            {
                var fiadoModelo = _mapper.Map<Fiado>(modelo);
                var fiadoEncontrado = await _fiadosRepository.Obtener(f => f.IdVenta == modelo.IdVenta);

                if (fiadoEncontrado == null)
                {
                    throw new TaskCanceledException("Fiado no existe...");
                }
                else
                {
                    fiadoEncontrado.pagado = true;

                    bool respuesta = await _fiadosRepository.Editar(fiadoEncontrado);
                    if (respuesta == false)
                    {
                        throw new TaskCanceledException("No se pudo editar el fiado...");
                    }

                    return respuesta;
                }


            }
            catch
            {
                throw;
            }
        }
    }
}
