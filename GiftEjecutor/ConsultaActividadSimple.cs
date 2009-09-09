using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ConsultaActividadSimple:Consulta
    {
        /// <summary>
        /// Devuelve los datos de una actividad simple segun su ID
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getActividadPorIDActividad(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select correlativo, nombre, descripcion, fechaActualizacion from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
    }
}
