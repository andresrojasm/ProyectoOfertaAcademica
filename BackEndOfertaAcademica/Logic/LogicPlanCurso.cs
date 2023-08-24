using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Utilities;
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
                        string idResBD = null;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP 
                        conexionLinq.sp_ActualizarPlanCurso(request.planCurso.codigoPlan,
                            request.planCurso.nombrePlan,
                            request.planCurso.idCarrera);

                        //Validacion de las acciones de la BASE DE DATOS

                        if (idResBD == null)
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

        public ResObtenerListaPlanCurso obtenerListaPlanCurso(ReqObtenerListaPlanCurso request)
        {
            ResObtenerListaPlanCurso response = new ResObtenerListaPlanCurso();
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
                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    List<GET_LISTA_PLAN_CURSOResult> rs;
                    rs = miLinq.GET_LISTA_PLAN_CURSO().ToList();
                    response.listaPlanCurso = Factory.factoryListaPlanCurso(rs);
                    response.result = true;
                }
            }catch (Exception ex) { 
                response.result = false; 
                response.errorList.Add(ex.ToString());
            }
            return response;
        }
    }
}
