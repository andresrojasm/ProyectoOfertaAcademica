using BackEndOfertaAcademica.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities.Response
{
    public class ResObtenerRelacionSF: ResBase
    {
        public RelacionSedeFacultad RelacionSedeFacultad { get; set; }
    }
}
