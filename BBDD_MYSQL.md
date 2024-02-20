CREATE TABLE `Clientes` (
  `ID_Cliente` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Apellido` varchar(32) NOT NULL,
  `Email` varchar(32) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Direccion` varchar(128) NOT NULL
);

INSERT INTO `Clientes` (`ID_Cliente`, `Nombre`, `Apellido`, `Email`, `Telefono`, `Direccion`) VALUES
(1, 'omar', 'string', 'string', 'string', 'string'),
(4, 'funciona', ':)', 'string', 'string', 'string');

CREATE TABLE `DetallePedidos` (
  `ID_DetallePedido` int NOT NULL,
  `ID_Pedido` int NOT NULL,
  `ID_Producto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Subtotal` decimal(11,2) NOT NULL,
  `FechaCreacion` date NOT NULL,
  `FechaModificacion` date NOT NULL
);

CREATE TABLE `Empleados` (
  `ID_Empleado` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Apellido` varchar(32) NOT NULL,
  `Cargo` varchar(64) NOT NULL,
  `Salario` decimal(11,2) NOT NULL,
  `FechaEntrada` date NOT NULL,
  `FechaSalida` date DEFAULT NULL
);

INSERT INTO `Empleados` (`ID_Empleado`, `Nombre`, `Apellido`, `Cargo`, `Salario`, `FechaEntrada`, `FechaSalida`) VALUES
(1, 'zas', 'zas', 'zas', '0.00', '2023-12-04', '2023-12-04');

CREATE TABLE `Pedidos` (
  `ID_Pedido` int NOT NULL,
  `ID_Cliente` int NOT NULL,
  `Fecha` date NOT NULL,
  `Total` decimal(11,2) NOT NULL,
  `Enviado` tinyint NOT NULL DEFAULT '0',
  `MetodoPago` varchar(32) NOT NULL
);

--
-- Dumping data for table `Pedidos`
--

INSERT INTO `Pedidos` (`ID_Pedido`, `ID_Cliente`, `Fecha`, `Total`, `Enviado`, `MetodoPago`) VALUES
(4, 1, '2023-12-04', '0.00', 1, '0');

CREATE TABLE `Productos` (
  `ID_Producto` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Descripcion` varchar(128) NOT NULL,
  `Precio` decimal(11,2) NOT NULL,
  `Stock` int NOT NULL,
  `Imagen` varchar(256) NOT NULL
);

INSERT INTO `Productos` (`ID_Producto`, `Nombre`, `Descripcion`, `Precio`, `Stock`, `Imagen`) VALUES
(1, 'Omar', 'no trajo pa tomar', '10.00', 0, 'imagenpng');

CREATE TABLE `RegistroVentas` (
  `ID_RegistroVentas` int NOT NULL,
  `ID_Empleado` int NOT NULL,
  `Fecha` date NOT NULL,
  `TotalVentas` int NOT NULL,
  `TotalCostos` decimal(11,2) NOT NULL,
  `TotalImpuestos` int NOT NULL
);

INSERT INTO `RegistroVentas` (`ID_RegistroVentas`, `ID_Empleado`, `Fecha`, `TotalVentas`, `TotalCostos`, `TotalImpuestos`) VALUES
(4, 1, '2023-12-05', 0, '0.00', 0);

ALTER TABLE `Clientes`
  ADD PRIMARY KEY (`ID_Cliente`);

ALTER TABLE `DetallePedidos`
  ADD PRIMARY KEY (`ID_DetallePedido`),
  ADD KEY `FK_ID_Pedido` (`ID_Pedido`),
  ADD KEY `FK_ID_Producto` (`ID_Producto`);
  
ALTER TABLE `Empleados`
  ADD PRIMARY KEY (`ID_Empleado`);

ALTER TABLE `Pedidos`
  ADD PRIMARY KEY (`ID_Pedido`),
  ADD KEY `FK_ID_Cliente` (`ID_Cliente`);

ALTER TABLE `Productos`
  ADD PRIMARY KEY (`ID_Producto`);

ALTER TABLE `RegistroVentas`
  ADD PRIMARY KEY (`ID_RegistroVentas`),
  ADD KEY `FK_ID_Empleado` (`ID_Empleado`);

ALTER TABLE `Clientes`
  MODIFY `ID_Cliente` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

ALTER TABLE `DetallePedidos`
  MODIFY `ID_DetallePedido` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `Empleados`
  MODIFY `ID_Empleado` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `Pedidos`
  MODIFY `ID_Pedido` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

ALTER TABLE `Productos`
  MODIFY `ID_Producto` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `RegistroVentas`
  MODIFY `ID_RegistroVentas` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

ALTER TABLE `DetallePedidos`
  ADD CONSTRAINT `FK_ID_Pedido` FOREIGN KEY (`ID_Pedido`) REFERENCES `Pedidos` (`ID_Pedido`),
  ADD CONSTRAINT `FK_ID_Producto` FOREIGN KEY (`ID_Producto`) REFERENCES `Productos` (`ID_Producto`);

ALTER TABLE `Pedidos`
  ADD CONSTRAINT `FK_ID_Cliente` FOREIGN KEY (`ID_Cliente`) REFERENCES `Clientes` (`ID_Cliente`);

ALTER TABLE `RegistroVentas`
  ADD CONSTRAINT `FK_ID_Empleado` FOREIGN KEY (`ID_Empleado`) REFERENCES `Empleados` (`ID_Empleado`);
COMMIT;
