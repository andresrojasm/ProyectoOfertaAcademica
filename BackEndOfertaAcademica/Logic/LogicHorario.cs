using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicHorario
    {
        public ResObtenerListaHorarios obtenerListaHorarios(ReqObtenerListaHorarios req)
        {
            ResObtenerListaHorarios res = new ResObtenerListaHorarios();
            res.errorList = new List<string>();

            try
            {
                if (req == null)
                {
                    res.result = false;
                    res.errorList.Add("Request null");
                }
                else
                {
                    conexionLinqDataContext conexionLinq = new conexionLinqDataContext();
                    List<GET_HORARIOSResult> rs = conexionLinq.GET_HORARIOS().ToList();
                    res.horarios = Factory.factoryListaHorarios(rs);

                    res.result = true;
                }
            }
            catch (Exception ex)
            {
                res.result=false;
                res.errorList.Add(ex.ToString());
                
            }

            return res;
        }
    }
}