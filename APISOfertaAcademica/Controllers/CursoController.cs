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
    public class CursoController : ApiController
    {
        public ResCurso nuevoCurso([FromBody] ReqCurso request)
        {
            LogicCurso logicCurso = new LogicCurso();
            return logicCurso.nuevoCurso(request);
        }
    }
   
}