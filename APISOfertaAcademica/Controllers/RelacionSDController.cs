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
    public class RelacionSDController : ApiController
    {
        public ResRelacionSD nuevaRelacionSD([FromBody] ReqRelacionSD request)
        {
            LogicRelacionSD logicRelacionSD = new LogicRelacionSD();
            return logicRelacionSD.nuevaRelacionSD(request);
        }
    }

}