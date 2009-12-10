using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de los perfiles
    /// </summary>
    class ConsultaPerfil:Consulta
    {
        /// <summary>
        /// Obtiene todos los perfiles
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getTodosPerfiles()
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, tipo, fechaActualizacion, IDFlujo from Perfil;");
            return dataReader;
        }

        /// <summary>
        /// Agrega un nuevo perfil
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipo"></param>
        public void insertPerfil(String nombre, String tipo){
            this.controladoBD.hacerConsultaEjecutor("insert into Perfil(nombre, tipo) values('"+nombre+"','"+tipo+"');");
        }

        /// <summary>
        /// Elimina un perfil
        /// </summary>
        /// <param name="IDPerfil"></param>
        public void deletePerfil(int IDPerfil)
        {
            this.controladoBD.hacerConsultaEjecutor("delete from Perfil where correlativo="+IDPerfil+";");
        }

        /// <summary>
        /// Selecciona un perfil por ID
        /// </summary>
        /// <param name="IDPerfil"></param>
        /// <returns></returns>
        public SqlDataReader selectPerfilPorID(int IDPerfil)
        {
            SqlDataReader dataReader = null;
            dataReader=this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, tipo, fechaActualizacion from Perfil where correlativo=" + IDPerfil + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene las colecciones
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <returns></returns>
        public SqlDataReader obtenerColecciones(int idPerfil) {
            return this.controladoBD.hacerConsultaEjecutor("select idColeccion from ColeccionAsignada where IDPerfil = " + idPerfil + ";");
        }

        /// <summary>
        /// ASigna una coleccion al perfil
        /// </summary>
        /// <param name="IDPerfil"></param>
        /// <param name="IDColeccion"></param>
        /// <returns></returns>
        public SqlDataReader asignarColeccion(int IDPerfil, int IDColeccion)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into ColeccionAsignada (IDPerfil, IDColeccion) values (" + IDPerfil + "," + IDColeccion + ");");
            return dataReader;
        }

        /// <summary>
        /// Desasigna la coleccion al perfil
        /// </summary>
        /// <param name="IDPerfil"></param>
        /// <param name="IDColeccion"></param>
        /// <returns></returns>
        public SqlDataReader desasignarColeccion(int IDPerfil, int IDColeccion)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("delete from ColeccionAsignada where IDPerfil=" + IDPerfil + " and IDColeccion=" + IDColeccion + ";");
            return dataReader;
        }

        /// <summary>
        /// Agrega la actividad a la tabla ActividadPermitida
        /// </summary>
        /// <param name="IDColeccion"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader permitirActividad(int IDColeccion, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into ActividadPermitida (IDColeccionAsignada, IDActividad) values (" + IDColeccion + "," + IDActividad + ");");
            return dataReader;
        }

        /// <summary>
        /// Indica la coleccion asignada al perfil
        /// </summary>
        /// <param name="IDColeccion"></param>
        /// <param name="IDPerfil"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader buscarColeccionEnPerfil(int IDColeccion, int IDPerfil, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select C.correlativo from ColeccionAsignada C, ActividadPermitida A where C.IDPerfil=" + IDPerfil + " and C.IDColeccion = " + IDColeccion + " and C.correlativo = A.IDColeccionAsignada and A.IDActividad = " + IDActividad + ";");
            return dataReader;
        }

    }
}
