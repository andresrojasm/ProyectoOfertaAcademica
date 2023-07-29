using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicCurso
    {
        //Metodo para ingresar usuario nuevo (De front a Backend)
        public ResCurso nuevoCurso(ReqCurso request)
        {
            ResCurso response = new ResCurso();
            response.errorList = new List<string>();

            try
            {
                //Evaluamos el Request que viene desde el Front
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("El request esta nulo.");
                }
                else
                {
                    if (String.IsNullOrEmpty(request.curso.idCurso))
                    {
                        response.result = false;
                        response.errorList.Add("ID_CURSO no ingresado");
                    }
                    if (String.IsNullOrEmpty(request.curso.nombreCurso))
                    {
                        response.result = false;
                        response.errorList.Add("NOMBRECURSO no ingresado");
                    }
                    if (request.curso.credito == 0)
                    {
                        response.result = false;
                        response.errorList.Add("CREDITO no ingresado");
                    }
                    if (request.curso.bloque == 0)
                    {
                        response.result = false;
                        response.errorList.Add("BLOQUE no ingresado");
                    }
                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias
                        int? idResdBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP
                        conexionLinq.NEWCURSO(request.curso.idCurso,
                            request.curso.nombreCurso,
                            request.curso.credito,
                            request.curso.bloque);

                        //Validacion de las acciones de la BASE DE DATOS
                        if (idCurso > 0)
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
            //Iria un finally si hay un log de errores

            return response;
        }
    }
}
