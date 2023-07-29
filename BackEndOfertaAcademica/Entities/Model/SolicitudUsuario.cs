using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities
{
    public class SolicitudUsuario
    {
        public int idSolicitudUsuario { get; set; }
        public int cedula { get; set; }
        public SqlDateTime fechaSolicitud { get; set; }
        public int idEstado { get; set; }
    }
}