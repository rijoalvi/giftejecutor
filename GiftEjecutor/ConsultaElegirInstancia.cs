using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos del componente Elegir instancia
    /// </summary>
    class ConsultaElegirInstancia : Consulta
    {
        /// <summary>
        /// Obtiene el nombre del formulario
        /// </summary>
        /// <param name="IDForm"></param>
        /// <returns></returns>
        public String getNombreFormulario(int IDForm)
        {
            String consulta = "SELECT nombre FROM FORMULARIO WHERE correlativo = " + IDForm;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        /// <summary>
        /// Obtiene los datos del formulario
        /// </summary>
        /// <param name="nombreForm"></param>
        /// <param name="IDExpediente"></param>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public SqlDataReader getDatosFormuario(String nombreForm, int IDExpediente, int IDFormulario)
        {
            //agregue al final la comparacion con el IDForm, esta sin probar... ;)
            String consulta = "select " + nombreForm + ".correlativo, BITACORA.fecha from " + nombreForm + ", BITACORA where " + nombreForm + ".correlativo = BITACORA.IDInstaciaForm AND BITACORA.tipoComando = 1 AND BITACORA.IDExpediente = " + IDExpediente + " AND Bitacora.IDFormConfigurador = " + IDFormulario + ";";
            Console.WriteLine(consulta);
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }        
    }
}
