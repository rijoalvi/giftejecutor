using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Hereda de clase consulta donde esta el "ControladorBD"
    /// </summary>
    class ConsultaConstructorTablasFormulariosMySQL : ConsultaConstructorTablasFormularios
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
            Object datos = this.controladoBD.hacerConsultaMySQL(strConsulta);
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
            string strConsulta = "SELECT MIEMBROFORMULARIO.nombre, MIEMBROFORMULARIO.IDTipoCampo, MIEMBROFORMULARIO.IDCampo " +
                                "FROM FORMULARIO, MIEMBROFORMULARIO " +
                                "WHERE MIEMBROFORMULARIO.IDFormulario = '" + IDFormulario + "' " +
                                "AND MIEMBROFORMULARIO.esEtiqueta = 'false'";
            Object datos = this.controladoBD.hacerConsultaMySQL(strConsulta);
            return datos;
        }

        public override String getNombreFormulario(String IDFormulario)
        {

            string strConsulta = "SELECT FORMULARIO.nombre " +
                                "FROM FORMULARIO " +
                                "WHERE FORMULARIO.correlativo = '" + IDFormulario + "' ;";
            Object datos = this.controladoBD.hacerConsultaMySQL(strConsulta);
            String nombre = "";
            if (datos != null)
            {
                while (((MySqlDataReader)(datos)).Read())
                {
                    nombre = ((MySqlDataReader)(datos)).GetValue(0).ToString();                        
                }                
            }
            nombre = nombre.Trim();
            String[] tmp = nombre.Split(' ');
            nombre = "";
            for (int i = 0; i < tmp.Length; ++i)
                nombre += tmp[i];
            return nombre;        
        }

        /// <summary>
        /// Indica el largo del texto, para asi crear el campo en la BD del tamaño maximo
        /// </summary>
        /// <param name="IDTipoCampo"></param>
        /// <returns></returns>
        public override int getLongitudDeTexto(String IDTipoCampo)
        {
            Console.WriteLine("busco el tamano del texto");
            string strConsulta = "SELECT TEXTO.tamano " +
                                "FROM TEXTO " +
                                "WHERE TEXTO.correlativo = '" + IDTipoCampo + "' ;";
            Object datos = this.controladoBD.hacerConsultaMySQL(strConsulta);
            String strLargo = "";
            if (datos != null)
            {
                while (((MySqlDataReader)(datos)).Read())
                {
                    strLargo = ((MySqlDataReader)(datos)).GetValue(0).ToString();
                }
            }
            int largo = int.Parse(strLargo);
            Console.WriteLine("largo = " + largo);
            return largo;
        }


        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public override void agregarFlujoConstruido(String consulta)
        {
            this.controladoBD.hacerConsultaMySQL(consulta);
        }


        public override void crearTablaFormulario(String consulta) {
            this.controladoBD.hacerConsultaMySQL(consulta);
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
            object datos = this.controladoBD.hacerConsultaMySQL(consulta);
            if (datos != null)
            {
                if (((MySqlDataReader)(datos)).Read())
                {
                    String IDFormDetalle = ((MySqlDataReader)(datos)).GetValue(0).ToString();
                    return IDFormDetalle;
                }
            }
            return null;
        }

        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public int getConeccion() {
            return this.controladoBD.getConeccionSeleccionada();
        }


    }
}
