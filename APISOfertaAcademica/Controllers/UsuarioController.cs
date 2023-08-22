using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Logic;
using System.Web.Http;

namespace APISOfertaAcademica.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/usuario/5
        public ResObtenerNuevoUsuario Get(int id)
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            ReqObtenerNuevoUsuario request = new ReqObtenerNuevoUsuario();
            request.idDelUsuario = id;
            return logicUsuario.obtenerNuevoUsuario(request);
        }

        // POST api/usuario
        public ResNuevoUsuario Post([FromBody] ReqNuevoUsuario request)
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            return logicUsuario.nuevoUsuario(request);
        }

        // GET api/usuario
        public ResObtenerListaNuevoUsuario Get()
        {
            LogicUsuario logicUsuario = new LogicUsuario();
            ReqObtenerListaNuevoUsuario req = new ReqObtenerListaNuevoUsuario();
            return logicUsuario.obtenerListaNuevoUsuario(req);
        }
		
    }
}