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
    public class ListaFiadosService :IListaFiadosService
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
    }
}
