using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
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
        public String[] getIDsFormulariosDelFlujo(int IDflujo)
        {
            
            /*//Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT FORMULARIO.correlativo " +
                                 "FROM FLUJO, ACTIVIDAD, MIEMBROACTIVIDADSIMPLE, COMANDO, FORMULARIO "+
                                 "WHERE FLUJO.correlativo = '"+ IDflujo + "' " + //aqui compara cn el flujo escogido
                                 "AND ACTIVIDAD.correlativoFlujo = FLUJO.correlativo "+
                                 "AND MIEMBROACTIVIDADSIMPLE.correlativoMadre = ACTIVIDAD.correlativo "+
                                 "AND COMANDO.ID = MIEMBROACTIVIDADSIMPLE.correlativoComando "+
                                 "AND COMANDO.IDFormulario = FORMULARIO.correlativo;";                
            MySqlDataReader datos = this.controladoBD.hacerConsulta(strConsulta);
            Console.WriteLine("hay " + datos.FieldCount + " numero de datos");
            String[] IDs = new string[datos.FieldCount];
            for (int i = 0; i < datos.FieldCount; i++) {
                IDs[i] = ""+datos.GetValue(i)+";";
            }
            return IDs;*/
            return null;
        }

        /// <summary>
        /// Devuelve todos los IDs del TIPOCAMPO de los diferentes miembros del formulario
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public String[] getIDsTiposCampo(int IDFormulario){
        /*//Toma todos los IDs de los formularios q trabajan con ese flujo
            string strConsulta = "SELECT MIEMBROFORMULARIO.IDTipoCampo "+
                                "FROM FORMULARIO, MIEMBROFORMULARIO "+
                                "WHERE MIEMBROFORMULARIO.IDFormulario = '"+ IDFormulario +"' "+
                                "AND MIEMBROFORMULARIO.esEtiqueta = 'false'";              
            MySqlDataReader datos = this.controladoBD.hacerConsulta(strConsulta);
            Console.WriteLine("hay " + datos.FieldCount + " numero de datos");
            String[] IDs = new string[datos.FieldCount];
            for (int i = 0; i < datos.FieldCount; i++) {
                IDs[i] = ""+datos.GetValue(i)+";";
            }
            return IDs;
        */
            return null;
        }


    }
}
