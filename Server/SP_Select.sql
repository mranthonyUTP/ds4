CREATE PROCEDURE sp_postres_listar
AS
BEGIN
    SELECT IdPostre, Nombre, Descripcion, Precio, Imagen
    FROM Postres
END