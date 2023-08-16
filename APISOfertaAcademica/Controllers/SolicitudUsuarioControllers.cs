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
    public class SolicitudUsuarioControllers : ApiController
    {
        public ResSolicitudUsuario Get()
        {
            LogicSolicitudUsuario logicalSolicitudUsuario = new LogicSolicitudUsuario();
            ReqSolicitudUsuario request = new ReqSolicitudUsuario();
            return logicalSolicitudUsuario.nuevoSolicitudUsuario(request);
        }
        public ResSolicitudUsuario nuevoSolicitudUsuario([FromBody] ReqSolicitudUsuario request)
        {
            LogicSolicitudUsuario logicalSolicitudUsuario = new LogicSolicitudUsuario(); 
                return logicalSolicitudUsuario.nuevoSolicitudUsuario (request);
        }
    }
}