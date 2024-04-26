CREATE TABLE Usuarios (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  Nombre VARCHAR(255),
  Apellido VARCHAR(255),
  Documento VARCHAR(255),
  CorreoElectronico VARCHAR(255),
  Direccion VARCHAR(255),
  Telefono VARCHAR(255),
  FechaNacimiento DATE,
  TipoAfiliacion VARCHAR(255)
)

CREATE TABLE Turnos (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  TipoServicio VARCHAR(30),
  FechaHoraTurno DATETIME,
  Estado VARCHAR(10),-- en espera, en proceso, finalizado, ausente
  IdUsuario INT,
  FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
)

SELECT * FROM Usuarios;
SELECT * FROM Turnos;

DROP TABLE usuarios

DROP TABLE Turnos

INSERT INTO `Usuarios`(`Nombre`,`Apellido`,`Documento`,`CorreoElectronico`,`Direccion`,`Telefono`,`FechaNacimiento`,`TipoAfiliacion`) VALUES('Mariana','Bedoya','9876546','mari@gmail.com','calle feliz','654654','2024-04-03','Cotizante');

INSERT INTO `Usuarios`(`Nombre`,`Apellido`,`Documento`,`CorreoElectronico`,`Direccion`,`Telefono`,`FechaNacimiento`,`TipoAfiliacion`) VALUES('Juan Pablo','Giraldo','321654','juan@gmail.com','calle feliz','258369','1987-11-14','Cotizante');

INSERT INTO `Usuarios`(`Nombre`,`Apellido`,`Documento`,`CorreoElectronico`,`Direccion`,`Telefono`,`FechaNacimiento`,`TipoAfiliacion`) VALUES('Wilmar','Puerta','123456789','wilmar@gmail.com','calle feliz','45258369','2003-05-14','Cotizante');

INSERT INTO `Usuarios`(`Nombre`,`Apellido`,`Documento`,`CorreoElectronico`,`Direccion`,`Telefono`,`FechaNacimiento`,`TipoAfiliacion`) VALUES('Cristhian','Monsalve','12345','cristhian@gmail.com','calle feliz','45258369','2000-10-20','Cotizante');