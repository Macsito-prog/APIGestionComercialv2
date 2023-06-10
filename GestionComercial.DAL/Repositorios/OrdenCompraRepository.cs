using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using GestionComercial.DAL.DBContext;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.Model;

namespace GestionComercial.DAL.Repositorios
{
    public class OrdenCompraRepository :IGenericRepository<OrdenCompra> , IOrdenCompraRepository
    {
        private readonly GestionComercialContext _dbcontext;

        public OrdenCompraRepository(GestionComercialContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<IQueryable<OrdenCompra>> Consultar(Expression<Func<OrdenCompra, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrdenCompra> Crear(OrdenCompra modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(OrdenCompra modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(OrdenCompra modelo)
        {
            throw new NotImplementedException();
        }


        public Task<OrdenCompra> Obtener(Expression<Func<OrdenCompra, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<OrdenCompra> RegistrarOC(OrdenCompra modelo)
        {
            OrdenCompra ordenCompraGenerada = new OrdenCompra();

            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    OrdenCompra ordenCompra = new OrdenCompra
                    {
                        RutProveedor = modelo.RutProveedor,
                        FechaOrdenCompra = modelo.FechaOrdenCompra,
                        DetalleOrdenCompras = modelo.DetalleOrdenCompras.Select(dto => new DetalleOrdenCompra
                        {
                            IdProducto = dto.IdProducto,
                            Cantidad = dto.Cantidad,
                            Precio = dto.Precio
                        }).ToList(),

                    };

                    await _dbcontext.OrdenCompras.AddAsync(ordenCompra);
                    await _dbcontext.SaveChangesAsync();

                    ordenCompraGenerada = ordenCompra;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
                return ordenCompraGenerada;
            }

        }
    }
}

