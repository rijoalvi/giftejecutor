using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    /// <summary>
    /// Hereda de clase consulta donde esta el "ControladorBD"
    /// </summary>
    class ConsultaConstructorTablasFormularios : Consulta
    {

        /// <summary>
        /// Devuelve los IDs de todos los formularios que forman parte del flujo de trabajo
        /// </summary>
        /// <param name="IDflujo"></param>
        /// <returns></returns>
        public object getIDsFormulariosDelFlujo(String IDflujo)
        {


            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT FORMULARIO.correlativo " +
                                 "FROM FLUJO, ACTIVIDAD, MIEMBROACTIVIDADSIMPLE, COMANDO, FORMULARIO " +
                                 "WHERE FLUJO.correlativo = '" + IDflujo + "' " + //aqui compara cn el flujo escogido
                                 "AND ACTIVIDAD.correlativoFlujo = FLUJO.correlativo " +
                                 "AND MIEMBROACTIVIDADSIMPLE.correlativoMadre = ACTIVIDAD.correlativo " +
                                 "AND COMANDO.ID = MIEMBROACTIVIDADSIMPLE.correlativoComando " +
                                 "AND COMANDO.IDFormulario = FORMULARIO.correlativo;";
            //******ATENCION AQUI NO SE COMO ARREGLARLO***********Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);
            //return datos;
            return null;
        }

        /// <summary>
        /// Devuelve todos los IDs del TIPOCAMPO de los diferentes miembros del formulario
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public object getIDsTiposCampo(String IDFormulario)
        {
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT MIEMBROFORMULARIO.nombre, MIEMBROFORMULARIO.IDTipoCampo, MIEMBROFORMULARIO.IDCampo " +
                                "FROM FORMULARIO, MIEMBROFORMULARIO " +
                                "WHERE MIEMBROFORMULARIO.IDFormulario = '" + IDFormulario + "' " +
                                "AND MIEMBROFORMULARIO.esEtiqueta = 'false'";
            //******ATENCION AQUI NO SE COMO ARREGLARLO***********Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);
            //return datos;
            return null;
        }

        public String getNombreFormulario(String IDFormulario)
        {
            string strConsulta = "SELECT FORMULARIO.nombre " +
                                "FROM FORMULARIO " +
                                "WHERE FORMULARIO.correlativo = '" + IDFormulario + "' ;";
            //******ATENCION AQUI NO SE COMO ARREGLARLO***********Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);
            Object datos = null;//************
            String nombre = "";
            if (datos != null)
            {
                /*while (((SqlDataReader)datos)).Read())///************
                {
                    nombre = ((SqlDataReader)(datos)).GetValue(0).ToString();
                }*/
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
        public int getLongitudDeTexto(String IDTipoCampo)
        {
            Console.WriteLine("busco el tamano del texto");
            string strConsulta = "SELECT TEXTO.largo " +
                                "FROM TEXTO " +
                                "WHERE TEXTO.correlativo = '" + IDTipoCampo + "' ;";
            //******ATENCION AQUI NO SE COMO ARREGLARLO***********Object datos = this.controladoBD.hacerConsultaSQLServer(strConsulta);
            String strLargo = "";
           /* if (datos != null)
            {
                //******ATENCION AQUI NO SE COMO ARREGLARLO***********while (((SqlDataReader)(datos)).Read())
                //{
                //    strLargo = ((SqlDataReader)(datos)).GetValue(0).ToString();
               // }
            }*/
            int largo = int.Parse(strLargo);
            Console.WriteLine("largo = " + largo);
            return largo;
        }

        public void crearTablaFormulario(String consulta)
        {
            //this.controladoBD.hacerConsultaSQLServer(consulta);
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public void agregarFlujoConstruido(String consulta)
        {
            //this.controladoBD.hacerConsultaSQLServer(consulta);
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Devuelve el ID del formulario detalle, si es q este es un maestro, de lo contrario devuelve un NULL
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public String soyMaestro(String IDFormulario)
        {
            String consulta = "select IDFormularioDetalle from MAESTRODETALLE " +
                            "where IDFormularioMaestro = '" + IDFormulario + "';";
            //NO SE ARREGLAR ESTOobject datos = this.controladoBD.hacerConsultaSQLServer(consulta);
            /*if (datos != null)
            {
                if (((SqlDataReader)(datos)).Read())
                {
                    String IDFormDetalle = ((SqlDataReader)(datos)).GetValue(0).ToString();
                    return IDFormDetalle;
                }
            }*/
            return null;
        }

        /*public static ConsultaConstructorTablasFormularios getInstancia()
        {
            ConsultaConstructorTablasFormularios consultaTablasFormularioSeleccionado = null;
            if (ControladorBD.conexionSelecciona == ControladorBD.SQLSERVER)
            {
                consultaTablasFormularioSeleccionado = new ConsultaConstructorTablasFormulariosSQLServer();
            }
            if (ControladorBD.conexionSelecciona == ControladorBD.MYSQL)
            {
                consultaTablasFormularioSeleccionado = new ConsultaConstructorTablasFormulariosMySQL();
            }
            return consultaTablasFormularioSeleccionado;
        }*/

    }
}
