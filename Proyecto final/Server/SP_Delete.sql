CREATE PROCEDURE sp_postres_eliminar
    @IdPostre INT
AS
BEGIN
    DELETE FROM Postres WHERE IdPostre=@IdPostre
END
