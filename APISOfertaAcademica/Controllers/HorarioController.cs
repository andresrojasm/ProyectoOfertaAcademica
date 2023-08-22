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
    public class HorarioController : ApiController
    {
        public ResObtenerListaHorarios Get()
        {
            LogicHorario logicHorario = new LogicHorario();
            ReqObtenerListaHorarios request = new ReqObtenerListaHorarios();
            return logicHorario.obtenerListaHorarios(request);
        }
    }
}
