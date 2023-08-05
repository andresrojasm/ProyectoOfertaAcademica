using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    internal class LogicaRelacionSedeFacultad
    {

        public ResRelacionSedeFacultad nuevaRelacionSedeFacultad (ReqRelacionSedeFAcultad request)
        {
            ResRelacionSedeFacultad response = new ResRelacionSedeFacultad ();
            response.errorList = new List<string> ();

            try
            {
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add ("El request de RelacionSedeFacultad es nulo");
                }
                else
                {
                    if (string.IsNullOrEmpty(request.RelacionSedeFacultad.idFacultad.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("");
                    }
                }
            }catch (Exception)
            {

            }

            return response;
        }

    }
}
