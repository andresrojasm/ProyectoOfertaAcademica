﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities.Response
{
    public class ResObtenerOfertaAcademica: ResBase
    {
        public OfertaAcademica ofertaAcademica { get; set; }
    }
}
