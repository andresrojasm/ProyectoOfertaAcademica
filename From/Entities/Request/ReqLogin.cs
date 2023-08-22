using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From.Entities.Request
{
    public class ReqLogin : ReqBase
    {
        public string correoDelUsuario { get; set; }
        public string claveDelUsuario { get; set; }
    }
}


