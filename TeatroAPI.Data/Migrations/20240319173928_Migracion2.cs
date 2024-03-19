using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeatroAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asiento",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "ReservaID",
                keyValue: 1,
                column: "Asiento",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "ReservaID",
                keyValue: 2,
                column: "Asiento",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "ReservaID",
                keyValue: 3,
                column: "Asiento",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asiento",
                table: "Reservas");
        }
    }
}
