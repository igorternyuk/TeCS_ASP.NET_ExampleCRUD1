CREATE DATABASE bd_contactos;
USE bd_contactos;

CREATE TABLE contacto(
    id INT IDENTITY(1,1),
    nombre VARCHAR(100),
    sexo VARCHAR(1),
    edad INT,
    telefono VARCHAR(50),
    PRIMARY KEY(id)
);

INSERT INTO contacto('Maria Cuevas','f','22','+35854554223');
SELECT * FROM contacto;