﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Entities
{
    public class Usuario
    {
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string codigoDocente { get; set; }
        public SqlDateTime fechaCreacion { get; set; }
        public string rol { get; set; }
        public bool activo { get; set; }
    }
}
