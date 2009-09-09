using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
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
            //******ATENCION AQUI NO SE COMO ARREGLARLO***********
            //Creo q asi... :p Beto
            Object datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            return datos;            
        }

        /// <summary>
        /// Devuelve todos los IDs del TIPOCAMPO de los diferentes miembros del formulario
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public SqlDataReader getIDsTiposCampo(String IDFormulario)
        {
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT MIEMBROFORMULARIO.nombre, MIEMBROFORMULARIO.IDTipoCampo, MIEMBROFORMULARIO.IDCampo " +
                                "FROM FORMULARIO, MIEMBROFORMULARIO " +
                                "WHERE MIEMBROFORMULARIO.IDFormulario = '" + IDFormulario + "' " +
                                "AND MIEMBROFORMULARIO.esEtiqueta = 'false'";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            return datos;            
        }

        public String getNombreFormulario(String IDFormulario)
        {
            string strConsulta = "SELECT FORMULARIO.nombre " +
                                "FROM FORMULARIO " +
                                "WHERE FORMULARIO.correlativo = '" + IDFormulario + "' ;";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            datos.Read();
            String nombre = datos.GetValue(0).ToString();
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
            string strConsulta = "SELECT tamano " +
                                "FROM TEXTO " +
                                "WHERE correlativo = '" + IDTipoCampo + "' ;";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            datos.Read();
            String strLargo = datos.GetValue(0).ToString();
            int largo = int.Parse(strLargo);
            Console.WriteLine("largo = " + largo);
            return largo;
        }

        public void crearTablaFormulario(String consulta)
        {
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Devuelve la coneccion que esta siendo utilizada
        /// </summary>
        /// <returns></returns>
        public void agregarFlujoConstruido(String consulta)
        {
            this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        /// <summary>
        /// Indica si este formularo es un maestro
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public bool soyMaestro(String IDFormulario)
        {
            String consulta = "select IDFormularioDetalle from MAESTRODETALLE " +
                            "where IDFormularioMaestro = '" + IDFormulario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if(datos.Read())
                return true;
            return false;
        }

        /// <summary>
        /// Indica si este formularo es un detalle
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public bool soyDetalle(String IDFormulario)
        {
            String consulta = "select IDFormularioMaestro from MAESTRODETALLE " +
                            "where IDFormularioDetalle = '" + IDFormulario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if(datos.Read())
                return true;
            return false;
        }
    }
}
