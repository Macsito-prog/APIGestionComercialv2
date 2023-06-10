using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using GestionComercial.Model;

namespace GestionComercial.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        
        //Task para trabajar de manera asíncrona
        //esta funcion es para obtener un modelo, cualquiera sea. Por eso se le adiciona el filtro.
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);


        //Para crear y se pasa un modelo de datos
        Task<TModel> Crear(TModel modelo);

        //el nombre lo dice todo
        Task<bool> Editar(TModel modelo);

        //Eliminar un modelo
        Task<bool> Eliminar(TModel modelo);


        //Esto es para listar con un filtro.
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);
    }
}
