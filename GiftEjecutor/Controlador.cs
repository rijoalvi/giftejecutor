using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

        public DataTable getDataTableBitacora(int IDExpediente)
        {
            DataTable tablaComandos = new DataTable();
            DataRow fila;


            DataColumn evento = new DataColumn();
            DataColumn fechaEjecucion = new DataColumn();
            
            evento.ColumnName = "Evento";
            fechaEjecucion.ColumnName = "fechaEjecucion";
            

            evento.DataType = Type.GetType("System.String");
            fechaEjecucion.DataType = Type.GetType("System.String");
            
            tablaComandos.Columns.Add(evento);
            tablaComandos.Columns.Add(fechaEjecucion);

            consultaControlador = new ConsultaControlador();
            SqlDataReader datos;
            datos = this.consultaControlador.getDatosBitacora(IDExpediente);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaComandos.NewRow();
                    fila["Evento"] = datos.GetValue(0);
                    fila["fechaEjecucion"] = datos.GetValue(1);
                    tablaComandos.Rows.Add(fila);
                }
            }
            return tablaComandos;
        }


    }
}
