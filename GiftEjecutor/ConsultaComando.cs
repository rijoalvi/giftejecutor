using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaComando:Consulta
    {
        /// <summary>
        /// Devuelve todos los comandos que están contenidos es una actividad simple
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getTodosComandosPorIDActividad(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select * from Flujo;");
            return dataReader;
        }
    }
}
