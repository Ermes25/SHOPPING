USE Compras;

-- Tabla de Categorías
CREATE TABLE Categorias (
    idCategoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
);

-- Tabla de Artículos
CREATE TABLE Articulos (
    idArticulo INT IDENTITY(1,1) PRIMARY KEY,
    nombreArticulo VARCHAR(100) NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad >= 0),
    precio DECIMAL(10, 2) NOT NULL CHECK (precio >= 0),
    idCategoria INT NULL,
    activo BIT NOT NULL DEFAULT 1,
    fechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idCategoria) REFERENCES Categorias(idCategoria)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

GO

-- Vista de resumen para Dashboard principal
CREATE VIEW vcontrolacs AS
SELECT 
    c.idCategoria,
    c.nombre AS categoria,
    COUNT(a.idArticulo) AS cantidadArticulos,
    SUM(a.cantidad) AS totalCantidad,
    SUM(a.precio * a.cantidad) AS totalPrecio
FROM Categorias c
LEFT JOIN Articulos a ON c.idCategoria = a.idCategoria AND a.activo = 1
GROUP BY c.idCategoria, c.nombre;
GO

CREATE VIEW vArticulos AS
SELECT 
    a.idArticulo,
    a.nombreArticulo,
    a.cantidad,
    a.precio,
    a.idCategoria,
    c.nombre AS nombre, -- nombre de la categoría
    a.activo,
    a.fechaCreacion
FROM Articulos a
LEFT JOIN Categorias c ON a.idCategoria = c.idCategoria;
GO



INSERT INTO Categorias (nombre)
VALUES 
('Frutas'),
('Verduras');


INSERT INTO Articulos (nombreArticulo, cantidad, precio, idCategoria)
VALUES 
('Manzana Roja', 150, 0.30, 1),
('Plátano', 200, 0.25, 1),
('Naranja', 180, 0.40, 1),
('Lechuga', 100, 0.50, 2),
('Zanahoria', 120, 0.35, 2),
('Tomate', 170, 0.45, 2);


SELECT * FROM dbo.vcontrolacs;

SELECT * FROM Categorias;

SELECT * FROM Articulos;

SELECT * FROM dbo.vArticulos;