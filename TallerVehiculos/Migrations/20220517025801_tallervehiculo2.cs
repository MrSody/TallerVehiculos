﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerVehiculos.Migrations
{
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
    public partial class TallerVehiculos : Migration
========
    public partial class tallervehiculo2 : Migration
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudades", x => x.Id);
                });

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
                name: "sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
                    IdCiudades = table.Column<int>(type: "int", nullable: false),
========
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs
                    CiudadesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sedes_ciudades_CiudadesId",
                        column: x => x.CiudadesId,
                        principalTable: "ciudades",
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
========
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs
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
                    ClientesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehiculo_clientes_ClientesId",
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
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SedesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_sedes_SedesId",
                        column: x => x.SedesId,
                        principalTable: "sedes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSedes = table.Column<int>(type: "int", nullable: false),
                    SedesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_sedes_SedesId",
                        column: x => x.SedesId,
                        principalTable: "sedes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    ClientesId = table.Column<int>(type: "int", nullable: true),
                    Usuariosid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facturas_clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_facturas_usuarios_Usuariosid",
                        column: x => x.Usuariosid,
                        principalTable: "usuarios",
                        principalColumn: "id");
========
                name: "ServicioVehiculo",
                columns: table => new
                {
                    serviciosId = table.Column<int>(type: "int", nullable: false),
                    vehiculosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioVehiculo", x => new { x.serviciosId, x.vehiculosId });
                    table.ForeignKey(
                        name: "FK_ServicioVehiculo_servicio_serviciosId",
                        column: x => x.serviciosId,
                        principalTable: "servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioVehiculo_vehiculo_vehiculosId",
                        column: x => x.vehiculosId,
                        principalTable: "vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs
                });

            migrationBuilder.CreateTable(
                name: "detalleFacturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
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
                name: "IX_facturas_Usuariosid",
                table: "facturas",
                column: "Usuariosid");

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
                name: "IX_servicio_Nombre",
                table: "servicio",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicioVehiculo_vehiculosId",
                table: "ServicioVehiculo",
                column: "vehiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id",
                table: "usuarios",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_SedesId",
                table: "usuarios",
                column: "SedesId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_ClientesId",
                table: "vehiculo",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_placa",
                table: "vehiculo",
                column: "placa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleFacturas");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
                name: "vehiculo");
========
                name: "ServicioVehiculo");

            migrationBuilder.DropTable(
                name: "usuarios");
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuarios");
========
                name: "vehiculo");

            migrationBuilder.DropTable(
                name: "sedes");
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:TallerVehiculos/Migrations/20220517024259_TallerVehiculos.cs
                name: "sedes");
========
                name: "clientes");
>>>>>>>> 3fd96f5dcae90a6b2821bc0d7f0b2c1eaa9c2f34:TallerVehiculos/Migrations/20220517025801_tallervehiculo2.cs

            migrationBuilder.DropTable(
                name: "ciudades");
        }
    }
}
