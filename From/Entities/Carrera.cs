using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From.Entities
{
    public class Carrera
    {
        public string idCarrera { get; set; }
        public string nombre { get; set; }
        public int idFacultad { get; set; }
        public int idGrado { get; set; }
    }
}
