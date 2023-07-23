--Trabajo Proyecto Final Programaci�n 5
/* Autores:
* Esteban Mora
* Andres Rojas
* William Herrera*/

/** SE CREA LA BASE DE DATOS**/
CREATE DATABASE SISTEMA_GESTION_ACADEMICA
GO

/** SE SELECCIONA LA BASE DE DATOS CREADA**/
USE SISTEMA_GESTION_ACADEMICA
GO

/** INSTRUCCION QUE PERMITE CREAR LOS DIAGRAMAS**/
Alter authorization on database::SISTEMA_GESTION_ACADEMICA to sa 
GO

/*Establece el formato de la fecha en dia/mes/a�o, 
cualquiera de las dos*/
SET DATEFORMAT dmy
SET LANGUAGE spanish
GO

/*Instruccion que indica que la proxima consulta 
se ejecutar� hasta que termine de ejecutarse la sentencia anterior*/
GO 

--CREACION DE TABLAS
CREATE TABLE ROLLES(
	ID_ROLLES	INT IDENTITY(1,1) NOT NULL,
	NOMBREROLL VARCHAR(20) NOT NULL,
	CONSTRAINT PK_ROLLES PRIMARY KEY (ID_ROLLES)
)
GO

CREATE TABLE USUARIO
(
	CEDULA INT NOT NULL,
	NOMBRE VARCHAR(20) NOT NULL,
	APELLIDOS VARCHAR(30) NOT NULL,
	EDAD INT NOT NULL,
	CORREO VARCHAR(100) NOT NULL,
	CLAVE NVARCHAR(MAX) NOT NULL,
	CODIGODOCENTE VARCHAR(10) NULL,
	FECHA DATETIME NOT NULL,
	ID_ROLLES INT NOT NULL,
	ACTIVO BIT NOT NULL,
	CONSTRAINT PK_CEDULA PRIMARY KEY(CEDULA),
	CONSTRAINT FK_ROLLES_USUARIO FOREIGN KEY (ID_ROLLES) REFERENCES ROLLES (ID_ROLLES)
)
GO

CREATE TABLE LOGING
(
	ID_LOGING INT IDENTITY(1,1) NOT NULL,
	CEDULA INT NOT NULL,
	FECHA DATETIME NOT NULL,
	REGISTRO BIT,
	CONSTRAINT PK_LOGING PRIMARY KEY (ID_LOGING),
	CONSTRAINT FK_USUARIO_LOGING FOREIGN KEY (CEDULA) REFERENCES USUARIO (CEDULA)
)
GO

CREATE TABLE ESTADO_SOLICITUD(
	ID_ESTADO_SOLICITUD INT IDENTITY(1,1) NOT NULL,
	NOMBRE_ESTADO VARCHAR(20) NOT NULL,
	CONSTRAINT PK_ID_ESTADO_SOLICITUD PRIMARY KEY(ID_ESTADO_SOLICITUD)
)
GO

CREATE TABLE SOLICITUD_USUARIO(
	ID_SOLICITUD_USUARIO INT IDENTITY(1,1) NOT NULL,
	CEDULA INT NOT NULL,
	FECHA_SOLICITUD DATETIME NOT NULL,
	ID_ESTADO INT NOT NULL,
	CONSTRAINT PK_ID_SOLICITUD_USUARIO PRIMARY KEY(ID_SOLICITUD_USUARIO),
	CONSTRAINT FK_ESTADO_SOLICITUD_SOLICITUD_USUARIO FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO_SOLICITUD (ID_ESTADO_SOLICITUD),
	CONSTRAINT FK_USUARIO_SOLICITUD_USUARIO FOREIGN KEY (CEDULA) REFERENCES USUARIO (CEDULA)
)
GO

CREATE TABLE LOG_SOLICITUDES(
	ID_LOG_SOLICITUDES INT IDENTITY(1,1) NOT NULL,
	ID_ESTADO_ANTERIOR INT NOT NULL,
	ID_ESTADO_ACTUAL INT NOT NULL,
	ID_SOLICITUD_USUARIO INT NOT NULL,
	FECHA DATETIME NOT NULL,
	CONSTRAINT PK_ID_LOG_SOLICITUDES PRIMARY KEY(ID_LOG_SOLICITUDES),
	CONSTRAINT FK_ID_ESTADO_SOLICITUD_LOG_SOLICITUDES_ANT FOREIGN KEY (ID_ESTADO_ANTERIOR) REFERENCES ESTADO_SOLICITUD (ID_ESTADO_SOLICITUD),
	CONSTRAINT FK_ID_ESTADO_SOLICITUD_LOG_SOLICITUDES_ACT FOREIGN KEY (ID_ESTADO_ACTUAL) REFERENCES ESTADO_SOLICITUD (ID_ESTADO_SOLICITUD),
	CONSTRAINT FK_ID_SOLICITUD_USUARIO_LOG_SOLICITUDES FOREIGN KEY (ID_SOLICITUD_USUARIO) REFERENCES SOLICITUD_USUARIO (ID_SOLICITUD_USUARIO)
)
GO

CREATE TABLE CUATRIMESTRE
(
	ID_CUATRIMESTRE INT IDENTITY(1,1) NOT NULL,
	NOMBRE VARCHAR(20)NOT NULL,
	CONSTRAINT PK_ID_CUATRIMESTRE PRIMARY KEY(ID_CUATRIMESTRE)
)
GO

CREATE TABLE TELEFONO
(
	ID_TELEFONO INT IDENTITY(1,1) NOT NULL,
	NUMERO INT NOT NULL,
	CEDULA INT NOT NULL,
	CONSTRAINT PK_ID_TELEFONO PRIMARY KEY(ID_TELEFONO),
	CONSTRAINT FK_USUARIO_TELEFONO FOREIGN KEY (CEDULA) REFERENCES USUARIO (CEDULA)
)
GO

CREATE TABLE DIRECCION
(
	ID_DIRECCI�N INT IDENTITY(1,1) NOT NULL,
	DIRECCION VARCHAR(150) NOT NULL,
	CEDULA INT NOT NULL,
	CONSTRAINT PK_ID_DIRECCI�N PRIMARY KEY(ID_DIRECCI�N),
	CONSTRAINT FK_USUARIO_DIRECCION FOREIGN KEY (CEDULA) REFERENCES USUARIO (CEDULA)
)
GO

CREATE TABLE BLOQUE
(
	ID_BLOQUE INT IDENTITY(1,1) NOT NULL,
	NOMBRE VARCHAR(20) NOT NULL,
	CONSTRAINT PK_ID_BLOQUE PRIMARY KEY(ID_BLOQUE)
)
GO

CREATE TABLE CURSO
(
	ID_CURSO VARCHAR(10) NOT NULL,
	NOMBRECURSO VARCHAR(20) NOT NULL,
	CREDITO INT NOT NULL,
	REQUISITOUNO VARCHAR(10) NULL,
	REQUISITODOS VARCHAR(10) NULL,
	REQUISITOTRES VARCHAR(10) NULL,
	REQUISITOCUATRO VARCHAR(10) NULL,
	BLOQUE INT NOT NULL,
	CONSTRAINT PK_ID_CURSO PRIMARY KEY(ID_CURSO),
	CONSTRAINT FK_BLOQUE_CURSO FOREIGN KEY (BLOQUE) REFERENCES BLOQUE(ID_BLOQUE),
)
GO

CREATE TABLE RELACION_CURSO_DOCENTE
(
	ID_RECD INT IDENTITY(1,1) NOT NULL,
	ID_CURSO VARCHAR(10) NOT NULL,
	CEDULA INT NOT NULL,
	CONSTRAINT PK_ID_RECD PRIMARY KEY(ID_RECD),
	CONSTRAINT FK_RELACION_CURSO_DOCENTE FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO),
	CONSTRAINT FK_RELACION_DOCENTE FOREIGN KEY (CEDULA) REFERENCES USUARIO(CEDULA)
)
GO

CREATE TABLE GRADO
(
	ID_GRADO INT IDENTITY(1,1) NOT NULL,
	NOMBREGRADO VARCHAR(15) NOT NULL,
	CONSTRAINT PK_ID_GRADO PRIMARY KEY(ID_GRADO),
)
GO

CREATE TABLE FACULTAD
(
	ID_FACULTAD INT IDENTITY(1,1) NOT NULL,
	NOMBREFACULTAD VARCHAR(15) NOT NULL,
	CONSTRAINT PK_ID_FACULTAD PRIMARY KEY(ID_FACULTAD),
)
GO

CREATE TABLE CARRERA
(
	ID_CARRERA VARCHAR(15) NOT NULL,
	NOMBRECARRERA VARCHAR(15) NOT NULL,
	ID_FACULTAD INT NOT NULL,
	ID_GRADO INT NOT NULL,
	CONSTRAINT PK_ID_CARRERA PRIMARY KEY(ID_CARRERA),
	CONSTRAINT FK_FACULTAD_CARRERA FOREIGN KEY (ID_FACULTAD) REFERENCES FACULTAD(ID_FACULTAD),
	CONSTRAINT FK_GRADO_CARRERA FOREIGN KEY (ID_GRADO) REFERENCES GRADO(ID_GRADO)
)
GO

CREATE TABLE PLAN_CURSO
(
	CODIGOPLAN VARCHAR(10) NOT NULL,
	NOMBREPLAN VARCHAR(10) NOT NULL,
	ID_CARRERA VARCHAR(15) NOT NULL,
	CONSTRAINT PK_CODIGOPLAN PRIMARY KEY(CODIGOPLAN),
	CONSTRAINT FK_RELACION_CARRERA FOREIGN KEY (ID_CARRERA) REFERENCES CARRERA(ID_CARRERA)
)
GO

CREATE TABLE RELACION_CURSO_PLAN
(
	ID_RECP INT IDENTITY(1,1) NOT NULL,
	ID_CURSO VARCHAR(10) NOT NULL,
	CODIGOPLAN VARCHAR(10) NOT NULL,
	CONSTRAINT PK_ID_RECP PRIMARY KEY(ID_RECP),
	CONSTRAINT FK_RELACION_CURSO_PLAN FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO),
	CONSTRAINT FK_RELACION_PLAN_CURSO FOREIGN KEY (CODIGOPLAN) REFERENCES PLAN_CURSO(CODIGOPLAN)
)
GO

CREATE TABLE SEDE
(
	ID_SEDE INT IDENTITY(1,1) NOT NULL,
	NOMBRE VARCHAR(10) NOT NULL,
	UBICACION VARCHAR(20) NOT NULL,
	CONSTRAINT PK_ID_SEDE PRIMARY KEY(ID_SEDE)
)
GO

CREATE TABLE RELACION_SEDE_FACULTAD
(
	ID_RESF INT IDENTITY(1,1) NOT NULL,
	ID_FACULTAD INT NOT NULL,
	ID_SEDE INT NOT NULL,
	CONSTRAINT PK_ID_RESF PRIMARY KEY(ID_RESF),
	CONSTRAINT FK_RELACION_SEDE_FACULTAD FOREIGN KEY (ID_SEDE) REFERENCES SEDE(ID_SEDE),
	CONSTRAINT FK_RELACION_FACULTAD FOREIGN KEY (ID_FACULTAD) REFERENCES FACULTAD(ID_FACULTAD)
)
GO

CREATE TABLE RELACION_SEDE_DOCENTE
(
	ID_RESD INT IDENTITY(1,1) NOT NULL,
	ID_SEDE INT NOT NULL,
	CEDULA INT NOT NULL,
	CONSTRAINT PK_ID_RESD PRIMARY KEY(ID_RESD),
	CONSTRAINT FK_RELACION_SEDE_DOCENTE FOREIGN KEY (ID_SEDE) REFERENCES SEDE(ID_SEDE),
	CONSTRAINT FK_RELACION_DOCENTE_CEDULA FOREIGN KEY (CEDULA) REFERENCES USUARIO(CEDULA)
)
GO

CREATE TABLE HORARIO
(
	ID_HORARIO INT IDENTITY(1,1) NOT NULL,
	DIA VARCHAR(8) NOT NULL,
	HORAINICIO DATETIME NOT NULL,
	HORAFIN DATETIME NOT NULL,
	CONSTRAINT PK_ID_HORARIO PRIMARY KEY(ID_HORARIO),
)
GO

CREATE TABLE OFERTA_ACADEMICA
(
	ID_OFERTA INT IDENTITY(1,1) NOT NULL,
	NOMBREOFERTA VARCHAR(15) NOT NULL,
	ID_CURSO VARCHAR(10) NOT NULL,
	ID_SEDE INT NOT NULL,
	ID_CUATRIMESTRE INT NOT NULL,
	CEDULA_DOCENTE INT NOT NULL,
	A�O DATETIME NOT NULL,
	ID_HORARIO INT NOT NULL,
	GRUPO INT NOT NULL,
	ESTADO BIT NOT NULL,
	USUARIO INT NOT NULL,
	CONSTRAINT PK_ID_OFERTA PRIMARY KEY(ID_OFERTA),
	CONSTRAINT FK_CURSO_OFERTA_ACADEMICA FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO),
	CONSTRAINT FK_SEDE_OFERTA_ACADEMICA FOREIGN KEY (ID_SEDE) REFERENCES SEDE(ID_SEDE),
	CONSTRAINT FK_CUATRIMESTRE_OFERTA_ACADEMICA FOREIGN KEY (ID_CUATRIMESTRE) REFERENCES CUATRIMESTRE(ID_CUATRIMESTRE),
	CONSTRAINT FK_DOCENTE_OFERTA_ACADEMICA FOREIGN KEY (CEDULA_DOCENTE) REFERENCES USUARIO(CEDULA),
	CONSTRAINT FK_USUARIO_OFERTA_ACADEMICA FOREIGN KEY (USUARIO) REFERENCES USUARIO(CEDULA),
	CONSTRAINT FK_HORARIO_OFERTA_ACADEMICA FOREIGN KEY (ID_HORARIO) REFERENCES HORARIO(ID_HORARIO)
)
GO
-- CARGA DE DATOS.
/*
	INSERT INTO [dbo].[]([ ], [ ],[ ],[ ]) 
	VALUES ( ),
*/

-- VER TABLA
/*
	select*from ******
*/