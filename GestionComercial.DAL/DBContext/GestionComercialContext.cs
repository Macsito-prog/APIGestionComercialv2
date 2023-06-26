using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GestionComercial.Model;


namespace GestionComercial.DAL.DBContext;

public partial class GestionComercialContext : DbContext
{
    public GestionComercialContext()
    {
    }

    public GestionComercialContext(DbContextOptions<GestionComercialContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<ProductoPorProveedor> ProductoPorProveedor { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Fiado> Fiados { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

 


    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA5F1215986");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.EsActivaCategoria)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ES_ACTIVA_CATEGORIA");
            entity.Property(e => e.FechaRegistroCategoria)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_CATEGORIA");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CATEGORIA");
        });

        

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.RutCliente).HasName("PK__CLIENTE__4FE6A3805CF4BAE9");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.RutCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUT_CLIENTE");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_CLIENTE");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO_CLIENTE");
            entity.Property(e => e.FonoCliente)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("FONO_CLIENTE");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CLIENTE");
        });

        modelBuilder.Entity<ProductoPorProveedor>(entity =>
        {
            entity.HasKey(p => p.IdProductoProveedor);
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleOrden).HasName("PK__DETALLE___C1617362308A7B27");

            entity.ToTable("DETALLE_ORDEN_COMPRA");

            entity.Property(e => e.IdDetalleOrden).HasColumnName("ID_DETALLE_ORDEN");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("ID_ORDEN_COMPRA");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .HasConstraintName("FK__DETALLE_O__ID_OR__571DF1D5");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DETALLE_O__ID_PR__5812160E");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DETALLE___49DABA0C8B88FFFF");

            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("ID_DETALLE_VENTA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.EsFiado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ES_FIADO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DETALLE_V__ID_PR__47DBAE45");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DETALLE_V__ID_VE__46E78A0C");
        });

        modelBuilder.Entity<Fiado>(entity =>
        {
            entity
                .ToTable("FIADO");

            entity.Property(e => e.FechaRegistroVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_VENTA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.RutCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUT_CLIENTE");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_PAGO");
            entity.Property(e => e.Total).HasColumnName("TOTAL");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__FIADO__ID_USUARI__4AB81AF0");

            entity.HasOne(d => d.RutClienteNavigation).WithMany()
                .HasForeignKey(d => d.RutCliente)
                .HasConstraintName("FK__FIADO__RUT_CLIEN__4BAC3F29");

            
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__MENU__4728FC60914528FA");

            entity.ToTable("MENU");

            entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ICONO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.UrlMenu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("URL_MENU");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MENU_ROL__138F08B4006B0069");

            entity.ToTable("MENU_ROL");

            entity.Property(e => e.IdMenuRol).HasColumnName("ID_MENU_ROL");
            entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MENU_ROL__ID_MEN__29572725");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MENU_ROL__ID_ROL__2A4B4B5E");
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NUMERO_D__193AEF0E9D41333E");

            entity.ToTable("NUMERO_DOCUMENTO");

            entity.Property(e => e.IdNumeroDocumento).HasColumnName("ID_NUMERO_DOCUMENTO");
            entity.Property(e => e.FechaRegistroDocumento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_DOCUMENTO");
            entity.Property(e => e.UltimoNumero).HasColumnName("ULTIMO_NUMERO");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK__ORDEN_CO__6C6555B8E5B96314");

            entity.ToTable("ORDEN_COMPRA");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("ID_ORDEN_COMPRA");
            entity.Property(e => e.FechaOrdenCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ORDEN_COMPRA");
            entity.Property(e => e.RutProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUT_PROVEEDOR");

            entity.HasOne(d => d.RutProveedorNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.RutProveedor)
                .HasConstraintName("FK__ORDEN_COM__RUT_P__534D60F1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__88BD0357E00B4A51");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.EsActivoProducto)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ES_ACTIVO_PRODUCTO");
            entity.Property(e => e.FechaRegistroProducto)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_PRODUCTO");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__PRODUCTO__ID_CAT__37A5467C");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.RutProveedor).HasName("PK__PROVEEDO__2D7D308F8DF3CA50");

            entity.ToTable("PROVEEDOR");

            entity.Property(e => e.RutProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUT_PROVEEDOR");
            entity.Property(e => e.CorreoProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CORREO_PROVEEDOR");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROVEEDOR");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_PROVEEDOR");

            entity.HasMany(d => d.IdProductos).WithMany(p => p.RutProveedors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoProveedor",
                    r => r.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductosPredeterminados_Producto"),
                    l => l.HasOne<Proveedor>().WithMany()
                        .HasForeignKey("RutProveedor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductosPredeterminados_Proveedor"),
                    j =>
                    {
                        j.HasKey("RutProveedor", "IdProducto").HasName("PK_ProductosPredeterminados");
                        j.ToTable("PRODUCTO_PROVEEDOR");
                        j.IndexerProperty<string>("RutProveedor")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("RUT_PROVEEDOR");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("ID_PRODUCTO");
                    });
        });

 

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__203B0F680BDB756F");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ROL");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B9060979093");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLAVE");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ES_ACTIVO");
            entity.Property(e => e.FechaRegistroUsuario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_USUARIO");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_COMPLETO");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__USUARIO__ID_ROL__2D27B809");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__VENTA__F3B6C1B44191C484");

            entity.ToTable("VENTA", tb => tb.HasTrigger("TR_InsertFiados"));

            entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
            entity.Property(e => e.FechaRegistroVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO_VENTA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.RutCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RUT_CLIENTE");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_PAGO");
            entity.Property(e => e.Total).HasColumnName("TOTAL");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__VENTA__ID_USUARI__4222D4EF");

            entity.HasOne(d => d.RutClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.RutCliente)
                .HasConstraintName("FK__VENTA__RUT_CLIEN__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
