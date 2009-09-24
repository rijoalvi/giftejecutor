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

        public SqlDataReader getDatosFormuario(String nombreForm, int IDExpediente) {
            String consulta = "select " + nombreForm + ".correlativo, BITACORA.fecha from " + nombreForm + ", BITACORA where " + nombreForm + ".correlativo = BITACORA.IDInstaciaForm AND BITACORA.tipoComando = 1 AND BITACORA.IDExpediente = " + IDExpediente + ";";            
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }

        public SqlDataReader eliminarTupla(int IDTupla, String nombreFormulario) {
            String consulta = "delete from " + nombreFormulario + " where correlativo = " + IDTupla + ";";
            SqlDataReader datos = this.controladoBD.hacerConsultaEjecutor(consulta);
            return datos;
        }
    }
}
