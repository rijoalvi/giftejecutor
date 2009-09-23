using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaControlador: Consulta
    {
        public ConsultaControlador()
        {
        }

        public SqlDataReader getDatosUnSoloComando(int IDComando, int IDExpediente)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDExpediente, IDComando from Bitacora where IDExpediente=" + IDExpediente + " and IDComando=" + IDComando + ";");
            return dataReader;
        }
    }
}
