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

            DataColumn IDFlujo = new DataColumn();
            DataColumn NombreFlujo = new DataColumn(); 
            DataColumn IDExpediente = new DataColumn();
            DataColumn Expediente = new DataColumn();
            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn fechaLimite = new DataColumn();

            IDFlujo.ColumnName = "IDFlujo";
            NombreFlujo.ColumnName = "NombreFlujo";
            IDExpediente.ColumnName = "IDExpediente";
            Expediente.ColumnName = "Expediente";
            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            fechaLimite.ColumnName = "fechaLimite";

            IDFlujo.DataType = Type.GetType("System.String");
            NombreFlujo.DataType = Type.GetType("System.String");
            IDExpediente.DataType = Type.GetType("System.String");
            Expediente.DataType = Type.GetType("System.String");
            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            fechaLimite.DataType = Type.GetType("System.String");

            tablaInbox.Columns.Add(IDFlujo);
            tablaInbox.Columns.Add(NombreFlujo);
            tablaInbox.Columns.Add(IDExpediente);
            tablaInbox.Columns.Add(Expediente);
            tablaInbox.Columns.Add(IDActividad);
            tablaInbox.Columns.Add(nombreActividad);
            tablaInbox.Columns.Add(descripcionActividad);
            tablaInbox.Columns.Add(fechaLimite);

            Controlador control = new Controlador();

            for (int i = 0; i < expedientes.Length; ++i)
            {
                //crea una actividad vacia
                this.actividad = new Actividad();
                this.actividad.setIDExpediente(expedientes[i].getCorrelativo());

                DataTable actividadesEjecutables = actividad.getDataTableActividadesEjecutablesPorIDFlujo(expedientes[i].getIDFlujo());
                String nombreFlujo = expedientes[i].getNombreFlujo();
                int numActividades = actividadesEjecutables.Rows.Count;
                //Si es administrador o dueño puede ejecutar cualquier actividad
                if (usuario.getTipo() == 0 || usuario.getTipo() == 1)
                {
                    for (int k = 0; k < numActividades; ++k)
                    {
                        fila = tablaInbox.NewRow();
                        fila["IDFlujo"] = expedientes[i].getIDFlujo();
                        fila["NombreFlujo"] = nombreFlujo;
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
                            fila["IDFlujo"] = expedientes[i].getIDFlujo();
                            fila["NombreFlujo"] = nombreFlujo;
                            fila["IDExpediente"] = expedientes[i].getCorrelativo();
                            fila["Expediente"] = expedientes[i].getNombre();
                            fila["IDActividad"] = actividadesEjecutables.Rows[k][0].ToString();
                            fila["nombreActividad"] = actividadesEjecutables.Rows[k][1].ToString();
                            fila["descripcionActividad"] = actividadesEjecutables.Rows[k][2].ToString();
                            fila["fechaLimite"] = "FECHA!!!!!";
                            actividad.setID(int.Parse(actividadesEjecutables.Rows[k][0].ToString()));
                            if(actividad.soyActividadInicial())
                                tablaInbox.Rows.Add(fila);
                        }
                    }
                    else
                    {
                        //Si es colaborados solo puede ejecutar las actividades asignadas, 
                        //si esta ya se ejecuto o no esta disponible no puede hacer nada, por lo q no se pone en el inbox
                        if (usuario.getTipo() == 3)
                        {
                            DataTable actividadesPropias = usuario.getDataTableActividadesPropias();
                            for (int k = 0; k < numActividades; ++k)
                            {
                                fila = tablaInbox.NewRow();
                                fila["IDFlujo"] = expedientes[i].getIDFlujo();
                                fila["NombreFlujo"] = nombreFlujo;
                                fila["IDExpediente"] = expedientes[i].getCorrelativo();
                                fila["Expediente"] = expedientes[i].getNombre();
                                fila["IDActividad"] = actividadesEjecutables.Rows[k][0].ToString();
                                fila["nombreActividad"] = actividadesEjecutables.Rows[k][1].ToString();
                                fila["descripcionActividad"] = actividadesEjecutables.Rows[k][2].ToString();
                                fila["fechaLimite"] = "FECHA!!!!!";
                                //comprueba si esta actividad le pertenece al Usuario
                                for (int j = 0; j < actividadesPropias.Rows.Count; ++j)
                                {
                                    //Si esta actividad pertenece al usuario se agrega, de lo contrario no.
                                    if (actividadesPropias.Rows[j][0].ToString().Equals(expedientes[i].getCorrelativo().ToString()) && actividadesPropias.Rows[j][1].ToString().Equals(actividadesEjecutables.Rows[k][0].ToString()))
                                    {
                                        tablaInbox.Rows.Add(fila);
                                    }
                                }
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
