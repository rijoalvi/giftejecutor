using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class ActividadSimple
    {
        public string nombre;
        public string descripcion;
        ConsultaActividadSimple consultaActividad;
        public ActividadSimple(){
            this.consultaActividad=new ConsultaActividadSimple();
        }
        public void setAtributosPorID(int IDActividad){
            SqlDataReader datosActividad;

            datosActividad = this.consultaActividad.getActividadPorIDActividad(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                   // this.ID = System.Int32.Parse(datosComando.GetValue(0).ToString());
                    this.nombre = datosActividad.GetValue(1).ToString();
                    this.descripcion = datosActividad.GetValue(2).ToString();
                  
                }
            }     
        }
    }
}
