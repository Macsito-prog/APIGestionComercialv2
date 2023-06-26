using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using GestionComercial.DTO;
using GestionComercial.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace GestionComercial.Utility
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //el mapeo es CreateMap<Origen(modelo), Destino(DTO)>(); Es importante que sí o sí tengan el mismo nombre. Con ReverseMap() también se hace el mapeo
            //hacia el otro lado; RolDTO -> Rol
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();

            #endregion Rol

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();

            #endregion Menu

            #region Usuario
            //Cuando tenemos tipos distintos, se trabaja con ForMember; esto hace que se puedan transformar los tipos de datos desde el origen al destino y viceversa
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol)
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            //Solo se muestra la descripción del ROL
            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol)
                );


            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                );





            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>()
                .ReverseMap();
            #endregion Categoria

            #region ProductoPorProveedor
            CreateMap<ProductoPorProveedor, ProductoPorProveedorDTO>()
                .ForMember(destino =>
                destino.IdProducto, opt => opt.MapFrom(origen => origen.IdProductoNavigation.NombreProducto))
                .ForMember(destino =>
                destino.RutProveedor, opt => opt.MapFrom(origen => origen.RutProveedorNavigation.NombreProveedor));
            CreateMap<ProductoPorProveedorDTO, ProductoPorProveedor>()
                .ReverseMap();
            #endregion


            #region Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                destino.DescripcionCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.NombreCategoria)
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio, new CultureInfo("es-CL")))
                )
                .ForMember(destino =>
                destino.EsActivoProducto,
                opt => opt.MapFrom(origen => origen.EsActivoProducto == true ? 1 : 0)
                );

            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToInt32(origen.Precio, new CultureInfo("es-CL")))
                )
                .ForMember(destino =>
                destino.EsActivoProducto,
                opt => opt.MapFrom(origen => origen.EsActivoProducto == 1 ? true : false)
                );
            #endregion

            #region Venta

            // Mapeo de Venta a VentaDTO
            CreateMap<Venta, VentaDTO>()
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CL")))
                )
                .ForMember(destino =>
                destino.FechaRegistroVenta,
                opt => opt.MapFrom(origen => origen.FechaRegistroVenta.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CL")))
                );
            #endregion Venta







            #region DetalleVenta

            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                destino.DescripcionProducto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.NombreProducto)
                )
                .ForMember(destino =>
                destino.PrecioTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CL")))
                )
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CL")))
                );

            CreateMap<DetalleVentaDTO, DetalleVenta>()
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-CL")))
                )
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-CL")))
                );
            #endregion DetalleVenta




            #region Reporte
            CreateMap<DetalleVenta, ReporteDTO>()
                .ForMember(destino =>
                destino.FechaRegistro,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistroVenta.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                destino.NumeroDocumento,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento))
                .ForMember(destino =>
                destino.TipoPago,
                opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago))
                .ForMember(destino =>
                destino.TotalVenta,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-CL"))))
                .ForMember(destino =>
                destino.Producto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.NombreProducto))
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CL"))))
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CL"))));

            #endregion


            #region Cliente

            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            #endregion


            #region fiado

            CreateMap<Fiado, FiadoDTO>()
                .ForMember(destino => destino.Total, opt => opt.MapFrom(origen => origen.Total.ToString()))
                .ForMember(destino =>
                destino.FechaRegistroVenta,
                opt => opt.MapFrom(origen => origen.FechaRegistroVenta.Value.ToString("dd/MM/yyyy")))
                .ForMember(destino =>
                destino.fechaPago,
                opt => opt.MapFrom(origen => origen.fechaPago.Value.ToString("dd/MM/yyyy")));

            CreateMap<FiadoDTO, Fiado>()
                .ForMember(destino => destino.Total, opt => opt.MapFrom(origen => origen.Total));

            #endregion



            #region OrdenCompra
            CreateMap<OrdenCompra, OrdenCompraDTO>()
                .ForMember(dest => dest.FechaOrdenCompra,
                    opt => opt.MapFrom(src => src.FechaOrdenCompra.HasValue
                        ? src.FechaOrdenCompra.Value.ToString("dd/MM/yyyy")
                        : string.Empty));

            CreateMap<OrdenCompraDTO, OrdenCompra>()
                .ForMember(dest => dest.FechaOrdenCompra,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.FechaOrdenCompra)
                        ? DateTime.ParseExact(src.FechaOrdenCompra, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null));



            #endregion

            #region Proveedor
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();

            #endregion




        }
    }
}
