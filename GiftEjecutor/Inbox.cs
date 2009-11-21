using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiftEjecutor
{
    class Inbox
    {

        private Actividad actividad;
        private ConsultaActividad consultaActividad;
        private Usuario usuario;
        //private int IDFlujo;

        public Inbox(Usuario user) {
            consultaActividad = new ConsultaActividad();
            this.usuario = user;
        }

        public DataTable llenarDataGridInbox(Expediente[] expedientes)
        {
            DataTable tablaInbox = new DataTable(); ;
            DataRow fila;

            DataColumn IDExpediente = new DataColumn();
            DataColumn Expediente = new DataColumn();
            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn fechaLimite = new DataColumn();

            IDExpediente.ColumnName = "IDExpediente";
            Expediente.ColumnName = "Expediente";
            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            fechaLimite.ColumnName = "fechaLimite";

            IDExpediente.DataType = Type.GetType("System.String");
            Expediente.DataType = Type.GetType("System.String");
            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            fechaLimite.DataType = Type.GetType("System.String");

            tablaInbox.Columns.Add(IDExpediente);
            tablaInbox.Columns.Add(Expediente);
            tablaInbox.Columns.Add(IDActividad);
            tablaInbox.Columns.Add(nombreActividad);
            tablaInbox.Columns.Add(descripcionActividad);
            tablaInbox.Columns.Add(fechaLimite);

            Controlador control = new Controlador();
            SqlDataReader datos;

            for (int i = 0; i < expedientes.Length; ++i)
            {
                //crea una actividad vacia
                this.actividad = new Actividad();
                this.actividad.setIDExpediente(expedientes[i].getCorrelativo());

                //******************************************************************
                int IDFlujo = 1;
                //******************************************************************
                DataTable actividadesEjecutables = actividad.getDataTableActividadesEjecutablesPorIDFlujo(IDFlujo);
                int numActividades = actividadesEjecutables.Rows.Count;
                //Si es administrador o dueño puede ejecutar cualquier actividad
                if (usuario.getTipo() == 0 || usuario.getTipo() == 1)
                {
                    for (int k = 0; k < numActividades; ++k)
                    {
                        fila = tablaInbox.NewRow();
                        fila["IDExpediente"] = expedientes[i].getCorrelativo();
                        fila["Expediente"] = expedientes[i].getNombre();
                        fila["IDActividad"] = actividadesEjecutables.Rows[k][0].ToString();
                        fila["nombreActividad"] = actividadesEjecutables.Rows[k][1].ToString();
                        fila["descripcionActividad"] = actividadesEjecutables.Rows[k][2].ToString();
                        fila["fechaLimite"] = "FECHA!!!!!";
                        tablaInbox.Rows.Add(fila);
                    }
                }
                else {
                    //Si es creador solo puede ejecutar la actividad inicial, 
                    //si esta ya se ejecuto no puede hacer nada, por lo q no se pone en el inbox
                    if (usuario.getTipo() == 2)
                    {
                        for (int k = 0; k < numActividades; ++k)
                        {
                            fila = tablaInbox.NewRow();
                            fila["IDExpediente"] = expedientes[i].getCorrelativo();
                            fila["Expediente"] = expedientes[i].getNombre();
                            fila["IDActividad"] = actividadesEjecutables.Rows[k][0].ToString();
                            fila["nombreActividad"] = actividadesEjecutables.Rows[k][1].ToString();
                            fila["descripcionActividad"] = actividadesEjecutables.Rows[k][2].ToString();
                            tablaInbox.Rows.Add(fila);
                        }
                    }
                    else
                    {
                        //Si es colaborados solo puede ejecutar las actividades asignadas, 
                        //si esta ya se ejecuto o no esta disponible no puede hacer nada, por lo q no se pone en el inbox
                        if (usuario.getTipo() == 3)
                        {
                            for (int k = 0; k < numActividades; ++k)
                            {
                                fila = tablaInbox.NewRow();
                                fila["IDExpediente"] = expedientes[i].getCorrelativo();
                                fila["Expediente"] = expedientes[i].getNombre();
                                fila["IDActividad"] = actividadesEjecutables.Rows[k][0].ToString();
                                fila["nombreActividad"] = actividadesEjecutables.Rows[k][1].ToString();
                                fila["descripcionActividad"] = actividadesEjecutables.Rows[k][2].ToString();
                                tablaInbox.Rows.Add(fila);
                            }
                        }
                    }
                }
            }
            /*
            //esto nos indica si ya se agrego una actividad a ejecutables x lo tanto las siguientes no tienen suficientes requisitos
            bool unaEjecutable = false;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDExpediente"] = datos.GetValue(1);
                    fila["Expediente"] = datos.GetValue(2);
                    fila["IDActividad"] = datos.GetValue(3);
                    fila["nombreActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["descripcionActividad"] = datos.GetValue(6).ToString();

                    tablaActividades.Rows.Add(fila);
                }
            }*/
            return tablaInbox;
        }
    }
}
