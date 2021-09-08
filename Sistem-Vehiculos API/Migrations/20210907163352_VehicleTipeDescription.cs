using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistem_Vehiculos_API.Migrations
{
    public partial class VehicleTipeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "VehicleTypes",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleTypes_Descripcion",
                table: "VehicleTypes",
                newName: "IX_VehicleTypes_Description");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Procedures",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_Descripcion",
                table: "Procedures",
                newName: "IX_Procedures_Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "VehicleTypes",
                newName: "Descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes",
                newName: "IX_VehicleTypes_Descripcion");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Procedures",
                newName: "Descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Procedures_Description",
                table: "Procedures",
                newName: "IX_Procedures_Descripcion");
        }
    }
}
