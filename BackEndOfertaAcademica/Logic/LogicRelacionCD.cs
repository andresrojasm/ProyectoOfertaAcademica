using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicRelacionCD
    {
        //Metodo para la relacion entre la tabla usuario/docente 
        public ResRelacionCD nuevaRelacionCD(ReqRelacionCD request)
        {
            ResRelacionCD response = new ResRelacionCD();
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
                    if (String.IsNullOrEmpty(request.relacionCD.id.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Id no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.relacionCD.idCurso.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Id del curso no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.relacionCD.cedula.ToString()))
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
                        conexionLinq.SP_RELACION_CD(request.relacionCD.id,
                            request.relacionCD.idCurso,
                            request.relacionCD.cedula);

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
