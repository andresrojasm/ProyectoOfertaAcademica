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
    public class TelefonoController : ApiController
    {
        public ResTelefono Get()
        { 
            LogicTelefono logicTelefono = new LogicTelefono();
            ReqTelefono request = new ReqTelefono();
            return logicTelefono.nuevoTelefono(request);
        }
        public ResTelefono nuevoTelefono([FromBody] ReqTelefono request)
        {
            LogicTelefono logicTelefono = new LogicTelefono();
            return logicTelefono.nuevoTelefono(request);
        }
    }
}