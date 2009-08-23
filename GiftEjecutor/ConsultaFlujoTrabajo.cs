using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    
    class ConsultaFlujoTrabajo : Consulta
    {

        public MySqlDataReader getTodosLosFlujosTrabajo()
        {
            MySqlDataReader datos= this.controladoBD.hacerConsulta("SELECT correlativo, nombre, descripcion, actividadRaiz, fechaActualizacion FROM FLUJO;");
            return datos;
        }
    }
}
