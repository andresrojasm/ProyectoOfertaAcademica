using BackEndOfertaAcademica.DataAccess;
using BackEndOfertaAcademica.Entities;
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

        public static List<Curso> fatoryListaCursos(List<GET_LISTA_CURSOSResult> rs)
        {
            Curso curso = new Curso();
            List<Curso> listaCursos = new List<Curso>();

            foreach (GET_LISTA_CURSOSResult cursos in rs)
            {
                
                curso.idCurso = cursos.ID_CURSO;
                cursos.NOMBRECURSO = cursos.NOMBRECURSO;
                curso.credito = cursos.CREDITO;
                curso.bloque = cursos.BLOQUE;

                listaCursos.Add(curso);
            }

            return listaCursos;
        }
    }
}