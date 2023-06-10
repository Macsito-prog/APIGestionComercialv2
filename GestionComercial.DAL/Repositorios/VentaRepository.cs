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
    public class VentaRepository : IGenericRepository<Venta>, IVentaRepository
    {

        private readonly GestionComercialContext _dbcontext;

        public VentaRepository(GestionComercialContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public Task<IQueryable<Venta>> Consultar(Expression<Func<Venta, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<Venta> Crear(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Venta> Obtener(Expression<Func<Venta, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try 
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        if (dv.Cantidad <1)
                        {
                            transaction.Rollback();
                        }
                        else
                        {
                            _dbcontext.Productos.Update(producto_encontrado);
                        }
                    } 
                    await _dbcontext.SaveChangesAsync();

                    //En el número de documento se da inicio a los número correlativos de las boletas
                    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistroDocumento = DateTime.Now;
                    _dbcontext.NumeroDocumentos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();

                    //formatear el número de documento. 0001
                    int cantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //0001 -> ese es el formato que va a tomar el detalle de venta.

                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidadDigitos, cantidadDigitos);


                    modelo.NumeroDocumento = numeroVenta;
                    await _dbcontext.Venta.AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    //cierra la transacción
                    transaction.Commit();


                }
                catch 
                { 
                    transaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            }
        }
    }
}
