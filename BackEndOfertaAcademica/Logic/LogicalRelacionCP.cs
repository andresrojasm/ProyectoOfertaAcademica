using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Entities.Response;
using BackEndOfertaAcademica.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicRelacionCP
    {
        //Metodo para la relacion entre la tabla usuario/docente 
        public ResRelacionCP nuevaRCP(ReqRelacionCP request)
        {
            ResRelacionCP response = new ResRelacionCP();
            response.errorList = new List<string>();

            try
            {
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("El request esta nulo.");
                }
                else
                {
                    //Hacemos 
                    if (String.IsNullOrEmpty(request.relacionCP.idRecp.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Id no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.relacionCP.idCurso.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Id del curso no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.relacionCP.codigoPlan.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Cedula de usuario no ingresada");
                    }
                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias  
                        int? cedulaBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP 
                        conexionLinq.NEW_RCP(
                            request.relacionCP.idCurso,
                            request.relacionCP.codigoPlan);

                        /*
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
        PRINT 'LA RELACIÓN CURSO-PLAN YA EXISTE';
    END
END
GO
                         
                         */

                        //Validacion de las acciones de la BASE DE DATOS

                        if (cedulaBD > 0)
                        {
                            response.result = true;
                        }
                        else
                        {
                            response.result = false;
                            response.errorList.Add(listaErroresBD);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                response.result = false;
                response.errorList.Add(ex.ToString());
            }
            return response;
        }
    }
}
