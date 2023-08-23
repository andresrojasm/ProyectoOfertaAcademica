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
    public class OfertaAcademicaController : ApiController
    {

        public ResObtenerListaOfertaAcademica Get()
        {
            LogicOfertaAcademica logicOfertaAcademica = new LogicOfertaAcademica();
            ReqObtenerListaOfertaAcademica request = new ReqObtenerListaOfertaAcademica();
            return logicOfertaAcademica.obtenerListaOfertaAcademica(request);
        }
        public ResOfertaAcademica Post([FromBody] ReqOfertaAcademica request)
        {
            LogicOfertaAcademica logicOfertaAcademica = new LogicOfertaAcademica();
            return logicOfertaAcademica.nuevaOfertaAcademica(request);
        }
    }
}