using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BackEndOfertaAcademica.Logic;
using BackEndOfertaAcademica.Entities;
using WebGrease.Activities;

namespace APISOfertaAcademica.Controllers
{
    public class PlanCursoControllers : ApiController
    {
        public ResObtenerListaPlanCurso GET()
        {
            LogicPlanCurso logicPlanCurso = new LogicPlanCurso();   
            ReqObtenerListaPlanCurso request = new ReqObtenerListaPlanCurso();
            return logicPlanCurso.obtenerListaPlanCurso(request);
        }
        public ResPlanCurso POST([FromBody] ReqPlanCurso request)
        {
            LogicPlanCurso logicPlanCurso = new LogicPlanCurso();
            return logicPlanCurso.nuevaPC(request);
        }
    }
}