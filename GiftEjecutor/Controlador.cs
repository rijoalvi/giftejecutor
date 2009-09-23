using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class Controlador
    {
        ConsultaControlador consultaControlador;
        public Controlador()
        {

        }

        public bool checkComandoRealizado(int idComando, int expediente)
        {
            bool respuesta;
            respuesta = false;

            consultaControlador= new ConsultaControlador();
            SqlDataReader datosControlador;

            datosControlador = this.consultaControlador.getDatosUnSoloComando(idComando, expediente);
            if (datosControlador != null)
            {
                if (datosControlador.Read())
                {
                    respuesta = true;
                }
            }

            return respuesta;
        }

    }
}
