using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Logic;
using System.Web.Http;

namespace APISOfertaAcademica.Controllers
{
    public class LoginController : ApiController
    {

        public ResLogin Post([FromBody] ReqLogin req)
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            return logicUsuario.login(req);
        }
    }
}