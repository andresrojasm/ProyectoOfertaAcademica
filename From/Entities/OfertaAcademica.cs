using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From.Entities
{
    public class OfertaAcademica
    {
        public int idOferta { get; set; }
        public string idCurso { get; set; }
        public int idSede { get; set; }
        public int idCuatrimestre { get; set; }
        public int cedulaDocente { get; set; }
        public DateTime año { get; set; }
        public int idHorario { get; set; }
        public int grupo { get; set; }
        public bool estado { get; set; }
        public int usuario { get; set; }
    }
}
