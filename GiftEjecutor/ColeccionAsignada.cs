using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ColeccionAsignada
    {
        public int correlativo;
        public int IDPerfil;
        public int IDColeccion;
        public ConsultaColeccion consultaColeccion;
        public ColeccionAsignada() {
            consultaColeccion = new ConsultaColeccion();
        }
        public void setDatosPorPerfilYColeccion(int IDPerfil, int IDColeccion){

            SqlDataReader datos;
            datos = this.consultaColeccion.selectTuplaPorIDColeccionYIDPerfil(IDPerfil, IDColeccion);
            if (datos != null)
            {
                while (datos.Read())
                {
                    this.correlativo= Int32.Parse(datos.GetValue(0).ToString());
                    this.IDPerfil = Int32.Parse(datos.GetValue(1).ToString());
                    this.IDColeccion = Int32.Parse(datos.GetValue(2).ToString());

                }
            }
        }
        public void permitirActividad(int IDActividad)
        {
            this.consultaColeccion.permitirActividadDeUnaColeccion(this.correlativo, IDActividad);
        }

        public void despermitirActividad(int IDActividad)
        {
            this.consultaColeccion.despermitirActividadDeUnaColeccion(this.correlativo,IDActividad);
        }
    }
}
