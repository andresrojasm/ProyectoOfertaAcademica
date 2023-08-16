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
    public class UsuarioController : ApiController
    {
        public ResNuevoUsuario Get()
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            ReqNuevoUsuario request = new ReqNuevoUsuario();
            return logicUsuario.nuevoUsuario(request);
        }
        public ResNuevoUsuario nuevoUsuario([FromBody] ReqNuevoUsuario request)
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            return logicUsuario.nuevoUsuario(request);
        }
    }
}