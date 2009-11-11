using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ConsultaComandoMascara : Consulta
    {
        /// <summary>
        /// Aplicar comando para modificar el campo de un formulario
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public void aplicarComandoConMascara(string nombreFormulario,string campoCondicion, string valorCo)
        {
            /*SqlDataReader dataReader = null;

            dataReader = this.controladoBD.hacerConsultaConfigurador("Select m.correlativo , m.correlativoMadre as IDActividad, m.correlativoComando as IDComando, c.Nombre as nombreComando, c.Descripcion as descripcionComando, c.tipo,c.IDFormularioATrabajar, m.orden as ordenComando, m.obligatorio from MiembroActividadSimple m, comando c where m.correlativoMadre=" + IDActividad + " and m.correlativoComando=c.ID;");
            return dataReader;*/
    
        }

        /// <summary>
        /// Devuelve los datos de un COMANDO CON MASCARA según su ID
        /// </summary>
        /// <param name="IDActividad">ID de la actividad simple</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader getDatosPorID(int ID)
        {
            SqlDataReader dataReader = null;
            dataReader = this.controladoBD.hacerConsultaConfigurador("select IDComando, TipoCampoInicial, CondicionInicial, TipoCampoFinal, EstadoFinal from ComandoMascara where IDComando=" + ID + ";");
            return dataReader;            
        }

    }
}
