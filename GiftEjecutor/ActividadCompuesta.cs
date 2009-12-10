using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que hereda de Actividad, contiene metodos y miembros específicos para las actividades compuestas
    /// </summary>
    class ActividadCompuesta: Actividad
    {
        public bool miEsParalela;
        public bool miEsExclusiva;
        ConsultaActividaCompuesta consultaActividadCompuesta;

        /// <summary>
        /// Devuelve el dataTable con las actividades hijas de una actividad segun su ID
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>                
        public ActividadCompuesta() {
            consultaActividadCompuesta = new ConsultaActividaCompuesta();
        }

        /// <summary>
        /// Llena sus atributos segun el ID
        /// </summary>
        /// <param name="IDActividad"></param>
        public void setAtributosPorID(int IDActividad) {
            base.setAtributosSegunID(IDActividad);
            this.setAtributosDeActividadCompuesta(IDActividad);
        
        }

        /// <summary>
        /// Modifica el ToString para que se muestre el nombre de la actividad, pero tambíén si es paralela y exlcusiva
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "[esParalela: " + this.miEsParalela + "] [esExclusiva: " + miEsExclusiva + "]";
        }

        public override void setAtributosSegunID(int IDActividad)
        {
            base.setAtributosSegunID(IDActividad);
            SqlDataReader datosActividad = null;

            datosActividad = this.consultaActividadCompuesta.getDatosExtendidosPorID(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                    this.miEsParalela = bool.Parse(datosActividad.GetValue(5).ToString());
                    this.miEsExclusiva = bool.Parse(datosActividad.GetValue(6).ToString());

                }
            }

        }

        public void setAtributosDeActividadCompuesta(int IDActividad){
            SqlDataReader datosActividad=null;

            datosActividad = this.consultaActividadCompuesta.getDatosExtendidosPorID(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                //    this.ID = System.Int32.Parse(datosActividad.GetValue(0).ToString());
                    base.esParalela = bool.Parse(datosActividad.GetValue(5).ToString());
                    base.esExclusiva = bool.Parse(datosActividad.GetValue(6).ToString());
                 //   //this.tipo = System.Int32.Parse(datosActividad.GetValue(3).ToString());
                 //   this.nombreTipo = this.getTipo(this.tipo.ToString());
                    //this.fechaActualizacion = datosActividad.GetValue(5);
                }
            }
        }

        /// <summary>
        /// Obtiene el DataTable de todas las actividades hijas
        /// </summary>
        /// <param name="IDActividadPadre"></param>
        /// <returns></returns>
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
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

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
                    fila["repetible"] = datos.GetValue(6).ToString();

                    tablaActividades.Rows.Add(fila);

                }
            }
            return tablaActividades;
        }

        /// <summary>
        /// Indica el tipo de la actividad
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
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
