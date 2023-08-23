using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Entities
{
    public class Horario
    {
        public int idHorario {  get; set; }
        public string dia { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set;}
    }
}