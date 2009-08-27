using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Hereda de clase consulta donde esta el "ControladorBD"
    /// </summary>
    class ConsultaConstructorTablasFormulariosSQLServer : ConsultaConstructorTablasFormularios
    {

        /// <summary>
        /// Devuelve los IDs de todos los formularios que forman parte del flujo de trabajo
        /// </summary>
        /// <param name="IDflujo"></param>
        /// <returns></returns>
        public override object getIDsFormulariosDelFlujo(String IDflujo)
        {
            
            
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT FORMULARIO.correlativo " +
                                 "FROM FLUJO, ACTIVIDAD, MIEMBROACTIVIDADSIMPLE, COMANDO, FORMULARIO "+
                                 "WHERE FLUJO.correlativo = '"+ IDflujo + "' " + //aqui compara cn el flujo escogido
                                 "AND ACTIVIDAD.correlativoFlujo = FLUJO.correlativo "+
                                 "AND MIEMBROACTIVIDADSIMPLE.correlativoMadre = ACTIVIDAD.correlativo "+
                                 "AND COMANDO.ID = MIEMBROACTIVIDADSIMPLE.correlativoComando "+
                                 "AND COMANDO.IDFormulario = FORMULARIO.correlativo;";
            Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);            
            return datos;
        }

        /// <summary>
        /// Devuelve todos los IDs del TIPOCAMPO de los diferentes miembros del formulario
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public override object getIDsTiposCampo(String IDFormulario)
        {
            
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT MIEMBROFORMULARIO.nombre, MIEMBROFORMULARIO.IDTipoCampo "+
                                "FROM FORMULARIO, MIEMBROFORMULARIO "+
                                "WHERE MIEMBROFORMULARIO.IDFormulario = '"+ IDFormulario +"' "+
                                "AND MIEMBROFORMULARIO.esEtiqueta = 'false'";
            Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);
            return datos;
        }

        public override String getNombreFormulario(String IDFormulario)
        {

            string strConsulta = "SELECT FORMULARIO.nombre " +
                                "FROM FORMULARIO " +
                                "WHERE FORMULARIO.correlativo = '" + IDFormulario + "' ;";
            Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);         
            String nombre = "";
            if (datos != null)
            {
                while (((SqlDataReader)(datos)).Read())
                {
                    nombre = ((SqlDataReader)(datos)).GetValue(0).ToString();                        
                }                
            }
            nombre = nombre.Trim();
            String[] tmp = nombre.Split(' ');
            nombre = "";
            for (int i = 0; i < tmp.Length; ++i)
                nombre += tmp[i];
            return nombre;    
            return nombre;                        
        }

        public override void crearTablaFormulario(String consulta) {
            this.controladoBD.hacerConsultaSQLServer(consulta);
        }

        /// <summary>
        /// Devuelve el ID del formulario detalle, si es q este es un maestro, de lo contrario devuelve un NULL
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public override String soyMaestro(String IDFormulario)
        {
            String consulta = "select IDFormularioDetalle from MAESTRODETALLE " +
                            "where IDFormularioMaestro = '" + IDFormulario + "';";
            object datos = this.controladoBD.hacerConsultaSQLServer(consulta);
            String IDFormDetalle = ((SqlDataReader)(datos)).GetValue(0).ToString(); 
            return IDFormDetalle;
        }

        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public override void agregarFlujoConstruido(String consulta)
        {
            this.controladoBD.hacerConsultaSQLServer(consulta);
        }


    }
}
