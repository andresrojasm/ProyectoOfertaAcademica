using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities
{
    public class Usuario
    {
        private int cedula { get; set; }
        private string nombre { get; set; }
        private string apellidos { get; set; }
        private int edad { get; set; }
        private string correo { get; set; }
        private string clave { get; set; }
        private string codigoDocente { get; set; }
        private SqlDateTime fechaCreacion { get; set; }
        private string rol { get; set; }
        private bool activo { get; set; }
    }
}
