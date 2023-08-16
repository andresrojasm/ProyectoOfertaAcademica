using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicOfertaAcademica
    {
        //Metodo para ingresar usuario nuevo (De front a Backend)
        public ResOfertaAcademica nuevaOfertaAcademica(ReqOfertaAcademica request)
        {
            ResOfertaAcademica response = new ResOfertaAcademica();
            response.errorList = new List<string>();

            try
            {
                //Evaluamos el Request que viene desde el Front
                if (request == null)
                {
                    response.result = false;
                    response.errorList.Add("El request esta nulo.");
                }
                else
                {
                    if (request.ofertaAcademica.idOferta == 0)
                    {
                        response.result = false;
                        response.errorList.Add("ID_OFERTA no ingresado");
                    }
                    if (String.IsNullOrEmpty(request.ofertaAcademica.nombreOferta))
                    {
                        response.result = false;
                        response.errorList.Add("NOMBREOFERTA no ingresada");
                    }
                    if (String.IsNullOrEmpty(request.ofertaAcademica.idCurso))
                    {
                        response.result = false;
                        response.errorList.Add("ID_CURSO no ingresado");
                    }
                    if (request.ofertaAcademica.idSede == 0)
                    {
                        response.result = false;
                        response.errorList.Add("ID_SEDE no ingresado");
                    }
                    if (request.ofertaAcademica.idCuatrimestre == 0)
                    {
                        response.result = false;
                        response.errorList.Add("ID_CUATRIMESTRE no ingresado");
                    }
                    if (request.ofertaAcademica.cedulaDocente == 0)
                    {
                        response.result = false;
                        response.errorList.Add("CEDULA_DOCENTE no ingresado");
                    }
                    if (request.ofertaAcademica.idHorario == 0)
                    {
                        response.result = false;
                        response.errorList.Add("ID_HORARIO no ingresado");
                    }
                    if (request.ofertaAcademica.grupo == 0)
                    {
                        response.result = false;
                        response.errorList.Add("GRUPO no ingresado");
                    }
                    if (request.ofertaAcademica.usuario == 0)
                    {
                        response.result = false;
                        response.errorList.Add("USUARIO no ingresado");
                    }
                    if (!response.errorList.Any())
                    {
                        //Inicializamos las variables necesarias
                        string idResdBD = null;
                        string listaErroresBD = "";
                        //Instancia LINQ
                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext();

                        //Uso del SP
                        conexionLinq.sp_ActualizarOfertaAcademica(request.ofertaAcademica.idOferta,
                            request.ofertaAcademica.nombreOferta,
                            request.ofertaAcademica.idCurso,
                            request.ofertaAcademica.idSede,
                            request.ofertaAcademica.idCuatrimestre,
                            request.ofertaAcademica.cedulaDocente,
                            request.ofertaAcademica.año,
                            request.ofertaAcademica.idHorario,
                            request.ofertaAcademica.grupo,
                            request.ofertaAcademica.estado,
                            request.ofertaAcademica.usuario);

                        //Validacion de las acciones de la BASE DE DATOS
                        if (idResdBD == null)
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

        public ResObtenerOfertaAcademica obtenerOfertaAcademica(ReqObtenerOfertaAcademica request)
        {
            ResObtenerOfertaAcademica response = new ResObtenerOfertaAcademica();

            if (request == null)
            {
                response.result = false;
                response.errorList.Add("Request null");
            }
            else
            {
                if (request.idDeOfertaAcademica == 0)
                {
                    response.result = false;
                    response.errorList.Add("Id usuario faltante");
                }
                if (String.IsNullOrEmpty(request.session))
                {
                    response.result = false;
                    response.errorList.Add("Session faltante");
                }
                if (!response.errorList.Any())
                {
                    /*
                    conexionLinqDataContext miLinq = new conexionLinqDataContext();
                    SP_OBTENER_USUARIOResult miTipoComplejo = (SP_OBTENER_USUARIOResult)miLinq.SP_OBTENER_USUARIO(req.idDelUsuario);
                    res.elUsuario = Factory.miFactoryDeUsuario(miTipoComplejo);*/
                }
            }
            return response;
        }
        public ResObtenerListaOfertaAcademica obtenerListaOfertaAcademica(ReqObtenerListaOfertaAcademica request)
        {
            ResObtenerListaOfertaAcademica response = new ResObtenerListaOfertaAcademica();

            if (request == null)
            {
                response.result = false;
                response.errorList.Add("Request null");
            }
            else
            {/*
                conexionLinqDataContext miLinq = new conexionLinqDataContext();
                List<SP_OBTENER_LISTAUSUARIOSResult> listaTipoComplejo = miLinq.SP_OBTENER_LISTAUSUARIOS().ToList();

                foreach (SP_OBTENER_LISTAUSUARIOSResult cadaTipoComplejo in listaTipoComplejo)
                {
                    res.listaDeUsuarios.Add(Factory.miFactoryDeUsuarioParaLista(cadaTipoComplejo));
                }
                */
            }
            return response;
        }
    }
}
