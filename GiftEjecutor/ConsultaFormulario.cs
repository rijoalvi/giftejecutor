using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class ConsultaFormulario : Consulta
    {

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
            Object dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            return dato.ToString();            
        }

        public String getTextoDefecto(int IDCampo)
        {
            String consulta = "SELECT textoDefecto FROM NUMERO WHERE correlativo = " + IDCampo;
            Object dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            return dato.ToString();            
        }

        public String getValInicialIncremental(int IDCampo)
        {
            String consulta = "SELECT valInicial FROM INCREMENTAL WHERE correlativo = " + IDCampo;
            Object dato = this.controladoBD.hacerConsultaConfigurador(consulta);
            return dato.ToString();
        }


    }
}
