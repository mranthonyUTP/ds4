INSERT INTO Usuarios (Nombre, Email, Password, Rol)
VALUES 
('Administrador', 'admin@reposteria.com', '1234', 'Admin'),
('Cliente Demo', 'cliente@correo.com', '1234', 'Usuario');

INSERT INTO Postres (Nombre, Descripcion, Precio, Imagen)
VALUES
('Cupcake de Chocolate', 'Cupcake con relleno de chocolate', 2.50, 'cupcake_choco.jpg'),
('Cheesecake Fresa', 'Cheesecake con topping de fresa', 4.75, 'cheesecake_fresa.jpg'),
('Brownie', 'Brownie clásico con nueces', 3.00, 'brownie.jpg');

INSERT INTO Compras (IdUsuario, Total)
VALUES (2, 10.25);

INSERT INTO DetalleCompra (IdCompra, IdPostre, Cantidad, PrecioUnitario)
VALUES
(1, 1, 2, 2.50),
(1, 3, 1, 3.00);

SELECT * FROM Usuarios;

SELECT * FROM Postres;

SELECT 
    C.IdCompra,
    U.Nombre AS Usuario,
    P.Nombre AS Postre,
    D.Cantidad,
    D.PrecioUnitario
FROM Compras C
LEFT JOIN Usuarios U ON C.IdUsuario = U.IdUsuario
JOIN DetalleCompra D ON C.IdCompra = D.IdCompra
JOIN Postres P ON D.IdPostre = P.IdPostre;
