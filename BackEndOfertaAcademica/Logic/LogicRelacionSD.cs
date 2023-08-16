using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicRelacionSD
    {
        //Metodo para ingresar usuario nuevo (De front a Backend)
        public ResRelacionSD nuevaRelacionSD(ReqRelacionSD request)
        {
            ResRelacionSD response = new ResRelacionSD();
            response.errorList = new List<string>();

            try 
            {
                //Evaluamos el Request que viene desde el Front
                if(request == null)
                {
                    response.result = false;
                    response.errorList.Add("El request esta nulo.");
                }
                else
                {
                    if(request.relacionSD.idResd == 0) 
                    {
                        response.result = false;
                        response.errorList.Add("ID_SD no ingresado");
                    }
                    if(request.relacionSD.idSede == 0) 
                    {
                        response.result = false;
                        response.errorList.Add("ID_SEDE no ingresado");
                    }
                    if(request.relacionSD.cedula == 0) 
                    {
                        response.result = false;
                        response.errorList.Add("Cedula no ingresada");
                    }
                    if (!response.errorList.Any()) 
                    {
                        //Inicializamos las variables necesarias
                        int? idResdBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP
                        conexionLinq.NEW_SEDE_DOCENTE(
                            request.relacionSD.idSede,
                            request.relacionSD.cedula);

                        //Validacion de las acciones de la BASE DE DATOS

                        if (idResdBD > 0)
                        {
                            response.result = true;
                        }
                        else
                        {
                            response.result = false;
                            response.errorList.Add(listaErroresBD);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.result = false;
                response.errorList.Add(ex.ToString());
            }
            //Iria un finally si hay un log de errores

            return response;
        }
    }
}
