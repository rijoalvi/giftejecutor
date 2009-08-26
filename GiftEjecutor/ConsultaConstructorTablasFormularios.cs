using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Hereda de clase consulta donde esta el "ControladorBD"
    /// </summary>
    abstract class ConsultaConstructorTablasFormularios : Consulta
    {

        /// <summary>
        /// Devuelve los IDs de todos los formularios que forman parte del flujo de trabajo
        /// </summary>
        /// <param name="IDflujo"></param>
        /// <returns></returns>
        public abstract object getIDsFormulariosDelFlujo(String IDflujo);        
   
        /// <summary>
        /// Devuelve todos los IDs del TIPOCAMPO de los diferentes miembros del formulario
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public abstract object getIDsTiposCampo(String IDFormulario);

        public abstract String getNombreFormulario(String IDFormulario);

        public abstract void crearTablaFormulario(String consulta);

        public static ConsultaConstructorTablasFormularios getInstancia()
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
        }

    }
}
