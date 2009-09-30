using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

        public SqlDataReader getDatosUnaActividad(int IDActividad, int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDExpediente, IDActividad, ejecutada FROM Bitacora where IDExpediente = " + IDExpediente + " and IDActividad = " + IDActividad+ " AND IDComando = -1;");
            return dataReader;
        }

        public SqlDataReader getDatosBitacora(int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select descripcion, fecha from Bitacora where IDExpediente=" + IDExpediente + ";");
            return dataReader;
        }

        public SqlDataReader getDatosBitacoraOrdenDescendiente(int IDExpediente)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDComando from Bitacora where IDExpediente=" + IDExpediente + " order by correlativo desc;");
            return dataReader;
        }

        public SqlDataReader getUltimoComandoPorActividad(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("Select estadoFinal from Actividad where correlativo =" + IDActividad+ ";");
            return dataReader;
        }
    }
}
