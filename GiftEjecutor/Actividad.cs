using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GiftEjecutor
{
    class Actividad
    {
        // private ConfiguracionProyecto configuracion;
        ConsultaActividad consultaActividad;
        private int ID;
        private string nombre;
        private string descripcion;
        private int tipo;
        private string nombreTipo;
        private DateTime fechaActualizacion;
        private int IDExpediente;//falta cargarlo

        public Actividad() {
            consultaActividad = new ConsultaActividad();
            //this.configuracion = new ConfiguracionProyecto();
            this.ID = -1;
            this.nombre = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.descripcion = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.tipo = -1;
            this.nombreTipo = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.fechaActualizacion = new DateTime(1111, 1, 11);

        }

        public int getID()
        {
            return this.ID;
        }
        public void setIDExpediente(int IDExpediente)
        {
            this.IDExpediente = IDExpediente;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public string getDescripcion()
        {
            return this.descripcion;
        }
        public void setAtributosSegunID(int IDActividad)
        {
            SqlDataReader datosActividad;

            datosActividad = this.consultaActividad.getDatosPorID(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                    this.ID = System.Int32.Parse(datosActividad.GetValue(0).ToString());
                    this.nombre = datosActividad.GetValue(1).ToString();
                    this.descripcion = datosActividad.GetValue(2).ToString();
                    //this.tipo = System.Int32.Parse(datosActividad.GetValue(3).ToString());
                    this.nombreTipo = this.getTipo(this.tipo.ToString());
                    //this.fechaActualizacion = datosActividad.GetValue(5);
                }
            }
        }

        public DataTable getDataTableActividadesPorIDFlujo(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;


            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();


            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);

            SqlDataReader datos;

            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    tablaActividades.Rows.Add(fila);
                }
            }
            return tablaActividades;
        }

        public override string ToString()
        {
            return "Nombre: " + this.nombre + "" + '\n' +
                "Descripción: " + this.descripcion + "" + '\n' +
                "Tipo: " + this.tipo + "" + '\n' +
                "NombreTipo: " + this.nombreTipo + "" + '\n' +
                "IDExpediente: " + this.IDExpediente + "" + '\n' +
                "Fecha Actualización: " + this.fechaActualizacion + ""// + '\n' + 
                ;
        }

        private string getTipo(string tipo)
        {
            switch (tipo)
            {
                case "true":
                    return "Simple";
                case "false":
                    return "Compuesta";
                default:
                    return "[Mal especifícado]";
            }
        }
    }
}
