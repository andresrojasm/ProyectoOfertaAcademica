using BackEndOfertaAcademica.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Entities
{
    public class ResObtenerListaCarreras : ResBase
    {
        public List<Carrera> listaCarrera { get; set; }
    }
}