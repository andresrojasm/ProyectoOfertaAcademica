using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    internal class LogicSolicitudUsuario
    {
        //Metodo para ingresar una solicitud de usuario nuevo (De front a Backend)
        public ResSolicitudUsuario nuevoSolicitudUsuario(ReqSolicitudUsuario request)
        {
            ResSolicitudUsuario response = new ResSolicitudUsuario();
            response.errorList = new List<string>();

            try
            {
                //Evaluamos el Request que viene desde el Front
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("re");
                }
                else
                {
                    if (request.solicitudUsuario.idSolicitudUsuario == 0)
                    {
                        response.result = false;
                        response.errorList.Add("Id de usuario no ingresada");
                    }

                    if (String.IsNullOrEmpty(request.solicitudUsuario.cedula))
                    {
                        response.result = false;
                        response.errorList.Add("Cedula no ingresado");
                    }

                    if (String.IsNullOrEmpty(request.solicitudUsuario.idEstado))
                    {
                        response.result = false;
                        response.errorList.Add("Rol no ingresado");
                    }

                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias
                        int? cedulaBD = 0;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP
                        conexionLinq.NEW_USER(request.solicitudUsuario.cedula,
                            request.solicitudUsuario.nombre,
                            request.solicitudUsuario.apellidos,
                            request.solicitudUsuario.edad,
                            request.solicitudUsuario.correo,
                            request.solicitudUsuario.clave,
                            request.solicitudUsuario.codigoDocente,
                            request.solicitudUsuario.rol,
                            request.solicitudUsuario.activo;
                        // ref cedulaBD,
                        // ref listaErroresBD)

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
            //Iria un finally si hay un log de errores

            return response;
        }
    }
}
