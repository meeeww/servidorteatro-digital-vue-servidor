using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IDCliente = table.Column<int>(name: "ID_Cliente", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IDEmpleado = table.Column<int>(name: "ID_Empleado", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IDEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IDProducto = table.Column<int>(name: "ID_Producto", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IDProducto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IDPedido = table.Column<int>(name: "ID_Pedido", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(name: "ID_Cliente", type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Enviado = table.Column<bool>(type: "bit", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteIDCliente = table.Column<int>(name: "ClienteID_Cliente", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IDPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteID_Cliente",
                        column: x => x.ClienteIDCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroVentas",
                columns: table => new
                {
                    IDRegistroVentas = table.Column<int>(name: "ID_RegistroVentas", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(name: "ID_Empleado", type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVentas = table.Column<int>(type: "int", nullable: false),
                    TotalCostos = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    TotalImpuestos = table.Column<int>(type: "int", nullable: false),
                    EmpleadoIDEmpleado = table.Column<int>(name: "EmpleadoID_Empleado", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVentas", x => x.IDRegistroVentas);
                    table.ForeignKey(
                        name: "FK_RegistroVentas_Empleados_EmpleadoID_Empleado",
                        column: x => x.EmpleadoIDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado");
                    table.ForeignKey(
                        name: "FK_RegistroVentas_Empleados_ID_Empleado",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    IDDetallePedido = table.Column<int>(name: "ID_DetallePedido", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPedido = table.Column<int>(name: "ID_Pedido", type: "int", nullable: false),
                    IDProducto = table.Column<int>(name: "ID_Producto", type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedidoIDPedido = table.Column<int>(name: "PedidoID_Pedido", type: "int", nullable: false),
                    ProductoIDProducto = table.Column<int>(name: "ProductoID_Producto", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.IDDetallePedido);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_PedidoID_Pedido",
                        column: x => x.PedidoIDPedido,
                        principalTable: "Pedidos",
                        principalColumn: "ID_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_ProductoID_Producto",
                        column: x => x.ProductoIDProducto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PedidoID_Pedido",
                table: "DetallePedidos",
                column: "PedidoID_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ProductoID_Producto",
                table: "DetallePedidos",
                column: "ProductoID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID_Cliente",
                table: "Pedidos",
                column: "ClienteID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVentas_EmpleadoID_Empleado",
                table: "RegistroVentas",
                column: "EmpleadoID_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVentas_ID_Empleado",
                table: "RegistroVentas",
                column: "ID_Empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "RegistroVentas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
