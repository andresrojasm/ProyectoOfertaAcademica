using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    response.errorList.Add("Request null");
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

                    if (request.usuario.rol == 0)
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
                response.result = false;
                response.errorList.Add(ex.ToString());
            }
            //Iria un finally si hay un log de errores

            return response;
        }

        public ResObtenerNuevoUsuario obtenerNuevoUsuario(ReqObtenerNuevoUsuario req)
        {
            ResObtenerNuevoUsuario res = new ResObtenerNuevoUsuario();
            res.errorList = new List<string>();

            if (req == null)
            {
                res.result = false;
                res.errorList.Add("Request null");
            }
            else
            {
                if (req.idDelUsuario == 0)
                {
                    res.result = false;
                    res.errorList.Add("Id de usuario faltante");
                }

                if (!res.errorList.Any())
                {
                    conexionLinqDataContext conexionLinq = new conexionLinqDataContext();
                    List<GET_USUARIOResult> rs = conexionLinq.GET_USUARIO(req.idDelUsuario).ToList();

                    if (!rs.Any())
                    {
                        res.result =false;
                        res.errorList.Add("No hay ninguna coincidencia");
                    }
                    else
                    {
                        res.usuario = Factory.factoryUsuario(rs[0]);
                        res.result = true;
                    }
                }
            }

            return res;
        }

        public ResObtenerListaNuevoUsuario obtenerListaNuevoUsuario(ReqObtenerListaNuevoUsuario req)
        {
            ResObtenerListaNuevoUsuario res = new ResObtenerListaNuevoUsuario();
            res.errorList = new List<string>();

            if ( req == null)
            {
                res.result = false;
                res.errorList.Add("Request Null");
            }
            else
            {
                conexionLinqDataContext conexionLinq = new conexionLinqDataContext();
                List<GET_LISTA_USUARIOSResult> rs = new List<GET_LISTA_USUARIOSResult>();
                rs = conexionLinq.GET_LISTA_USUARIOS().ToList();
                res.listaUsuario = Factory.factoryListaUsuario(rs);

                res.result = true;
            }

            return res;
        }

        public ResLogin login(ReqLogin req)
        {
            ResLogin res = new ResLogin();
            res.errorList = new List<string>();

            if( req == null )
            {
                res.result = false;
                res.errorList.Add("Request null");
            }
            else
            {
                if (string.IsNullOrEmpty(req.correoDelUsuario))
                {
                    res.result = false;
                    res.errorList.Add("Correo faltante");
                }

                if (string.IsNullOrEmpty(req.claveDelUsuario))
                {
                    res.result = false;
                    res.errorList.Add("Clave faltante");
                }

                if(!res.errorList.Any())
                {
                    conexionLinqDataContext conexionLinq = new conexionLinqDataContext();
                    List<USER_LOGINGResult> rs = conexionLinq.USER_LOGING(req.correoDelUsuario, req.claveDelUsuario).ToList();

                    if(rs.Any())
                    {
                        res.result = true;
                        res.usuario = Factory.factoryLogin(rs[0]);
                    }
                    else
                    {
                        res.result = false;
                        res.errorList.Add("Credenciales no coiniden o se usuario esta inactivo");
                    }
                }
            }

            return res;
        }
    }
}
