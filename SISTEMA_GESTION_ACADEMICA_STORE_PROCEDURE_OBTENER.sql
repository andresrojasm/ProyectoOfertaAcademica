USE SISTEMA_GESTION_ACADEMICA
GO

CREATE PROCEDURE GET_USUARIO @ID_USUARIO INT
AS BEGIN

	SELECT [CEDULA]
		  ,[NOMBRE]
		  ,[APELLIDOS]
		  ,[EDAD]
		  ,[CORREO]
		  ,[CODIGODOCENTE]
		  ,[FECHA]
		  ,[ID_ROLLES]
		  ,[ACTIVO]
	  FROM [dbo].[USUARIO]
	  WHERE CEDULA = @ID_USUARIO

END
GO

CREATE PROCEDURE GET_LISTA_USUARIOS
AS BEGIN

	SELECT [CEDULA]
		  ,[NOMBRE]
		  ,[APELLIDOS]
		  ,[EDAD]
		  ,[CORREO]
		  ,[CODIGODOCENTE]
		  ,[FECHA]
		  ,[ID_ROLLES]
		  ,[ACTIVO]
	  FROM [dbo].[USUARIO]

END
GO

CREATE PROCEDURE GET_HORARIOS
AS BEGIN

	SELECT [ID_HORARIO]
		,[DIA]
		,[HORAINICIO]
		,[HORAFIN]
	  FROM [dbo].[HORARIO]

END
GO

--Procedimiento almacenado saltandonos la verifiaion del plan, para efectos de simplicidad
CREATE PROCEDURE GET_LISTA_CURSOS @ID_CARRERA VARCHAR(15)
AS BEGIN

SELECT C.[ID_CURSO]
      ,[NOMBRECURSO]
      ,[CREDITO]
      ,[BLOQUE]
  FROM [dbo].[CURSO] C
	INNER JOIN [dbo].[RELACION_CURSO_PLAN] CP ON C.ID_CURSO = CP.ID_CURSO
	INNER JOIN [dbo].[PLAN_CURSO] P ON CP.CODIGOPLAN = P.CODIGOPLAN
  WHERE @ID_CARRERA = P.ID_CARRERA

END
GO

--EXEC GET_LISTA_CURSOS 'BISC'