--Trabajo Proyecto Final Programaci�n 5
/* Autores:
* Andres Rojas
* Ana Calvo
* Esteban Mora
* William Herrera*/
USE [SISTEMA_GESTION_ACADEMICA]
GO

/*EL NOMBRE REQUEST ES SOLO PARA TENAS DE SOLICITUD*/
CREATE PROCEDURE NEW_USER_REQUEST @CEDULA int ,@NOMBRE varchar(20),@APELLIDOS varchar(30),@EDAD int,@CORREO varchar(100),@CLAVE nvarchar(max),@CODIGODOCENTE varchar(10),@ID_ROLLES int
AS BEGIN

--STORE PROCEDURE PARA USUARIO(PARA EL BOTON DE REGISTRO)
IF NOT EXISTS(SELECT * FROM [dbo].[USUARIO] WHERE [CEDULA] = @CEDULA) BEGIN
	INSERT INTO [dbo].[USUARIO]([CEDULA],[NOMBRE],[APELLIDOS],[EDAD],[CORREO],[CLAVE],[CODIGODOCENTE],[FECHA],[ID_ROLLES],[ACTIVO])
     VALUES
           (@CEDULA,@NOMBRE,@APELLIDOS,@EDAD,@CORREO,@CLAVE,@CODIGODOCENTE,GETDATE(),@ID_ROLLES,0)
END
IF EXISTS(SELECT * FROM [dbo].[USUARIO] WHERE [CEDULA] = @CEDULA AND ACTIVO = 1) BEGIN
	PRINT 'USUARIO ACTIVO, SOLICITUD NO PROCEDE'
END
IF EXISTS(SELECT * FROM [dbo].[USUARIO] WHERE [CEDULA] = @CEDULA AND ACTIVO = 0) BEGIN
	INSERT INTO [dbo].[SOLICITUD_USUARIO]([CEDULA],[FECHA_SOLICITUD],[ID_ESTADO])
     VALUES (@CEDULA,GETDATE(),1) /*PENDIENTE = 1, ACEPTADO = 2, RECHAZADO = 3*/

	 PRINT 'USUARIO INACTIVO, SOLICITUD AGREGADA'
END
END
GO

--STORE PROCEDURE PARA DIRRECION
CREATE PROCEDURE NEW_ADDRESS @DIRECCION VARCHAR(150), @CEDULA INT
AS BEGIN
INSERT INTO [dbo].[DIRECCION]([DIRECCION],[CEDULA])
     VALUES (@DIRECCION,@CEDULA)
END
GO

--STORE PROCEDURE PARA TELEFONO
CREATE PROCEDURE NEW_PHONE @NUMERO INT, @CEDULA INT
AS BEGIN
INSERT INTO [dbo].[TELEFONO]([NUMERO],[CEDULA])
     VALUES (@NUMERO,@CEDULA)
END
GO

--STORE PROCEDURE PARA DOCENTE(PARA COORDINARDO)
CREATE PROCEDURE NEW_TEACHER @CEDULA INT, @NOMBRE VARCHAR(20), @APELLIDOS VARCHAR(30), @EDAD INT, @CORREO VARCHAR(100), @CLAVE nvarchar(max), @CODIGODOCENTE VARCHAR(10)
AS BEGIN
	IF EXISTS(SELECT * FROM [dbo].[USUARIO] WHERE CEDULA = @CEDULA) BEGIN
	PRINT 'EL DOCENTE EXISTE'
	END
	ELSE BEGIN
INSERT INTO [dbo].[USUARIO]([CEDULA],[NOMBRE],[APELLIDOS],[EDAD],[CORREO],[CLAVE],[CODIGODOCENTE],[FECHA],[ID_ROLLES],[ACTIVO])
     VALUES
           (@CEDULA,@NOMBRE,@APELLIDOS,@EDAD,@CORREO,@CLAVE,@CODIGODOCENTE,GETDATE(),3,1)
END
END
GO

--STORE PROCEDURE PARA CURSO
CREATE PROCEDURE NEW_SUBJECT @ID_CURSO VARCHAR(10),@NOMBRECURSO VARCHAR(20),@CREDITO INT,@BLOQUE INT
AS BEGIN
	IF EXISTS(SELECT * FROM [dbo].[CURSO] WHERE [ID_CURSO] = @ID_CURSO) BEGIN
	PRINT 'EL CURSO EXISTE'
	END
	ELSE BEGIN
INSERT INTO [dbo].[CURSO]([ID_CURSO],[NOMBRECURSO],[CREDITO],[BLOQUE])
     VALUES(@ID_CURSO, @NOMBRECURSO, @CREDITO,@BLOQUE)
END
END
GO

--STORE PROCEDURE PARA PLAN DE CURSO
CREATE PROCEDURE NEW_SUBJECTPLAN @CODIGOPLAN VARCHAR(10),@NOMBREPLAN VARCHAR(10),@ID_CARRERA INT
AS BEGIN
	IF EXISTS(SELECT * FROM [dbo].[PLAN_CURSO] WHERE CODIGOPLAN = @CODIGOPLAN) BEGIN
	PRINT 'EL PLAN CURSO EXISTE'
	END
	ELSE BEGIN
INSERT INTO [dbo].[PLAN_CURSO]([CODIGOPLAN],[NOMBREPLAN],[ID_CARRERA])
     VALUES(@CODIGOPLAN,@NOMBREPLAN,@ID_CARRERA)
END
END
GO

--STORE PROCEDURE PARA RELACION CURSO PLAN
CREATE PROCEDURE NEW_RCP @ID_CURSO VARCHAR(10),@CODIGOPLAN VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM RELACION_CURSO_PLAN WHERE ID_CURSO = @ID_CURSO AND CODIGOPLAN = @CODIGOPLAN)
    BEGIN
        INSERT INTO RELACION_CURSO_PLAN (ID_CURSO, CODIGOPLAN)
        VALUES (@ID_CURSO, @CODIGOPLAN);
    END
    ELSE
    BEGIN
        PRINT 'LA RELACI�N CURSO-PLAN YA EXISTE';
    END
END
GO



--STORE PROCEDURE PARA CARRERA
CREATE PROCEDURE NEW_CAREER @ID_CARRERA VARCHAR(15),@NOMBRECARRERA VARCHAR(15),@ID_FACULTAD INT,@ID_GRADO INT
AS BEGIN
	IF EXISTS(SELECT * FROM [dbo].[CARRERA] WHERE [ID_CARRERA] = @ID_CARRERA) BEGIN
	PRINT 'LA CARRERA EXISTE'
	END
	ELSE BEGIN
INSERT INTO [dbo].[CARRERA]([ID_CARRERA],[NOMBRECARRERA],[ID_FACULTAD],[ID_GRADO])
     VALUES(@ID_CARRERA,@NOMBRECARRERA,@ID_FACULTAD,@ID_GRADO)
END
END
GO

--STORE PROCEDURE PARA OFERTA ACADEMICA
CREATE PROCEDURE NEW_ACADEMICOFFER 
	@ID_CURSO VARCHAR(10),@ID_SEDE INT,@ID_CUATRIMESTRE INT,@CEDULA_DOCENTE INT,@A�O DATETIME,@ID_HORARIO INT,@GRUPO INT,@ESTADO BIT, @USUARIO INT
AS BEGIN
INSERT INTO [dbo].[OFERTA_ACADEMICA]([ID_CURSO],[ID_SEDE],[ID_CUATRIMESTRE],[CEDULA_DOCENTE],[A�O],[ID_HORARIO],[GRUPO],[ESTADO],[USUARIO])
     VALUES(@ID_CURSO,@ID_SEDE,@ID_CUATRIMESTRE,@CEDULA_DOCENTE,@A�O,@ID_HORARIO,@GRUPO,@ESTADO,@USUARIO)
END
GO

--STORE PROCEDURE PARA LOGING
/*
CREATE PROCEDURE NEW_LOGING @ID_USUARIO VARCHAR(20),@CLAVE NVARCHAR(MAX)
AS BEGIN
???????????????????????
INSERT INTO [dbo].[LOGING]([ID_USUARIO],[FECHA],[REGISTRO])
     VALUES(@ID_USUARIO,GETDATE(),1)
END
GO
*/

--STORE PROCEDURE PARA USAURIO (PARA PANTALLA DE ADMIN)
CREATE PROCEDURE NEW_USER @CEDULA int ,@NOMBRE varchar(20),@APELLIDOS varchar(30),@EDAD int,@CORREO varchar(100),@CLAVE nvarchar(max),@CODIGODOCENTE varchar(10),@FECHA datetime,@ID_ROLLES int,@ACTIVO bit
AS BEGIN
	IF EXISTS(SELECT * FROM [dbo].[USUARIO] WHERE CEDULA = @CEDULA) BEGIN
	PRINT 'EL USUARIO EXISTE'
	END
	ELSE BEGIN
INSERT INTO [dbo].[USUARIO]([CEDULA],[NOMBRE],[APELLIDOS],[EDAD],[CORREO],[CLAVE],[CODIGODOCENTE],[FECHA],[ID_ROLLES],[ACTIVO])
     VALUES
           (@CEDULA,@NOMBRE,@APELLIDOS,@EDAD,@CORREO,@CLAVE,@CODIGODOCENTE,@FECHA,@ID_ROLLES,0)
END
END
GO

 --STORE PROCEDURE PARA SOLICITUD USUARIO
CREATE PROCEDURE NEW_USUARIO_SOLICITUD
    @CEDULA INT,
    @FECHA_SOLICITUD DATETIME,
    @ID_ESTADO INT
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM SOLICITUD_USUARIO WHERE CEDULA = @CEDULA AND FECHA_SOLICITUD = @FECHA_SOLICITUD)
    BEGIN
        INSERT INTO SOLICITUD_USUARIO (CEDULA, FECHA_SOLICITUD, ID_ESTADO)
        VALUES (@CEDULA, @FECHA_SOLICITUD, @ID_ESTADO);
    END
    ELSE
    BEGIN
        PRINT 'LA SOLICITUD DE USUARIO YA EXISTE';
    END
END
GO

-----------------------------------------------
--STORE PROCEDURE PARA RELACION CURSO PLAN
CREATE PROCEDURE NEW_RCP @ID_CURSO VARCHAR(10),@CODIGOPLAN VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT 1 FROM RELACION_CURSO_PLAN WHERE ID_CURSO = @ID_CURSO AND CODIGOPLAN = @CODIGOPLAN)
    BEGIN
        INSERT INTO RELACION_CURSO_PLAN (ID_CURSO, CODIGOPLAN)
        VALUES (@ID_CURSO, @CODIGOPLAN);
    END
    ELSE
    BEGIN
        PRINT 'LA RELACI�N CURSO-PLAN YA EXISTE';
    END
END
GO

--STORE PROCEDURE PARA RELACION CURSO DOCENTE
CREATE PROCEDURE NEW_RCD @ID_RECD INT, @ID_CURSO VARCHAR, @CEDULA INT
AS BEGIN 
INSERT INTO [dbo].[RELACION_CURSO_DOCENTE]([ID_RECD],[ID_CURSO],[CEDULA])
     VALUES(@ID_RECD,@ID_CURSO,@CEDULA)
END
    BEGIN
        PRINT 'LA RELACI�N CURSO-DOCENTE YA EXISTE';
    END
GO

--STRONE PROCEDURE PARA RELACION SEDE DOCENTE
CREATE PROCEDURE NEW_SEDE_DOCENTE @ID_SEDE INT, @CEDULA INT
AS BEGIN
INSERT INTO [dbo].[RELACION_SEDE_DOCENTE]([ID_SEDE],[CEDULA])
     VALUES(@ID_SEDE,@CEDULA)
END
    BEGIN
        PRINT 'LA RELACI�N SEDE-DOCENTE YA EXISTE';
    END
GO