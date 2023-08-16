using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicPlanCurso
    {
        //Metodo para ingresar el plan de curso
        public ResPlanCurso nuevaPC(ReqPlanCurso request)
        {
            ResPlanCurso response = new ResPlanCurso();
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
                    if (String.IsNullOrEmpty(request.planCurso.codigoPlan))
                    {
                        response.result = false;
                        response.errorList.Add("Id del plan de curso no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.planCurso.nombrePlan))
                    {
                        response.result = false;
                        response.errorList.Add("Nombre del plan no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.planCurso.idCarrera))
                    {
                        response.result = false;
                        response.errorList.Add("Id del curso no ingresada");
                    }
                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias  
                        int? cedulaBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP 
                        conexionLinq.sp_ActualizarPlanCurso(request.planCurso.codigoPlan,
                            request.planCurso.nombrePlan,
                            request.planCurso.idCarrera);

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

        public ResObtenerPlanCurso obtenerPlanCurso(ReqObtenerPlanCurso request)
        {
            ResObtenerPlanCurso response = new ResObtenerPlanCurso();

            if (request == null)
            {
                response.result = false;
                response.errorList.Add("Request null");
            }
            else
            {
                if (request.idDePlanCurso == 0)
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
        public ResObtenerListaPlanCurso obtenerListaPlanCurso(ReqObtenerListaPlanCurso request)
        {
            ResObtenerListaPlanCurso response = new ResObtenerListaPlanCurso();

            if (request == null)
            {
                response.result = false;
                response.errorList.Add("Request null");
            }
            else
            {/*
                conexionLinqDataContext miLinq = new conexionLinqDataContext();
                List<SP_OBTENER_LISTAUSUARIOSResult> listaTipoComplejo = miLinq.SP_OBTENER_LISTAUSUARIOS().ToList();

                foreach (SP_OBTENER_LISTAUSUARIOSResult cadaTipoComplejo in listaTipoComplejo)
                {
                    res.listaDeUsuarios.Add(Factory.miFactoryDeUsuarioParaLista(cadaTipoComplejo));
                }
                */
            }
            return response;
        }
    }
}
