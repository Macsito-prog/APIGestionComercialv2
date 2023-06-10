using GestionComercial.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionComercial.DAL.Repositorios.Contrato;
using GestionComercial.DAL.Repositorios;

using GestionComercial.Utility;
using GestionComercial.BLL.Servicios.Contrato;
using GestionComercial.BLL.Servicios;

namespace GestionComercial.IOC
{
    public static class Dependencia
    {
        //dentro del servicio se inyectará esta función
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration )
        {
            //recibe las colecciones 
            services.AddDbContext<GestionComercialContext>(options =>
            {
                //se le asigna la conexión al contexto de la base de datos.
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            //este es para cualquier modelo
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            //Este es solo para venta 
            services.AddScoped<IVentaRepository, VentaRepository>();
            //dependencias de automapper con todos los mapeos
            services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            //dependencias de las interfaces y los servicios    FALTA AGREGAR LOS DE LAS OTRAS TABLAS
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService,UsuarioService>();
            services.AddScoped<ICategoriaService,CategoriaService >();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IVentaService, VentaService>();
            services.AddScoped<IDashboardService, DashboardService >();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IDetalleOrdenCompraService, DetalleOrdenCompraService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IOrdenCompraService, OrdenCompraService>();

        }
    }
}
