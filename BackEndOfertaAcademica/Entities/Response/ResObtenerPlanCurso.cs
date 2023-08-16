using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities.Response
{
    public class ResObtenerPlanCurso: ResBase
    {
        public PlanCurso planCurso { get; set; }
    }
}
