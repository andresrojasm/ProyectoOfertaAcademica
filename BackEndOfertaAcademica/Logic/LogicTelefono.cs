using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities.Response;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    internal class LogicTelefono
    {
        public ResTelefono nuevaT(ReqTelefono request)
        {
            ResTelefono response = new ResTelefono();
            response.errorList = new List<string>();

            try
            {
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("El request esta nulo.");
                }
                else
                {
                    //Hacemos 
                    if (String.IsNullOrEmpty(request.telefono.idTelefono.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Id no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.telefono.numero.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Numero no ingresado");
                    }
                    if (String.IsNullOrEmpty(request.telefono.cedula.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Cedula de usuario no ingresada");
                    }
                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias  
                        int? cedulaBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP 
                        conexionLinq.NEW_PHONE(
                            request.telefono.numero,
                            request.telefono.cedula);

                        //Validacion de las acciones de la BASE DE DATOS

                        if (cedulaBD > 0)
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
            return response;
        }
    }
}
