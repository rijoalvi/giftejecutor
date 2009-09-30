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

        public SqlDataReader getDatosUnSoloComando(int IDComando, int IDExpediente, int IDActividad)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaEjecutor("Select IDExpediente, IDComando from Bitacora where IDExpediente=" + IDExpediente + " and IDComando=" + IDComando + " AND IDActividad = " + IDActividad + ";");
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

        public void finalizarActividadBitacora(int IDExpediente, int IDActividad)
        {
            bool valor = true;           
            String descripcion = "Se termino de ejecutar la actividad " + IDActividad.ToString();
            String consulta1 = "INSERT INTO BITACORA(IDExpediente, IDActividad, IDComando, tipoComando, IDInstaciaForm, IDFormConfigurador, ejecutada, descripcion)" +
                            "VALUES(" + IDExpediente + ", " + IDActividad + ", " + -1 + ", " + -1 + ", " + -1 + ", " + -1 + ", '" + valor + "', '" + descripcion + "');";
            Console.WriteLine(consulta1);
            SqlDataReader datos1 = this.controladoBD.hacerConsultaEjecutor(consulta1);
        }
    }
}
