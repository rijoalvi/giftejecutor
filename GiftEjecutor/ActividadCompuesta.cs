using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class ActividadCompuesta: Actividad
    {

        ConsultaActividaCompuesta consultaActividadCompuesta;

        /// <summary>
        /// Devuelve el dataTable con las actividades hijas de una actividad segun su ID
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        /// 

        public ActividadCompuesta() {
            consultaActividadCompuesta = new ConsultaActividaCompuesta();
        }
        public DataTable getDataTableTodasActividadesHija(int IDActividadPadre)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "Tipo";
           // repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
         //   repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
         //   tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            SqlDataReader datos;
            datos = consultaActividadCompuesta.getTodasActividadesHija(IDActividadPadre);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(2);
                    fila["nombreActividad"] = datos.GetValue(3);
                    fila["descripcionActividad"] = datos.GetValue(4);
                    fila["Tipo"] = this.getTipo(datos.GetValue(5).ToString());
                 //   fila["repetible"] = datos.GetValue(6).ToString();

                    tablaActividades.Rows.Add(fila);

                }
            }
            return tablaActividades;
        }

        private string getTipo(string tipo)
        {
            switch (tipo)
            {
                case "0":
                    return "Simple";
                case "1":
                    return "Compuesta";
                default:
                    return "[Mal especifícado]";
            }
        }

    }
}
