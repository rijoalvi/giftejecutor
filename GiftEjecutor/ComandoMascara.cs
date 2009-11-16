using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ComandoMascara: Comando
    {
        int ID;

        public string nombreCampoInicial;
        public string valorCampoInical;
        public string nombreCampoEfecto;
        public string valorCampoEfecto;

        ConsultaComandoMascara consultaComandoMascara;

        public ComandoMascara(Usuario user): base(user) {
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
            return 
                //base.ToString()+"ID: " + this.ID + "" + '\n' +
                //"nombreCampoInicial: " + this.nombreCampoInicial + "" + '\n' +
                //"valorCampoInical: " + this.valorCampoInical + "" + '\n' +
                "Aplicada máscara" + '\n' +
                "nombreCampoEfecto: " + this.nombreCampoEfecto + "" + '\n' +
                "valorCampoEfecto: " + this.valorCampoEfecto + "" + '\n' 
                ;
        }
    }
}
