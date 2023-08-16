﻿using System;
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
    public class RelacionCPControllers : ApiController
    {
        public ResRelacionCP Get()
        {
            LogicRelacionCP logicRelacionCP = new LogicRelacionCP();
            ReqRelacionCP request = new ReqRelacionCP();
            return logicRelacionCP.nuevaRelacionCP(request);
        }
        public ResRelacionCP nuevaRelacionCP([FromBody] ReqRelacionCP request)
        {
            LogicRelacionCP logicRelacionCP = new LogicRelacionCP();
            return logicRelacionCP.nuevaRelacionCP(request);
        }
    }
}