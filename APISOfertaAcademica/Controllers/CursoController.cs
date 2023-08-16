using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BackEndOfertaAcademica.Logic;
using WebGrease.Activities;
using BackEndOfertaAcademica.Entities;

namespace APISOfertaAcademica.Controllers
{
    public class CursoController : ApiController
    {
        public ResObtenerListaCurso Get()
        {
            LogicCurso logicCurso = new LogicCurso();
            ReqObtenerListaCurso request = new ReqObtenerListaCurso();
            return logicCurso.obtenerListaCurso(request);
        }
        public ResCurso nuevoCurso([FromBody] ReqCurso request)
        {
            LogicCurso logicCurso = new LogicCurso();
            return logicCurso.nuevoCurso(request);
        }
    }
   
}