using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionComercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_CATEGORIA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ES_ACTIVA_CATEGORIA = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHA_REGISTRO_CATEGORIA = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORI__4BD51FA5F1215986", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    RUT_CLIENTE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NOMBRE_CLIENTE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    APELLIDO_CLIENTE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CORREO_CLIENTE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FONO_CLIENTE = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__4FE6A3805CF4BAE9", x => x.RUT_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    ID_MENU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ICONO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    URL_MENU = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MENU__4728FC60914528FA", x => x.ID_MENU);
                });

            migrationBuilder.CreateTable(
                name: "NUMERO_DOCUMENTO",
                columns: table => new
                {
                    ID_NUMERO_DOCUMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ULTIMO_NUMERO = table.Column<int>(type: "int", nullable: false),
                    FECHA_REGISTRO_DOCUMENTO = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NUMERO_D__193AEF0E9D41333E", x => x.ID_NUMERO_DOCUMENTO);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    RUT_PROVEEDOR = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NOMBRE_PROVEEDOR = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CORREO_PROVEEDOR = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TELEFONO_PROVEEDOR = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PROVEEDO__2D7D308F8DF3CA50", x => x.RUT_PROVEEDOR);
                });

            migrationBuilder.CreateTable(
                name: "ROL",
                columns: table => new
                {
                    ID_ROL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_ROL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FECHA_REGISTRO = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROL__203B0F680BDB756F", x => x.ID_ROL);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_PRODUCTO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ID_CATEGORIA = table.Column<int>(type: "int", nullable: true),
                    STOCK = table.Column<int>(type: "int", nullable: true),
                    PRECIO = table.Column<int>(type: "int", nullable: true),
                    ES_ACTIVO_PRODUCTO = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHA_REGISTRO_PRODUCTO = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTO__88BD0357E00B4A51", x => x.ID_PRODUCTO);
                    table.ForeignKey(
                        name: "FK__PRODUCTO__ID_CAT__37A5467C",
                        column: x => x.ID_CATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID_CATEGORIA");
                });

            migrationBuilder.CreateTable(
                name: "ORDEN_COMPRA",
                columns: table => new
                {
                    ID_ORDEN_COMPRA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUT_PROVEEDOR = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FECHA_ORDEN_COMPRA = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ORDEN_CO__6C6555B8E5B96314", x => x.ID_ORDEN_COMPRA);
                    table.ForeignKey(
                        name: "FK__ORDEN_COM__RUT_P__534D60F1",
                        column: x => x.RUT_PROVEEDOR,
                        principalTable: "PROVEEDOR",
                        principalColumn: "RUT_PROVEEDOR");
                });

            migrationBuilder.CreateTable(
                name: "MENU_ROL",
                columns: table => new
                {
                    ID_MENU_ROL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_MENU = table.Column<int>(type: "int", nullable: true),
                    ID_ROL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MENU_ROL__138F08B4006B0069", x => x.ID_MENU_ROL);
                    table.ForeignKey(
                        name: "FK__MENU_ROL__ID_MEN__29572725",
                        column: x => x.ID_MENU,
                        principalTable: "MENU",
                        principalColumn: "ID_MENU");
                    table.ForeignKey(
                        name: "FK__MENU_ROL__ID_ROL__2A4B4B5E",
                        column: x => x.ID_ROL,
                        principalTable: "ROL",
                        principalColumn: "ID_ROL");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_COMPLETO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CORREO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ID_ROL = table.Column<int>(type: "int", nullable: true),
                    CLAVE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ES_ACTIVO = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    FECHA_REGISTRO_USUARIO = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__91136B9060979093", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK__USUARIO__ID_ROL__2D27B809",
                        column: x => x.ID_ROL,
                        principalTable: "ROL",
                        principalColumn: "ID_ROL");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO_PROVEEDOR",
                columns: table => new
                {
                    RUT_PROVEEDOR = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPredeterminados", x => new { x.RUT_PROVEEDOR, x.ID_PRODUCTO });
                    table.ForeignKey(
                        name: "FK_ProductosPredeterminados_Producto",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO");
                    table.ForeignKey(
                        name: "FK_ProductosPredeterminados_Proveedor",
                        column: x => x.RUT_PROVEEDOR,
                        principalTable: "PROVEEDOR",
                        principalColumn: "RUT_PROVEEDOR");
                });

            migrationBuilder.CreateTable(
                name: "ProductoPorProveedor",
                columns: table => new
                {
                    IdProductoProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    RutProveedorNavigationRutProveedor = table.Column<string>(type: "varchar(20)", nullable: true),
                    IdProductoNavigationIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPorProveedor", x => x.IdProductoProveedor);
                    table.ForeignKey(
                        name: "FK_ProductoPorProveedor_PRODUCTO_IdProductoNavigationIdProducto",
                        column: x => x.IdProductoNavigationIdProducto,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO");
                    table.ForeignKey(
                        name: "FK_ProductoPorProveedor_PROVEEDOR_RutProveedorNavigationRutProveedor",
                        column: x => x.RutProveedorNavigationRutProveedor,
                        principalTable: "PROVEEDOR",
                        principalColumn: "RUT_PROVEEDOR");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_ORDEN_COMPRA",
                columns: table => new
                {
                    ID_DETALLE_ORDEN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ORDEN_COMPRA = table.Column<int>(type: "int", nullable: true),
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: true),
                    CANTIDAD = table.Column<int>(type: "int", nullable: true),
                    PRECIO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___C1617362308A7B27", x => x.ID_DETALLE_ORDEN);
                    table.ForeignKey(
                        name: "FK__DETALLE_O__ID_OR__571DF1D5",
                        column: x => x.ID_ORDEN_COMPRA,
                        principalTable: "ORDEN_COMPRA",
                        principalColumn: "ID_ORDEN_COMPRA");
                    table.ForeignKey(
                        name: "FK__DETALLE_O__ID_PR__5812160E",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO");
                });

            migrationBuilder.CreateTable(
                name: "FIADO",
                columns: table => new
                {
                    ID_VENTA = table.Column<int>(type: "int", nullable: true),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: true),
                    RUT_CLIENTE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NUMERO_DOCUMENTO = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    TIPO_PAGO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TOTAL = table.Column<int>(type: "int", nullable: true),
                    FECHA_REGISTRO_VENTA = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__FIADO__ID_USUARI__4AB81AF0",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO");
                    table.ForeignKey(
                        name: "FK__FIADO__RUT_CLIEN__4BAC3F29",
                        column: x => x.RUT_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "RUT_CLIENTE");
                });

            migrationBuilder.CreateTable(
                name: "VENTA",
                columns: table => new
                {
                    ID_VENTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: true),
                    RUT_CLIENTE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NUMERO_DOCUMENTO = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    TIPO_PAGO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TOTAL = table.Column<int>(type: "int", nullable: true),
                    FECHA_REGISTRO_VENTA = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VENTA__F3B6C1B44191C484", x => x.ID_VENTA);
                    table.ForeignKey(
                        name: "FK__VENTA__ID_USUARI__4222D4EF",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO");
                    table.ForeignKey(
                        name: "FK__VENTA__RUT_CLIEN__4316F928",
                        column: x => x.RUT_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "RUT_CLIENTE");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_VENTA",
                columns: table => new
                {
                    ID_DETALLE_VENTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VENTA = table.Column<int>(type: "int", nullable: true),
                    ID_PRODUCTO = table.Column<int>(type: "int", nullable: true),
                    CANTIDAD = table.Column<int>(type: "int", nullable: true),
                    PRECIO = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ES_FIADO = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___49DABA0C8B88FFFF", x => x.ID_DETALLE_VENTA);
                    table.ForeignKey(
                        name: "FK__DETALLE_V__ID_PR__47DBAE45",
                        column: x => x.ID_PRODUCTO,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PRODUCTO");
                    table.ForeignKey(
                        name: "FK__DETALLE_V__ID_VE__46E78A0C",
                        column: x => x.ID_VENTA,
                        principalTable: "VENTA",
                        principalColumn: "ID_VENTA");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_ORDEN_COMPRA_ID_ORDEN_COMPRA",
                table: "DETALLE_ORDEN_COMPRA",
                column: "ID_ORDEN_COMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_ORDEN_COMPRA_ID_PRODUCTO",
                table: "DETALLE_ORDEN_COMPRA",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_VENTA_ID_PRODUCTO",
                table: "DETALLE_VENTA",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_VENTA_ID_VENTA",
                table: "DETALLE_VENTA",
                column: "ID_VENTA");

            migrationBuilder.CreateIndex(
                name: "IX_FIADO_ID_USUARIO",
                table: "FIADO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_FIADO_RUT_CLIENTE",
                table: "FIADO",
                column: "RUT_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_ROL_ID_MENU",
                table: "MENU_ROL",
                column: "ID_MENU");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_ROL_ID_ROL",
                table: "MENU_ROL",
                column: "ID_ROL");

            migrationBuilder.CreateIndex(
                name: "IX_ORDEN_COMPRA_RUT_PROVEEDOR",
                table: "ORDEN_COMPRA",
                column: "RUT_PROVEEDOR");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_ID_CATEGORIA",
                table: "PRODUCTO",
                column: "ID_CATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTO_PROVEEDOR_ID_PRODUCTO",
                table: "PRODUCTO_PROVEEDOR",
                column: "ID_PRODUCTO");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPorProveedors_IdProductoNavigationIdProducto",
                table: "ProductoPorProveedors",
                column: "IdProductoNavigationIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPorProveedors_RutProveedorNavigationRutProveedor",
                table: "ProductoPorProveedors",
                column: "RutProveedorNavigationRutProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ID_ROL",
                table: "USUARIO",
                column: "ID_ROL");

            migrationBuilder.CreateIndex(
                name: "IX_VENTA_ID_USUARIO",
                table: "VENTA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_VENTA_RUT_CLIENTE",
                table: "VENTA",
                column: "RUT_CLIENTE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DETALLE_ORDEN_COMPRA");

            migrationBuilder.DropTable(
                name: "DETALLE_VENTA");

            migrationBuilder.DropTable(
                name: "FIADO");

            migrationBuilder.DropTable(
                name: "MENU_ROL");

            migrationBuilder.DropTable(
                name: "NUMERO_DOCUMENTO");

            migrationBuilder.DropTable(
                name: "PRODUCTO_PROVEEDOR");

            migrationBuilder.DropTable(
                name: "ProductoPorProveedors");

            migrationBuilder.DropTable(
                name: "ORDEN_COMPRA");

            migrationBuilder.DropTable(
                name: "VENTA");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "PROVEEDOR");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "ROL");
        }
    }
}
