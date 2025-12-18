CREATE DATABASE PROD_REPOSTERIA;

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL, -- 'Admin' | 'Usuario'
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado BIT DEFAULT 1
);

CREATE TABLE Postres (
    IdPostre INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10,2) NOT NULL,
    Imagen NVARCHAR(255), -- ruta o nombre de archivo
    Estado BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NULL,
    FechaCompra DATETIME DEFAULT GETDATE(),
    Total DECIMAL(10,2),

    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

CREATE TABLE DetalleCompra (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT,
    IdPostre INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),

    FOREIGN KEY (IdCompra) REFERENCES Compras(IdCompra),
    FOREIGN KEY (IdPostre) REFERENCES Postres(IdPostre)
);



CREATE TABLE Pedidos (
    IdPedido INT IDENTITY PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    Total DECIMAL(10,2),
    Estado NVARCHAR(50) -- Pendiente / Confirmado
);

CREATE TABLE PedidoDetalle (
    IdDetalle INT IDENTITY PRIMARY KEY,
    IdPedido INT,
    IdPostre INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),

    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    FOREIGN KEY (IdPostre) REFERENCES Postres(IdPostre)
)
