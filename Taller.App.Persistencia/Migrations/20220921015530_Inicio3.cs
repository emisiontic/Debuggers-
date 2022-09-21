using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.App.Persistencia.Migrations
{
    public partial class Inicio3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueñoId",
                table: "Vehiculos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DueñoId",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
