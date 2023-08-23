using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Entities.Model
{
    public class Carrera
    {
        public string idCarrera {  get; set; }
        public string nombreCarrera { get;set; }
        public int idFacultad { get; set; }
        public int idGrado { get; set; }
    }
}