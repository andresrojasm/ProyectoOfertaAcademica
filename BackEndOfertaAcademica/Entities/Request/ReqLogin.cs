using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Entities
{
    public class ReqLogin : ReqBase
    {
        public string correoDelUsuario { get; set; }
        public string claveDelUsuario { get; set; }
    }
}