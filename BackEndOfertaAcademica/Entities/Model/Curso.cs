using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities
{
    public class Curso
    {
        public string idCurso { get; set; }
        public string nombreCurso { get; set; }
        public int credito { get; set; }
        public int bloque { get; set; }
    }
}
