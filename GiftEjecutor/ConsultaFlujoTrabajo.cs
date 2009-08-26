using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace GiftEjecutor
{

    abstract class ConsultaFlujoTrabajo : Consulta
    {

        public abstract Object getTodosLosFlujosTrabajo();

        public static ConsultaFlujoTrabajo getInstancia(){
            ConsultaFlujoTrabajo consultaFlujoSeleccionado=null;
            if (ControladorBD.conexionSelecciona == ControladorBD.SQLSERVER)
            {
                consultaFlujoSeleccionado = new ConsultaFlujoTrabajoSQLServer();
            }
            if (ControladorBD.conexionSelecciona == ControladorBD.MYSQL)
            {
                consultaFlujoSeleccionado = new ConsultaFlujoTrabajoMySQL();
            }
            return consultaFlujoSeleccionado;
        }
    }
}
