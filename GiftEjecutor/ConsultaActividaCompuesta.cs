using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ConsultaActividaCompuesta:Consulta
    {
        public SqlDataReader getTodasActividadesHija(int IDActividadPadre)
        {
            SqlDataReader dataReader = null;
            string consulta = "select a.correlativo as IDPadre, a.nombre as nombrePadre, mac.correlativoHija, ah.nombre as nombreHija, ah.descripcion as descripcionHija,ah.tipo as esCompuesta, ah.repetible, ah.fechaActualizacion from actividad a,MiembroActividadCompuesta mac, actividad ah where a.correlativo=mac.correlativoMadre and mac.correlativoMadre=" + IDActividadPadre + " and ah.correlativo=mac.correlativoHija";
            Console.WriteLine(consulta);
            dataReader = this.controladoBD.hacerConsultaConfigurador(consulta);
            return dataReader;
        }

        public SqlDataReader getDatosExtendidosPorID(int IDActividad)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select correlativo, nombre, Descripcion, esSimple, repetible, paralelo,exclusivo, ordenEjecucion, FechaActualizacion from Actividad where correlativo=" + IDActividad + ";");
            return dataReader;
        }
    }
}
