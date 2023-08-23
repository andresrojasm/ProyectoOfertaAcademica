using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
using BackEndOfertaAcademica.Entities.Model;
using System;
using System.Collections.Generic;

namespace BackEndOfertaAcademica.Utilities
{
    public class Factory
    {
        public static Usuario factoryLogin(USER_LOGINGResult login)
        {
            return createUser(login.CEDULA, login.NOMBRE, login.APELLIDOS, 0, "", "", DateTime.Now, login.ID_ROLLES, true);
        }

        public static Usuario factoryUsuario(GET_USUARIOResult rs)
        {
            return createUser(rs.CEDULA, rs.NOMBRE, rs.NOMBRE, rs.EDAD, rs.CORREO, rs.CODIGODOCENTE, 
                rs.FECHA, rs.ID_ROLLES, rs.ACTIVO) ;
        }

        public static List<Usuario> factoryListaUsuario(List<GET_LISTA_USUARIOSResult> rs)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            foreach (GET_LISTA_USUARIOSResult usuario in rs)
            {
                listaUsuarios.Add(createUser(usuario.CEDULA, usuario.NOMBRE, usuario.APELLIDOS, 
                    usuario.EDAD, usuario.CORREO, usuario.CODIGODOCENTE, usuario.FECHA, 
                    usuario.ID_ROLLES, usuario.ACTIVO));
            }

            return listaUsuarios;
        }

        private static Usuario createUser(int cedula, string nombre, string apellidos, int edad,
            string correo, string codigoDocente, DateTime fechaCreacion, int rol, bool activo)
        {
            Usuario usuario = new Usuario();
            usuario.cedula = cedula;
            usuario.nombre = nombre;
            usuario.apellidos = apellidos;
            usuario.edad = edad;
            usuario.correo = correo;
            usuario.codigoDocente = codigoDocente;
            usuario.fechaCreacion = fechaCreacion;
            usuario.rol =rol;
            usuario.activo = activo;

            return usuario;
        }

        public static List<Curso> factoryListaCursos(List<GET_LISTA_CURSOSResult> rs)
        {
            List<Curso> listaCursos = new List<Curso>();

            foreach (GET_LISTA_CURSOSResult cursos in rs)
            {
                Curso curso = new Curso();
                curso.idCurso = cursos.ID_CURSO;
                curso.nombreCurso = cursos.NOMBRECURSO;
                curso.credito = cursos.CREDITO;
                curso.bloque = cursos.BLOQUE;

                listaCursos.Add(curso);
            }

            return listaCursos;
        }

        public static List<OfertaAcademica> factoryListaOfertaAcademica(List<GET_LISTA_OFERTA_ACADEMICAResult> rs) {
            List<OfertaAcademica> listaOfertaAcademica = new List<OfertaAcademica>();
            foreach (GET_LISTA_OFERTA_ACADEMICAResult oferta in rs)
            {
                OfertaAcademica ofertaAcademica = new OfertaAcademica();
                ofertaAcademica.idOferta = oferta.ID_OFERTA;
                ofertaAcademica.idCurso = oferta.ID_CURSO;
                ofertaAcademica.idSede = oferta.ID_SEDE;
                ofertaAcademica.idCuatrimestre = oferta.ID_CUATRIMESTRE;
                ofertaAcademica.cedulaDocente = oferta.CEDULA_DOCENTE;
                ofertaAcademica.año = oferta.AÑO;
                ofertaAcademica.idHorario = oferta.ID_HORARIO;
                ofertaAcademica.grupo = oferta.GRUPO;
                ofertaAcademica.estado = oferta.ESTADO;
                ofertaAcademica.usuario = oferta.USUARIO;

                listaOfertaAcademica.Add(ofertaAcademica);
            }
            return listaOfertaAcademica;
        }
        public static List<Horario> factoryListaHorarios(List<GET_HORARIOSResult> rs)
        {
            List<Horario> listaHorarios = new List<Horario>();

            foreach (GET_HORARIOSResult horarios in rs)
            {
                Horario horario = new Horario();
                horario.idHorario = horarios.ID_HORARIO;
                horario.dia = horarios.DIA;
                horario.horaInicio = horarios.HORAINICIO;
                horario.horaFin = horarios.HORAFIN;

                listaHorarios.Add(horario);
            }

            return listaHorarios;
        }


        public static List<Carrera> factoryListaCarreras(List<GET_LISTA_CARRERASResult> rs)
        {
            List<Carrera> listaCarreras = new List<Carrera>();

            foreach (GET_LISTA_CARRERASResult carreras in rs)
            {
                Carrera carrera =   new Carrera();
                carrera.idCarrera = carreras.ID_CARRERA;
                carrera.nombreCarrera = carreras.NOMBRECARRERA;
                carrera.idFacultad = carreras.ID_GRADO;
                carrera.idGrado = carreras.ID_GRADO;

                listaCarreras.Add(carrera);
            }

            return listaCarreras;
        }

        public static List<PlanCurso> factoryListaPlanCurso(List<GET_LISTA_PLAN_CURSOResult> rs)
        {
            List<PlanCurso> listaPlanCurso = new List<PlanCurso>();

            foreach (GET_LISTA_PLAN_CURSOResult planesCursos in rs)
            {
                PlanCurso plan = new PlanCurso();
                plan.codigoPlan = planesCursos.CODIGOPLAN;
                plan.nombrePlan = planesCursos.NOMBREPLAN;
                plan.idCarrera = planesCursos.ID_CARRERA;

                listaPlanCurso.Add(plan);
            }
            return listaPlanCurso;
        }
    }
}