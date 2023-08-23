using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Logic;
using System.Web.Http;

namespace APISOfertaAcademica.Controllers
{
    public class CursoController : ApiController
    {
        public ResObtenerListaCurso Get(string idCarrera)
        {
            LogicCurso logicCurso = new LogicCurso();
            ReqObtenerListaCurso request = new ReqObtenerListaCurso();
            request.idCarrera = idCarrera;
            return logicCurso.obtenerListaCurso(request);
        }
        public ResCurso nuevoCurso([FromBody] ReqCurso request)
        {
            LogicCurso logicCurso = new LogicCurso();
            return logicCurso.nuevoCurso(request);
        }
    }
   
}