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
            dataReader = this.controladoBD.hacerConsultaConfigurador("select a.correlativo as IDPadre, a.nombre as nombrePadre, mac.correlativoHija, ah.nombre as nombreHija, ah.descripcion as descripcionHija, ah.fechaActualizacion from actividad a,MiembroActividadCompuesta mac, actividad ah where a.correlativo=mac.correlativoMadre and mac.correlativoMadre="+IDActividadPadre+" and ah.correlativo=mac.correlativoHija");
            return dataReader;
        }
    }
}
