CREATE PROCEDURE sp_postres_actualizar
    @IdPostre INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Precio DECIMAL(10,2),
    @Imagen NVARCHAR(255)
AS
BEGIN
    UPDATE Postres
    SET Nombre=@Nombre,
        Descripcion=@Descripcion,
        Precio=@Precio,
        Imagen=@Imagen
    WHERE IdPostre=@IdPostre
END
