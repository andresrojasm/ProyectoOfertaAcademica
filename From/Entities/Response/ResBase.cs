using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From.Entities.Response
{
    public class ResBase
    {
        public bool result { get; set; }
        public List<String> listaDeErrores { get; set; }
    }
}
