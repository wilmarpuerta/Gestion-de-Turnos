CREATE TABLE usuarios (
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

CREATE TABLE turnos (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  TipoServicio VARCHAR(20),
  Estado VARCHAR(20),-- en espera, en proceso, finalizado, ausente
  IdUsuario INT,
  FOREIGN KEY (IdUsuario) REFERENCES usuarios(Id)
)


DROP TABLE usuarios

DROP TABLE turnos

INSERT INTO 