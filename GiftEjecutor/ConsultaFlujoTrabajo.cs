using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{

    class ConsultaFlujoTrabajo : Consulta
    {

        public SqlDataReader getTodosLosFlujosTrabajo()
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("SELECT * FROM FLUJO;");
            return dataReader;
        }

        public SqlDataReader getFlujosConstruidos()
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("SELECT idFlujo FROM FLUJOSACTIVOS;");
            return dataReader;
        }


    }
}
