CREATE TABLE Usuarios (
    UserID INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    Contraseña VARCHAR(255),
    Rol INT
);

CREATE TABLE Sesiones (
    SessionID INT IDENTITY PRIMARY KEY,
    UserID INT,
    Token VARCHAR(255),
    FechaInicio DATETIME,
    FechaFin DATETIME,
    IP VARCHAR(50),
    Dispositivo VARCHAR(200)
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID)
);

CREATE TABLE Obras (
    ObraID INT IDENTITY PRIMARY KEY,
    Titulo VARCHAR(255),
    Descripcion TEXT,
    FechaInicio DATETIME,
    FechaFin DATETIME,
    Director VARCHAR(255)
);

CREATE TABLE Salas (
    SalaID INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(255),
    Capacidad INT
);

CREATE TABLE Funciones (
    FuncionID INT IDENTITY PRIMARY KEY,
    ObraID INT,
    SalaID INT,
    FechaHora DATETIME,
    Precio DECIMAL(10, 2),
    FOREIGN KEY (ObraID) REFERENCES Obras(ObraID),
    FOREIGN KEY (SalaID) REFERENCES Salas(SalaID)
);

CREATE TABLE Reservas (
    ReservaID INT IDENTITY PRIMARY KEY,
    FuncionID INT,
    UserID INT,
    Cantidad INT,
    FechaReserva DATETIME,
    FOREIGN KEY (FuncionID) REFERENCES Funciones(FuncionID),
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID)
);