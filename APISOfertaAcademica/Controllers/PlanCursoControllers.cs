using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BackEndOfertaAcademica.Logic;
using BackEndOfertaAcademica.Entities.Model;
using BackEndOfertaAcademica.Entities.Request;
using BackEndOfertaAcademica.Entities.Response;
using WebGrease.Activities;
using BackEndOfertaAcademica.Entities;

namespace APISOfertaAcademica.Controllers
{
    public class PlanCursoControllers : ApiController
    {
        public ResObtenerListaPlanCurso Get()
        {
            LogicPlanCurso logicPlanCurso = new LogicPlanCurso();   
            ReqObtenerListaPlanCurso request = new ReqObtenerListaPlanCurso();
            return logicPlanCurso.obtenerListaPlanCurso(request);
        }
        public ResPlanCurso nuevoPlanCurso([FromBody] ReqPlanCurso request)
        {
            LogicPlanCurso logicPlanCurso = new LogicPlanCurso();
            return logicPlanCurso.nuevaPC(request);
        }
    }
}