using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que realiza los accesos a Base de Datos de los comandos
    /// </summary>
    class ConsultaComando:Consulta
    {
        /// <summary>
        /// Devuelve todos los comandos que est�n contenidos es una actividad simple
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getTodosComandosPorIDActividad(int IDActividad)
        {
            SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("Select m.correlativo , m.correlativoMadre as IDActividad, m.correlativoComando as IDComando, c.Nombre as nombreComando, c.Descripcion as descripcionComando, c.tipo,c.IDFormularioATrabajar, m.orden as ordenComando, m.obligatorio from MiembroActividadSimple m, comando c where m.correlativoMadre="+IDActividad+" and m.correlativoComando=c.ID order by m.orden;");
            return dataReader;
        }
        /// <summary>
        /// Devuelve el comando seg�n su ID
        /// </summary>
        /// <param name="IDComando">ID del comando</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getDatosPorID(int IDComando)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID, Nombre, Descripcion, Tipo, IDFormularioATrabajar, FechaActualizacion from Comando where ID=" + IDComando + ";");
            return dataReader;
        }

        /// <summary>
        /// Obtiene el ID del comando
        /// </summary>
        /// <param name="nombreComando"></param>
        /// <returns></returns>
        public SqlDataReader getIDComando(string nombreComando)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select ID from Comando where Nombre=" + nombreComando + ";");
            return dataReader;
        }
    }
}
