using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{

    class ConsultaFlujoTrabajo : Consulta
    {
        public String[] getDatosFlujo(int correlativo){
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador("SELECT nombre,descripcion FROM FLUJO WHERE correlativo = " + correlativo);
            String[] dato = new String[2];
            dato[0] = datos.GetValue(0).ToString();
            dato[1] = datos.GetValue(1).ToString();
            return dato;
        }



        public SqlDataReader getTodosLosFlujosTrabajo()
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("SELECT * FROM FLUJO");
           /* dataReader.Read();
            dataReader.GetValue(1);*/
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
