using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ComandoMascara: Comando
    {
        int ID;

        string nombreCampoInicial;
        string valorCampoInical;
        string nombreCampoEfecto;
        string valorCampoEfecto;

        ConsultaComandoMascara consultaComandoMascara;
        public ComandoMascara(): base() {
            consultaComandoMascara = new ConsultaComandoMascara();
        }
        public void setAtributosComandoMascaraSegunID(int IDComando){
            base.setAtributosSegunID(IDComando);
            SqlDataReader datosComando;

            datosComando = this.consultaComandoMascara.getDatosPorID(IDComando);
            if (datosComando != null)
            {
                while (datosComando.Read()){
                    this.ID = System.Int32.Parse(datosComando.GetValue(0).ToString());
                    this.nombreCampoInicial = datosComando.GetValue(1).ToString();
                    this.valorCampoInical = datosComando.GetValue(2).ToString();
                    this.nombreCampoEfecto = datosComando.GetValue(3).ToString();
                    this.valorCampoEfecto = datosComando.GetValue(4).ToString();
                    //this.fechaActualizacion = datosComando.GetValue(5);
                }
            }
        }
        public override string ToString()
        {
            return base.ToString()+"ID: " + this.ID + "" + '\n' +
                "nombreCampoInicial: " + this.nombreCampoInicial + "" + '\n' +
                "valorCampoInical: " + this.valorCampoInical + "" + '\n' +
                "nombreCampoEfecto: " + this.nombreCampoEfecto + "" + '\n' +
                "valorCampoEfecto: " + this.valorCampoEfecto + "" + '\n' 
                ;
        }
    }
}
