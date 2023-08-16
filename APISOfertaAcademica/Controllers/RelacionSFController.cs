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
    public class RelacionSFController : ApiController
    {
        public ResRelacionSedeFacultad Get()
        {
            LogicaRelacionSedeFacultad logicRelacionSF = new LogicaRelacionSedeFacultad();
            ReqRelacionSedeFAcultad request = new ReqRelacionSedeFAcultad();
            return logicRelacionSF.nuevaRelacionSedeFacultad(request);
        }
        public ResRelacionSedeFacultad nuevaRelacionSedeFacultad([FromBody] ReqRelacionSedeFAcultad request)
        {
            LogicaRelacionSedeFacultad logicRelacionSF = new LogicaRelacionSedeFacultad();
            return logicRelacionSF.nuevaRelacionSedeFacultad(request);
        }
    }

}