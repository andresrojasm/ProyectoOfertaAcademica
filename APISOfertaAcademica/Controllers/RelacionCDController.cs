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
    public class RelacionCDController : ApiController
    {
        public ResRelacionCD Get()
        {
            LogicRelacionCD logicRelacionCD = new LogicRelacionCD();
            ReqRelacionCD request = new ReqRelacionCD();
            return logicRelacionCD.nuevaRelacionCD(request);
        }
        public ResRelacionCD nuevaRelacionCD([FromBody] ReqRelacionCD request)
        {
            LogicRelacionCD logicRelacionCD = new LogicRelacionCD();
            return logicRelacionCD.nuevaRelacionCD(request);
        }
    }

}