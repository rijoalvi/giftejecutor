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

        public bool checkComandoRealizado(int idComando, int expediente, int IDActividad)
        {
            bool respuesta;
            respuesta = false;

            consultaControlador = new ConsultaControlador();
            SqlDataReader datosControlador;

            datosControlador = this.consultaControlador.getDatosUnSoloComando(idComando, expediente, IDActividad);
            if (datosControlador != null)
            {
                if (datosControlador.Read())
                {
                    respuesta = true;
                }
            }

            if (this.consultaControlador.getRepetible(IDActividad))
            {
                respuesta = false;
            }

            return respuesta;
        }

        /// <summary>
        /// Indica si la actividad ya fue ejecutada en su totalidad
        /// </summary>
        /// <param name="idActividad"></param>
        /// <param name="expediente"></param>
        /// <returns></returns>
        public bool checkActividadRealizada(int idActividad, int expediente)
        {
            consultaControlador = new ConsultaControlador();
            SqlDataReader datosControlador;
            bool finalizada = false;
            datosControlador = this.consultaControlador.getDatosUnaActividad(idActividad, expediente);
            if (datosControlador != null)
            {
                while (datosControlador.Read())
                {                    
                    if (datosControlador.GetValue(2).ToString().Equals("True", StringComparison.OrdinalIgnoreCase))
                        finalizada = true;
                    else
                        finalizada = false;                    
                }
            }
            return finalizada;
        }

        /// <summary>
        /// Indica si la actividad ya fue iniciada
        /// </summary>
        /// <param name="idActividad"></param>
        /// <param name="expediente"></param>
        /// <returns></returns>
        public bool checkActividadIniciada(int idActividad, int expediente)
        {
            consultaControlador = new ConsultaControlador();
            SqlDataReader datosControlador;
            bool iniciada= false;
            datosControlador = this.consultaControlador.getDatosUnaActividad(idActividad, expediente);
            if (datosControlador != null)
            {
                while (datosControlador.Read())
                {
                    if (datosControlador.GetValue(2).ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                        iniciada= true;
                    else
                        iniciada = false;
                }
            }
            return iniciada;
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

        public int getUltimoComandoEjecutado(int IDExpediente)
        {
            consultaControlador = new ConsultaControlador();
            SqlDataReader datos;
            int respuesta = -1;
            datos = this.consultaControlador.getDatosBitacoraOrdenDescendiente(IDExpediente);
            if (datos != null)
            {
                if (datos.Read())
                {
                    respuesta = (int)datos.GetValue(0);  
                }
            }
            return respuesta;
        }

        public int getUltimoComandoReal(int IDActividad)
        {
            consultaControlador = new ConsultaControlador();
            SqlDataReader datos;
            int respuesta = -1;
            String nombreComando;
            datos = this.consultaControlador.getUltimoComandoPorActividad(IDActividad);
            if (datos != null)
            {
                if (datos.Read())
                {
                    nombreComando= datos.GetValue(0).ToString();
                    ConsultaComando tmp;
                    tmp = new ConsultaComando();
                    datos = tmp.getIDComando(nombreComando);
                    if (datos != null)
                    {
                        if (datos.Read())
                        {
                            respuesta = (int)datos.GetValue(0);
                        }

                    }
                }
            }

            return respuesta;
        }
        public void finalizarActividadBitacora(int IDExpediente, int IDActividad, Usuario user)
        {
            ConsultaControlador consult = new ConsultaControlador();
            consult.finalizarActividadBitacora(IDExpediente, IDActividad, user);
        }

    }
}
