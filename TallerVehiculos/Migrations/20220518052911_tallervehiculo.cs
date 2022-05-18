using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerVehiculos.Migrations
{
    public partial class tallervehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_sedes_SedesId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "ServicioVehiculo");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_SedesId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "SedesId",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "servicio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_servicio_VehiculoId",
                table: "servicio",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_servicio_vehiculo_VehiculoId",
                table: "servicio",
                column: "VehiculoId",
                principalTable: "vehiculo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_servicio_vehiculo_VehiculoId",
                table: "servicio");

            migrationBuilder.DropIndex(
                name: "IX_servicio_VehiculoId",
                table: "servicio");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "servicio");

            migrationBuilder.AddColumn<int>(
                name: "SedesId",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_SedesId",
                table: "usuarios",
                column: "SedesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioVehiculo_vehiculosId",
                table: "ServicioVehiculo",
                column: "vehiculosId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_sedes_SedesId",
                table: "usuarios",
                column: "SedesId",
                principalTable: "sedes",
                principalColumn: "Id");
        }
    }
}
