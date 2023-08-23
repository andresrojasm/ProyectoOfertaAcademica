using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace APISOfertaAcademica.Controllers
{
    public class CarreraController : ApiController
    {
        // GET: Carrera
        public ResObtenerListaCarreras Get()
        {
            LogicCarrera logicCarrera = new LogicCarrera();
            ReqObtenerListaCarreras request = new ReqObtenerListaCarreras();
            return logicCarrera.obtenerListaCarreras(request);
        }

        public ResCarrera Post([FromBody] ReqCarrera request)
        {
            LogicCarrera logicCarrera = new LogicCarrera();
            return logicCarrera.nuevaCarrera(request);
        }
    }
}