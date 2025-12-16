CREATE PROCEDURE sp_postres_insertar
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Precio DECIMAL(10,2),
    @Imagen NVARCHAR(255)
AS
BEGIN
    INSERT INTO Postres (Nombre, Descripcion, Precio, Imagen)
    VALUES (@Nombre, @Descripcion, @Precio, @Imagen)
END
