using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeatroAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Precio = table.Column<int>(type: "int", nullable: true),
                    ObraID1 = table.Column<int>(type: "int", nullable: true),
                    SalaID1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Funciones_Obras_ObraID1",
                        column: x => x.ObraID1,
                        principalTable: "Obras",
                        principalColumn: "ObraID");
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Salas",
                        principalColumn: "SalaID");
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaID1",
                        column: x => x.SalaID1,
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
                    Dispositivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUserID = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UsuarioUserID",
                        column: x => x.UsuarioUserID,
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
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionID1 = table.Column<int>(type: "int", nullable: true),
                    UsuarioUserID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Reservas_Funciones_FuncionID1",
                        column: x => x.FuncionID1,
                        principalTable: "Funciones",
                        principalColumn: "FuncionID");
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UserID",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioUserID",
                        column: x => x.UsuarioUserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_ObraID",
                table: "Funciones",
                column: "ObraID");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_ObraID1",
                table: "Funciones",
                column: "ObraID1");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaID",
                table: "Funciones",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaID1",
                table: "Funciones",
                column: "SalaID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FuncionID",
                table: "Reservas",
                column: "FuncionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FuncionID1",
                table: "Reservas",
                column: "FuncionID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UserID",
                table: "Reservas",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioUserID",
                table: "Reservas",
                column: "UsuarioUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UserID",
                table: "Sesiones",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UsuarioUserID",
                table: "Sesiones",
                column: "UsuarioUserID");
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
