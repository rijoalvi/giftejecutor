using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que posee todos los detalles de un flujo de trabajo
    /// </summary>
    class FlujoTrabajo
    {
        ConsultaFlujoTrabajo consultaFlujoTrabajo;
        int correlativo;
        String nombre;
        String descripcion;
        String fechaActualizacion;
        public List<FlujoTrabajo> flujosTrabajo;//para cuando quiero recibir todos los flujos

        /// <summary>
        /// Llena todos los datos del flujo según su ID
        /// </summary>
        /// <param name="IDPerfil"></param>
        public void setDatosPorID(int IDPerfil)
        {
            SqlDataReader datos;
            datos = this.consultaFlujoTrabajo.selectFlujoTrabajoPorID(IDPerfil);
            if (datos != null)
            {
                while (datos.Read())
                {
                    this.correlativo = Int32.Parse( datos.GetValue(0).ToString()) ;
                    this.nombre = datos.GetValue(1).ToString();
                    this.descripcion = datos.GetValue(2).ToString();
                    this.fechaActualizacion = datos.GetValue(3).ToString();
                }
            }

        }

        public FlujoTrabajo(int correlativo, String nombre, String descripcion) {
            this.correlativo = correlativo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            consultaFlujoTrabajo = new ConsultaFlujoTrabajo();
        }

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public FlujoTrabajo() {
            consultaFlujoTrabajo = new ConsultaFlujoTrabajo();
            this.flujosTrabajo = this.getListaTodosLosFlujosDeTrabajo();
        }

        /// <summary>
        /// Constructor que recibe el ID
        /// </summary>
        /// <param name="correlativoFlujo"></param>
        public FlujoTrabajo(int correlativoFlujo) {
            this.correlativo = correlativoFlujo;
            consultaFlujoTrabajo = new ConsultaFlujoTrabajo();
            String [] datos = consultaFlujoTrabajo.getDatosFlujo(correlativo);            
        }
        public FlujoTrabajo(int IDFlujo,int NOseUSA)
        {
            //this.correlativo = correlativoFlujo;
            consultaFlujoTrabajo = new ConsultaFlujoTrabajo();
            this.setDatosPorID(IDFlujo);
        }

        /// <summary>
        /// Devuelve un dataTable con todos los datos del flujo de trabajo instanciado
        /// </summary>
        /// <returns></returns>        
        public DataTable getDataTableFlujoDeTrabajo() {
            
            String [] datos = consultaFlujoTrabajo.getDatosFlujo(this.correlativo);

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
            fila = tabla.NewRow();
            fila["IDFlujo"] = this.correlativo;
            fila["nombre"] = datos[0];
            fila["descripcion"] = datos[1];
            tabla.Rows.Add(fila);
                
            
            return tabla;
        
        }

        /// <summary>
        /// Obtiene el nombre del flujo
        /// </summary>
        /// <returns></returns>
        public String getNombreFlujo()
        {
            String[] datos = consultaFlujoTrabajo.getDatosFlujo(this.correlativo);
            return (datos[0]);

        }

        /// <summary>
        /// Devuelve un dataTable con todos los flujos creados en el configurador
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTableTodosLosFlujosDeTrabajo()
        {
            SqlDataReader datos;
            datos = consultaFlujoTrabajo.getTodosLosFlujosTrabajo();

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
            if (datos != null){
                while (
                datos.Read())
                {
                    fila = tabla.NewRow();
                    fila["IDFlujo"] = datos.GetValue(0);
                    fila["nombre"] = datos.GetValue(1);
                    fila["descripcion"] = datos.GetValue(2).ToString();
                    tabla.Rows.Add(fila);
                }
            }
            return tabla;
        }


        public List<FlujoTrabajo> getListaTodosLosFlujosDeTrabajo()
        {
            List<FlujoTrabajo> lista = new List<FlujoTrabajo>();
            SqlDataReader datos;
            datos = consultaFlujoTrabajo.getTodosLosFlujosTrabajo();

            if (datos != null)
            {
                while (
                datos.Read())
                {
                    int IDFlujo = Int32.Parse(datos.GetValue(0).ToString());
                    lista.Add(new FlujoTrabajo(IDFlujo,-1));
         
                }
            }
            return lista;
        }

        public DataTable getFlujoTrabajo(int correlativo)
        {
            ///datos[0] = nombre,datos[1]=descripcion
            String[] datos = consultaFlujoTrabajo.getDatosFlujo(correlativo);//getTodosLosFlujosTrabajo();
            
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
                fila = tabla.NewRow();
                fila["IDFlujo"] = correlativo.ToString();
                fila["nombre"] = datos[0];
                fila["descripcion"] = datos[1];
                tabla.Rows.Add(fila);            
            }
            return tabla;
        }

        /// <summary>
        /// Devuelve una tabla con los flujos ya construidos
        /// </summary>
        /// <returns></returns>
        public DataTable getFlujosConstruidos() {
            DataTable todosFlujos = getDataTableTodosLosFlujosDeTrabajo();            

            SqlDataReader datos;
            datos = consultaFlujoTrabajo.getFlujosConstruidos();
            String[] idsFlujosConstruidos = new String[todosFlujos.Rows.Count];
            if (datos != null)
            {
                int cant = 0;
               // while (cant < todosFlujos.Rows.Count)
               // {
                    while (datos.Read())
                    {
                        idsFlujosConstruidos[cant++] = datos.GetValue(0).ToString();                        
                    }
                //    cant++;
                //}
            }
            //Va recorriendo todos los flujos existentes
            for (int k = todosFlujos.Rows.Count - 1; k >= 0; --k)
            {
                String idTemp = todosFlujos.Rows[k]["IDFlujo"].ToString();
                bool construido = false;
                //Elimina los valores que no fueron construidos
                for (int i = 0; i < idsFlujosConstruidos.Length; ++i)
                {
                    if (idTemp == idsFlujosConstruidos[i])
                    {
                        construido = true;
                        i = idsFlujosConstruidos.Length;
                    }
                }
                //Si no fue construido se elimina
                if (!construido)
                    todosFlujos.Rows[k].Delete();
            }
            return todosFlujos;        
        }

        /// <summary>
        /// Devuelve un dataTable con la informacion de los flujos que no han sido construidos todavia
        /// </summary>
        /// <returns></returns>
        public DataTable getFlujosSinConstruir()
        {
            DataTable todosFlujos = getDataTableTodosLosFlujosDeTrabajo();

            SqlDataReader datos;
            datos = consultaFlujoTrabajo.getFlujosConstruidos();
            if (datos != null)
            {
                while (datos.Read())
                {
                    //Lee el ID del flujo construido
                    String idConstruido = datos.GetValue(0).ToString();
                    for (int i = todosFlujos.Rows.Count - 1; i >= 0; --i)
                    {
                        //Cuando lo encuentra en la tabla, lo elimina
                        if (idConstruido == todosFlujos.Rows[i]["IDFlujo"].ToString())
                        {
                            todosFlujos.Rows[i].Delete();
                        }
                    }
                }                        
            }
            return todosFlujos;    
        }

        /// <summary>
        /// Devuelve el ID del flujo
        /// </summary>
        /// <returns></returns>
        public int getCorrelativo() {
            return this.correlativo;
        }

        /// <summary>
        /// Sobreescribe el método to String, para que devuelva el nombre
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return this.nombre;
        }
    }
}
