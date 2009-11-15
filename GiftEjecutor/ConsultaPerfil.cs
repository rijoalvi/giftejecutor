using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace GiftEjecutor
{
    class ConsultaPerfil:Consulta
    {
        public SqlDataReader getTodosPerfiles()
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, tipo, fechaActualizacion, IDFlujo from Perfil;");
            return dataReader;
        }
        //no se agrega IDFlujo, porque no sé que es... luisk
        public void insertPerfil(String nombre, String tipo){
            this.controladoBD.hacerConsultaEjecutor("insert into Perfil(nombre, tipo) values('"+nombre+"','"+tipo+"');");
        }
        public void deletePerfil(int IDPerfil)
        {
            this.controladoBD.hacerConsultaEjecutor("delete from Perfil where correlativo="+IDPerfil+";");
        }
        public SqlDataReader selectPerfilPorID(int IDPerfil)
        {
            SqlDataReader dataReader = null;
            dataReader=this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, tipo, fechaActualizacion from Perfil where correlativo=" + IDPerfil + ";");
            return dataReader;
        }

        public SqlDataReader asignarColeccion(int IDPerfil, int IDColeccion)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into ColeccionAsignada (IDPerfil, IDColeccion) values (" + IDPerfil + "," + IDColeccion + ");");
            return dataReader;
        }
        public SqlDataReader desasignarColeccion(int IDPerfil, int IDColeccion)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("delete from ColeccionAsignada where IDPerfil=" + IDPerfil + " and IDColeccion=" + IDColeccion + ";");
            return dataReader;
        }
        public SqlDataReader permitirActividad(int IDColeccion, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("insert into ActividadPermitida (IDColeccionAsignada, IDActividad) values (" + IDColeccion + "," + IDActividad + ");");
            return dataReader;
        }

        public SqlDataReader buscarColeccionEnPerfil(int IDColeccion, int IDPerfil, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select C.correlativo from ColeccionAsignada C, ActividadPermitida A where C.IDPerfil=" + IDPerfil + " and C.IDColeccion = " + IDColeccion + " and C.IDColeccion = A.IDColeccionAsignada and A.IDActividad = " + IDActividad + ";");
            return dataReader;
        }


    }
}
