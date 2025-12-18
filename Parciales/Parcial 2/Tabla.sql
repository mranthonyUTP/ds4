CREATE TABLE Historial(
	Id                      INT IDENTITY(1,1) PRIMARY KEY,
    CantidadArchivos        INT,
    TamanoArchivoMB         DECIMAL(10,2)     NOT NULL,
    TamanoUSBGB             DECIMAL(10,2)     NOT NULL,
    TotalArchivosPosibles   INT             NOT NULL,
);