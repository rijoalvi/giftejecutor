using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ConsultaFormulario : Consulta
    {
        public SqlDataReader ejecutarConsultaConfigurador(String consulta)
        {
            return this.controladoBD.hacerConsultaConfigurador(consulta);
        }

        public SqlDataReader ejecutarConsultaEjecutor(String consulta)
        {
            return this.controladoBD.hacerConsultaEjecutor(consulta);
        }

        public object getDatosFormulario(int IDForm)
        {
            //Toma todos los IDs de los formularios q trabajan con ese flujo
            String strConsulta = "Select correlativo, nombre, valX, valY, ancho, alto, tipoLetra, color, tamanoLetra, IDTipoCampo, IDCampo, tabIndex, estiloLetra " +
                "From MIEMBROFORMULARIO Where IDFormulario = " + IDForm +
                "ORDER BY correlativo;";
            Object datos = this.controladoBD.hacerConsultaConfigurador(strConsulta);
            return datos;            
        }

        public String getMascaraNumero(int IDCampo)
        {
            String consulta = "SELECT mascara FROM NUMERO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        public String getTextoDefecto(int IDCampo)
        {
            String consulta = "SELECT textoDefecto FROM TEXTO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        public String getValInicialIncremental(int IDCampo)
        {
            String consulta = "SELECT valInicial FROM INCREMENTAL WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if(dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        public Object getMiembrosLista(int IDCampo)
        {
            String consulta = "SELECT valor FROM MIEMBROLISTA WHERE IDLista = " + IDCampo;
            Object datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            return datos;
        }

        public int getMaxLengthTexto(int IDCampo)
        {
            String consulta = "SELECT tamano FROM TEXTO WHERE correlativo = " + IDCampo;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return int.Parse(dato.GetValue(0).ToString());
            return -1;
        }

        public String getNombreFormulario(int IDForm)
        {
            String consulta = "SELECT nombre FROM FORMULARIO WHERE correlativo = " + IDForm;
            SqlDataReader dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (dato.Read())
                return dato.GetValue(0).ToString();
            return null;
        }

        /// <summary>
        /// Indica si este formularo es un maestro
        /// </summary>
        /// <param name="IDFormulario"></param>
        /// <returns></returns>
        public bool soyMaestro(String IDFormulario)
        {
            String consulta = "select IDFormularioDetalle from MAESTRODETALLE " +
                            "where IDFormularioMaestro = '" + IDFormulario + "';";
            SqlDataReader datos = this.controladoBD.hacerConsultaConfigurador(consulta);
            if (datos.Read())
                return true;
            return false;
        }
    }
}
