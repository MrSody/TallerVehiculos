using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerVehiculos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nit = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudades_clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombrePropietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<double>(type: "float", nullable: false),
                    ClientesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facturas_clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientesId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehiculo_clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vehiculo_servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "servicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCiudad = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadesId = table.Column<int>(type: "int", nullable: true),
                    Usuariosid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sedes_ciudades_CiudadesId",
                        column: x => x.CiudadesId,
                        principalTable: "ciudades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sedes_usuarios_Usuariosid",
                        column: x => x.Usuariosid,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "detalleFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFactura = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleFacturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleFacturas_facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "facturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_detalleFacturas_productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudades_ClientesId",
                table: "ciudades",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_ciudades_Nombre",
                table: "ciudades",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Id",
                table: "clientes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalleFacturas_FacturaId",
                table: "detalleFacturas",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleFacturas_Id",
                table: "detalleFacturas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalleFacturas_ProductosId",
                table: "detalleFacturas",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_ClientesId",
                table: "facturas",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_Id",
                table: "facturas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productos_Nombre",
                table: "productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productos_ProveedorId",
                table: "productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_Id",
                table: "proveedores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sedes_CiudadesId",
                table: "sedes",
                column: "CiudadesId");

            migrationBuilder.CreateIndex(
                name: "IX_sedes_Id",
                table: "sedes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sedes_Usuariosid",
                table: "sedes",
                column: "Usuariosid");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_Nombre",
                table: "servicio",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id",
                table: "usuarios",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_ClientesId",
                table: "vehiculo",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_placa",
                table: "vehiculo",
                column: "placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_ServicioId",
                table: "vehiculo",
                column: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleFacturas");

            migrationBuilder.DropTable(
                name: "sedes");

            migrationBuilder.DropTable(
                name: "vehiculo");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ciudades");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
