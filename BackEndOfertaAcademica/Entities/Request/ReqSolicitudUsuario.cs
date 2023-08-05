using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities
{
    public class ReqSolicitudUsuario : ReqBase
    {
        public SolicitudUsuario solicitudUsuario { get; set; }
    }
}
