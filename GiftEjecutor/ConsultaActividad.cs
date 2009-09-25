using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaActividad:Consulta
    {
        /// <summary>
        /// Devuelve todas las Actividades que están contenidos es una actividad simple
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getTodasActividadesPorIDFlujo(int IDFlujo)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("Select correlativoFlujo , correlativo, nombre, descripcion, esSimple, ordenEjecucion from Actividad where correlativoFlujo="+IDFlujo+" order by ordenEjecucion;");
            return dataReader;
        }
        /// <summary>
        /// Devuelve la actividad según su ID
        /// </summary>
        /// <param name="IDActividad">ID de la actividad</param>
        /// <returns>SqlDataReader</returns>

        public SqlDataReader getDatosPorID(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select correlativo, nombre, Descripcion, esSimple, FechaActualizacion from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
    }
}
