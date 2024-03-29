﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de las colecciones
    /// </summary>
    class ConsultaColeccion : Consulta
    {
                
        /// <summary>
        /// Crea una colección
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="correlativoPadre"></param>
        /// <param name="correlativoFlujo"></param>
        /// <returns>Si se retorna un -1 indica que no se pudo crear debido a que ya existia una coleccion con ese nombre en esa Coleccion</returns>
        public int crearColeccion(String nombre, int correlativoPadre, int correlativoFlujo){
            int correlativo = -1;
            String consulta = "Select correlativo From COLECCION where nombre = '" + nombre +
                               "' AND correlativoPadre = " + correlativoPadre + ";";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);

            if (!resultado.Read())
            {
                consulta = "INSERT INTO COLECCION ( nombre, correlativoPadre, correlativoFlujo) VALUES ('" +
                    nombre + "'," + correlativoPadre + ","+ correlativoFlujo +"); SELECT correlativo FROM COLECCION WHERE nombre = '" + nombre + "' AND correlativoPadre = " + correlativoPadre + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                resultado.Read();
                correlativo = int.Parse(resultado.GetValue(0).ToString());
            }
            return correlativo;
        }


        /// <summary>
        /// Obtiene las colecciones hijas
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public String[] coleccionesHijas(String nombre/*, String nombrePadre*/) { 
            /*Consulta = "SELECT nombre FROM COLECCION c1 where c1.correlativoPadre = "+
                       "(SELECT correlativo FROM COLECCION c2 where c2.nombre = '"+ nombre+"' AND "       
                        +"c2.correlativo" +nombre = '"+nombre+"' AND "+*/
            
            /***********************AVERIGUAR CORRELATIVO DEL PADRE *******************************/
            
            String consulta = "SELECT correlativo FROM COLECCION where nombre = '" + nombre + "'";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            
            String []hijos = null;
            
            if( nombre == "raiz" || (resultado.IsClosed && resultado.Read())){
                int correlativo=0;
                if(nombre!="raiz")
                    correlativo = int.Parse(resultado.GetValue(0).ToString());


                /***********************AVERIGUAR CUANTOS SON *******************************/
                consulta = "SELECT count(*) FROM COLECCION where correlativoPadre = " + correlativo + ";";
                resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                if(resultado.Read()){


                    hijos = new String[int.Parse(resultado.GetValue(0).ToString())];
                    consulta = "SELECT nombre FROM COLECCION where correlativoPadre = " +correlativo+ "";
                    resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
                
                         
                    int i =0;
                    while(resultado.Read()){
                        hijos[i] = resultado.GetValue(0).ToString();
                        i++;            
                    }
                }
            }else if(nombre == "raiz"){
                
            
            }
            return hijos;
        }

        /// <summary>
        /// Modifica el nombre
        /// </summary>
        /// <param name="IDCorrelativo"></param>
        /// <param name="nombre"></param>
        public void modificarNombre(int IDCorrelativo, String nombre) {
            String consulta = "UPDATE COLECCION SET nombre = '" + nombre + "' WHERE correlativo = " + IDCorrelativo + ";";
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Lista las colecciones
        /// </summary>
        /// <returns></returns>
        public List<String[]> listarColecciones() {
            /****************************************************Probar con la base de datos***********************************************/
            // this.controladoBD.hacerConsultaEjecutor("DELETE FROM COLECCION");
            String consulta = "SELECT correlativo, nombre, correlativoPadre, correlativoFlujo From COLECCION;";
            SqlDataReader resultado = this.controladoBD.hacerConsultaEjecutor(consulta);
            String[] coleccion;
            List<String[]> lista = new List<string[]>();
            while (resultado.Read()) {
                coleccion = new String[4];
                coleccion[0] = resultado.GetValue(0).ToString();//Obtiene el correlativo
                coleccion[1] = resultado.GetValue(1).ToString();//Obtiene el nombre
                coleccion[2] = resultado.GetValue(2).ToString();//Obtiene el correlativo del padre
                coleccion[3] = resultado.GetValue(3).ToString();//Obtiene el correlativo del flujo al que pertenece
                lista.Add(coleccion);            
            }
            
            return lista;
        }

        /// <summary>
        /// Obtiene las colecciones del flujo
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public SqlDataReader getlistaColeccionesDeUnFlujo(int IDFlujo)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, correlativoPadre, correlativoFlujo from Coleccion where correlativoFlujo="+IDFlujo+";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene las colecciones no asignadas al flujo
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <param name="IDPerfil"></param>
        /// <returns></returns>
        public SqlDataReader getlistaColeccionesNoAsignadasDeUnFlujo(int IDFlujo, int IDPerfil)
        {
            SqlDataReader dataReader = null;//select  correlativo, nombre from Coleccion where correlativoFlujo=5 except select  colAsi.IDColeccion, col.nombre from ColeccionAsignada colAsi, Coleccion col where colAsi.IDColeccion=col.correlativo and col.correlativoFlujo=5 and colAsi.IDPerfil=19;
            //dataReader = this.controladoBD.hacerConsultaEjecutor("select  correlativo, nombre from Coleccion where correlativoFlujo="+IDFlujo+" except select  colAsi.IDColeccion, col.nombre from ColeccionAsignada colAsi, Coleccion col where colAsi.IDColeccion=col.correlativo;");
            dataReader = this.controladoBD.hacerConsultaEjecutor("select  correlativo, nombre from Coleccion where correlativoFlujo=" + IDFlujo + " except select  colAsi.IDColeccion, col.nombre from ColeccionAsignada colAsi, Coleccion col where colAsi.IDColeccion=col.correlativo and col.correlativoFlujo=" + IDFlujo + " and colAsi.IDPerfil=" + IDPerfil + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene las colecciones asignadas al flujo
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <param name="IDPerfil"></param>
        /// <returns></returns>
        public SqlDataReader getlistaColeccionesAsignadasDeUnFlujoAUnPerfil(int IDFlujo, int IDPerfil)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("select  colAsi.IDColeccion, col.nombre, colAsi.correlativo, colAsi.IDPerfil  from ColeccionAsignada colAsi, Coleccion col where IDPerfil="+IDPerfil+" and col.correlativo=colAsi.IDColeccion and col.correlativoFlujo=" + IDFlujo + "");
            return dataReader;
        }

        /// <summary>
        /// Obtiene el flujo de la coleccion
        /// </summary>
        /// <param name="IDColeccion"></param>
        /// <returns></returns>
        public SqlDataReader selectUnFlujo(int IDColeccion)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, nombre, correlativoPadre, correlativoFlujo from Coleccion where correlativo="+IDColeccion+";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene la tupla de ColeccionAsignada
        /// </summary>
        /// <param name="IDPerfil"></param>
        /// <param name="IDColeccion"></param>
        /// <returns></returns>
        public SqlDataReader selectTuplaPorIDColeccionYIDPerfil(int IDPerfil, int IDColeccion)//para retornar correlativo de la asignacion
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("select correlativo, IDPerfil, IDColeccion from ColeccionAsignada where IDPerfil=" + IDPerfil + " and IDColeccion=" + IDColeccion + ";");
            return dataReader;
        }

        /// <summary>
        /// Agrega una entrada a colecciones asignadas
        /// </summary>
        /// <param name="IDColeccionAsignada"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader permitirActividadDeUnaColeccion(int IDColeccionAsignada, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("INSERT INTO ActividadPermitida ( IDColeccionAsignada, IDActividad) 	VALUES (" + IDColeccionAsignada + ", " + IDActividad + ");");
            return dataReader;
        }

        /// <summary>
        /// Desasigna una actividad permitida
        /// </summary>
        /// <param name="IDColeccionAsignada"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public SqlDataReader despermitirActividadDeUnaColeccion(int IDColeccionAsignada, int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("delete from ActividadPermitida where IDColeccionAsignada=" + IDColeccionAsignada + " and IDActividad=" + IDActividad + ";");
            return dataReader;
        }
    }
}
