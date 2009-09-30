using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaElegirInstancia : Consulta
    {

        public String getNombreFormulario(int IDForm)
        {
            String consulta = "SELECT nombre FROM FORMULARIO WHERE correlativo = " + IDForm;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        public SqlDataReader getDatosFormuario(String nombreForm, int IDExpediente, int IDFormulario)
        {
            //agregue al final la comparacion con el IDForm, esta sin probar... ;)
            String consulta = "select " + nombreForm + ".correlativo, BITACORA.fecha from " + nombreForm + ", BITACORA where " + nombreForm + ".correlativo = BITACORA.IDInstaciaForm AND BITACORA.tipoComando = 1 AND BITACORA.IDExpediente = " + IDExpediente + " AND Bitacora.IDFormConfigurador = " + IDFormulario + ";";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }        
    }
}
