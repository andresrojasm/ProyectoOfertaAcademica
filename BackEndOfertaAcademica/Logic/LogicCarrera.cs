using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndOfertaAcademica.Logic
{
    public class LogicCarrera
    {
        public ResCarrera nuevaCarrera (ReqCarrera req)
        {
            ResCarrera res = new ResCarrera ();
            res.errorList = new List<string> ();

            try
            {
                if (req == null)
                {
                    res.result = false;
                    res.errorList.Add("Request Null");
                }
                else
                {
                    if (string.IsNullOrEmpty(req.carrera.idCarrera))
                    {
                        res.result = false;
                        res.errorList.Add("Id Carrera no ingresado");
                    }

                    if (string.IsNullOrEmpty(req.carrera.nombreCarrera))
                    {
                        res.result = false;
                        res.errorList.Add("Nombre de carrera no ingresado");
                    }
                    if (req.carrera.idFacultad == 0)
                    {
                        res.result = false;
                        res.errorList.Add("Id de facultad no ingresado");
                    }
                    if(req.carrera.idGrado == 0)
                    {
                        res.result = false;
                        res.errorList.Add("Id de Gradfo no ingresado");
                    }
                    if (!res.errorList.Any())
                    {
                        int? idCarreraBD = 0;
                        string listaErrorBD = "";

                        conexionLinqDataContext conexionLinq = new conexionLinqDataContext ();

                        idCarreraBD= conexionLinq.NEW_CAREER(req.carrera.idCarrera,
                            req.carrera.nombreCarrera,
                            req.carrera.idFacultad,
                            req.carrera.idGrado);

                        if (idCarreraBD > 0)
                        {
                            res.result = true;
                        }
                        else
                        {
                            res.result = false;
                            res.errorList.Add(listaErrorBD);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.result = false;
                res.errorList.Add(ex.ToString());
            }

            return res;
        }
        public ResObtenerListaCarreras obtenerListaCarreras (ReqObtenerListaCarreras req)
        {
            ResObtenerListaCarreras res = new ResObtenerListaCarreras ();
            res.errorList = new List<string> ();

            try
            {
                if (req == null)
                {
                    res.result = false;
                    res.errorList.Add("Request null");
                }
                else
                {
                    conexionLinqDataContext conexionLinq = new conexionLinqDataContext ();
                    List<GET_LISTA_CARRERASResult> rs;
                    rs = conexionLinq.GET_LISTA_CARRERAS().ToList ();
                    res.listaCarrera = Factory.factoryListaCarreras(rs);

                    res.result = true;
                }
            }
            catch ( Exception ex)
            {
                res.result = false;
                res.errorList.Add (ex.Message);
            }
            return res;
        }
    }
}