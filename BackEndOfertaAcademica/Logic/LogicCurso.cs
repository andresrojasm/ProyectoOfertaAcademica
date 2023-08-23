using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

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
                        string idResdBD = null;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP
                        conexionLinq.sp_ActualizarCurso(request.curso.idCurso,
                            request.curso.nombreCurso,
                            request.curso.credito,
                            request.curso.bloque);

                        //Validacion de las acciones de la BASE DE DATOS
                        if (idResdBD == null)
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

        public ResObtenerCurso obtenerCurso(ReqObtenerCurso request)
        {
            ResObtenerCurso response = new ResObtenerCurso();

            if (request == null)
            {
                response.result = false;
                response.errorList.Add("Request null");
            }
            else
            {
                if (request.idDelCurso == 0)
                {
                    response.result = false;
                    response.errorList.Add("Id usuario faltante");
                }
                if (String.IsNullOrEmpty(request.session))
                {
                    response.result = false;
                    response.errorList.Add("Session faltante");
                }
                if (!response.errorList.Any())
                {
                    /*
                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    SP_OBTENER_USUARIOResult miTipoComplejo = (SP_OBTENER_USUARIOResult)miLinq.SP_OBTENER_USUARIO(req.idDelUsuario);
                    res.elUsuario = Factory.miFactoryDeUsuario(miTipoComplejo);*/
                }
            }
            return response;
        }
        public ResObtenerListaCurso obtenerListaCurso(ReqObtenerListaCurso request)
        {
            ResObtenerListaCurso response = new ResObtenerListaCurso();
            response.errorList = new List<string>();
            try
            {
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("Request null");
                }
                else
                {
                    if (string.IsNullOrEmpty(request.idCarrera))
                    {
                        response.result = false;
                        response.errorList.Add("No se indico la Carrera correspondiente");
                    }
                    if (!response.errorList.Any())
                    {
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();
                        List<GET_LISTA_CURSOSResult> rs = conexionLinq.GET_LISTA_CURSOS(request.idCarrera).ToList();
                        response.listaCurso = Factory.factoryListaCursos(rs);

                        response.result = true;
                    }
                }
            } catch (Exception ex)
            {
                response.result = false;
                response.errorList.Add($"{ex.Message}");
            }
            return response;
        }
    }


}
