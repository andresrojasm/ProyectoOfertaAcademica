using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicUsuario
    {
        //Metodo para ingresar usuario nuevo (De front a Backend)
        public ResNuevoUsuario nuevoUsuario(ReqNuevoUsuario request)
        {
            ResNuevoUsuario response = new ResNuevoUsuario();
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
                    if (request.usuario.cedula == 0)
                    {
                        response.result = false;
                        response.errorList.Add("Cedula no ingresada");
                    }

                    if (String.IsNullOrEmpty(request.usuario.nombre))
                    {
                        response.result = false;
                        response.errorList.Add("Nombre no ingresado");
                    }

                    if (String.IsNullOrEmpty(request.usuario.apellidos))
                    {
                        response.result = false;
                        response.errorList.Add("Apellidos no ingresados");
                    }

                    if (String.IsNullOrEmpty(request.usuario.edad.ToString()))
                    {
                        response.result = false;
                        response.errorList.Add("Edad no ingresada");
                    }

                    if (String.IsNullOrEmpty(request.usuario.correo))
                    {
                        response.result = false;
                        response.errorList.Add("Correo no ingresado");
                    }

                    if (String.IsNullOrEmpty(request.usuario.clave))
                    {
                        response.result = false;
                        response.errorList.Add("Clave no ingresada");
                    }

                    if(request.usuario.rol== 0)
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
                        conexionLinq.NEW_USER(request.usuario.cedula,
                            request.usuario.nombre,
                            request.usuario.apellidos,
                            request.usuario.edad,
                            request.usuario.correo,
                            request.usuario.clave,
                            request.usuario.codigoDocente,
                            request.usuario.fechaCreacion,
                            request.usuario.rol,
                            request.usuario.activo);
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
                response.result=false;
                response.errorList.Add(ex.ToString());
            }
            //Iria un finally si hay un log de errores

            return response;
        }
    }
}
