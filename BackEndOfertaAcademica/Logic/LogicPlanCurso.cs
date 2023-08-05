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
                        conexionLinq.NEW_PC(request.planCurso.codigoPlan,
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
    }
}
