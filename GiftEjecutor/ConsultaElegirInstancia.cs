using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaElegirInstancia : Consulta
    {
        public SqlDataReader llenarDataGrid() {
            String consulta = "select * ";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }
    }
}
