using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;
namespace GiftEjecutor
{
    class FlujoTrabajo
    {
        ConsultaFlujoTrabajo consultaFlujoTrabajo;
        public FlujoTrabajo() {
            consultaFlujoTrabajo = new ConsultaFlujoTrabajo();
        }
        public DataTable getDataTableTodosLosFlujosDeTrabajo()
        {
            MySqlDataReader datos = consultaFlujoTrabajo.getTodosLosFlujosTrabajo();

            DataTable tabla = new DataTable();
            DataRow fila;
            DataColumn IDFlujo = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn descripcion = new DataColumn();

            IDFlujo.ColumnName = "IDFlujo";
            IDFlujo.DataType = Type.GetType("System.String");

            nombre.ColumnName = "nombre";
            nombre.DataType = Type.GetType("System.String");

            descripcion.ColumnName = "descripcion";
            descripcion.DataType = Type.GetType("System.String");

            tabla.Columns.Add(IDFlujo);
            tabla.Columns.Add(nombre);
            tabla.Columns.Add(descripcion);

            if (datos != null)
            {
    
                while (datos.Read())
                {


                    fila = tabla.NewRow();
                    fila["IDFlujo"] = datos.GetValue(0);//el nueve tiene la cantidad
                    fila["nombre"] = datos.GetValue(1);
                    fila["descripcion"] = datos.GetValue(2).ToString();

                    tabla.Rows.Add(fila);
                }

            }

            return tabla;
        }
    }
}
