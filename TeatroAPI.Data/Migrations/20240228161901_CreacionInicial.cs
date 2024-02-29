using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeatroAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObraID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraID = table.Column<int>(type: "int", nullable: true),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionID);
                    table.ForeignKey(
                        name: "FK_Funciones_Obras_ObraID",
                        column: x => x.ObraID,
                        principalTable: "Obras",
                        principalColumn: "ObraID");
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID");
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UserID",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Funciones_FuncionID",
                        column: x => x.FuncionID,
                        principalTable: "Funciones",
                        principalColumn: "FuncionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UserID",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "ObraID", "Descripcion", "Director", "FechaFin", "FechaInicio", "Titulo" },
                values: new object[,]
                {
                    { 1, null, "Pedro Calderón de la Barca", null, null, "La vida es sueño" },
                    { 2, null, "William Shakespeare", null, null, "Hamlet" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaID", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 100, "Sala Principal" },
                    { 2, 50, "Sala Secundaria" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserID", "Apellido", "Contra", "Email", "Nombre", "Rol", "Telefono" },
                values: new object[,]
                {
                    { 1, null, null, "juanperez@mail.com", "Juan Pérez", 0, null },
                    { 2, null, null, "analopez@mail.com", "Ana López", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionID", "FechaHora", "ObraID", "Precio", "SalaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1 },
                    { 2, new DateTime(2024, 3, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2 },
                    { 3, new DateTime(2024, 3, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaID", "FechaReserva", "FuncionID", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_ObraID",
                table: "Funciones",
                column: "ObraID");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaID",
                table: "Funciones",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FuncionID",
                table: "Reservas",
                column: "FuncionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UserID",
                table: "Reservas",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UserID",
                table: "Sesiones",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
