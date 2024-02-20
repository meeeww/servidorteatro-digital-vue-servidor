CREATE TABLE Clientes (
  ID_Cliente int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nombre varchar(32) NOT NULL,
  Apellido varchar(32) NOT NULL,
  Email varchar(32) NOT NULL,
  Telefono varchar(12) NOT NULL,
  Direccion varchar(128) NOT NULL
);

INSERT INTO Clientes (Nombre, Apellido, Email, Telefono, Direccion) VALUES
('omar', 'string', 'string', 'string', 'string'),
('funciona', ':)', 'string', 'string', 'string');

CREATE TABLE DetallePedidos (
  ID_DetallePedido int NOT NULL PRIMARY KEY IDENTITY(1,1),
  ID_Pedido int NOT NULL,
  ID_Producto int NOT NULL,
  Cantidad int NOT NULL,
  Subtotal decimal(11,2) NOT NULL,
  FechaCreacion date NOT NULL,
  FechaModificacion date NULL
);

CREATE TABLE Empleados (
  ID_Empleado int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nombre varchar(32) NOT NULL,
  Apellido varchar(32) NOT NULL,
  Cargo varchar(64) NOT NULL,
  Salario decimal(11,2) NOT NULL,
  FechaEntrada date NOT NULL,
  FechaSalida date NULL
);

INSERT INTO Empleados (Nombre, Apellido, Cargo, Salario, FechaEntrada, FechaSalida) VALUES
('zas', 'zas', 'zas', 0.00, '2023-12-04', '2023-12-04');

CREATE TABLE Pedidos (
  ID_Pedido int NOT NULL PRIMARY KEY IDENTITY(1,1),
  ID_Cliente int NOT NULL,
  Fecha date NOT NULL,
  Total decimal(11,2) NOT NULL,
  Enviado bit NOT NULL DEFAULT 0,
  MetodoPago varchar(32) NOT NULL
);

INSERT INTO Pedidos (ID_Cliente, Fecha, Total, Enviado, MetodoPago) VALUES
(1, '2023-12-04', 0.00, 1, '0');

CREATE TABLE Productos (
  ID_Producto int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Nombre varchar(32) NOT NULL,
  Descripcion varchar(128) NOT NULL,
  Precio decimal(11,2) NOT NULL,
  Stock int NOT NULL,
  Imagen varchar(256) NOT NULL
);

INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Imagen) VALUES
('Omar', 'no trajo pa tomar', 10.00, 0, 'imagenpng');

CREATE TABLE RegistroVentas (
  ID_RegistroVentas int NOT NULL PRIMARY KEY IDENTITY(1,1),
  ID_Empleado int NOT NULL,
  Fecha date NOT NULL,
  TotalVentas int NOT NULL,
  TotalCostos decimal(11,2) NOT NULL,
  TotalImpuestos int NOT NULL
);

INSERT INTO RegistroVentas (ID_Empleado, Fecha, TotalVentas, TotalCostos, TotalImpuestos) VALUES
(1, '2023-12-05', 0, 0.00, 0);

ALTER TABLE DetallePedidos
ADD FOREIGN KEY (ID_Pedido) REFERENCES Pedidos(ID_Pedido);

ALTER TABLE DetallePedidos
ADD FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto);

ALTER TABLE Pedidos
ADD FOREIGN KEY (ID_Cliente) REFERENCES Clientes(ID_Cliente);

ALTER TABLE RegistroVentas
ADD FOREIGN KEY (ID_Empleado) REFERENCES Empleados(ID_Empleado);
