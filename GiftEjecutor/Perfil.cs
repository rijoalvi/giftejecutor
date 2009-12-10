using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que configura un perfil, su tipo y derechos
    /// </summary>
    public class Perfil
    {
        ConsultaPerfil consultaPerfil;

        private int correlativo;
        private String nombre;
        private String tipo;
        private String fechaActualizacion;
        public List<Perfil> perfiles;// = new List<string>();

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public Perfil() {
            consultaPerfil = new ConsultaPerfil();
            //this.perfiles = new List<Perfil>();
            this.perfiles = this.getListTodosPerfiles();
        }
                
        /// <summary>
        /// Constructor que recibe el ID del perfil para abrir
        /// </summary>
        /// <param name="IDPerfil"></param>
        public Perfil(int IDPerfil) {
            consultaPerfil = new ConsultaPerfil();
            this.setDatosPorID(IDPerfil);
        }

        public Perfil(int correlativo, String nombre, String tipo, String fechaActualizacion) {
            this.setDatos(correlativo, nombre, tipo, fechaActualizacion);
        }

        /// <summary>
        /// Llena los datos del perfil
        /// </summary>
        /// <param name="correlativo"></param>
        /// <param name="nombre"></param>
        /// <param name="tipo"></param>
        /// <param name="fechaActualizacion"></param>
        public void setDatos(int correlativo, String nombre, String tipo, String fechaActualizacion){
            this.correlativo=correlativo;
            this.nombre=nombre;
            this.tipo=tipo;
            this.fechaActualizacion=fechaActualizacion;
        }
        /// <summary>
        /// Devuelve un DataTable para un DataGridView con todos los perfiles registrados en la BD
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable getDataTableTodosPerfiles() {

            DataTable tablaPerfiles = new DataTable();
            DataRow fila;

            DataColumn IDPerfil = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn tipo = new DataColumn();
            DataColumn fechaActualizacion = new DataColumn();
            DataColumn IDFlujo = new DataColumn();

            IDPerfil.ColumnName = "IDPerfil";
            nombre.ColumnName = "nombre";
            tipo.ColumnName = "tipo";
            fechaActualizacion.ColumnName = "fechaActualizacion";
            IDFlujo.ColumnName = "IDFlujo";

            IDPerfil.DataType = Type.GetType("System.String");
            nombre.DataType = Type.GetType("System.String");
            tipo.DataType = Type.GetType("System.String");
            fechaActualizacion.DataType = Type.GetType("System.String");
            IDFlujo.DataType = Type.GetType("System.String");

            tablaPerfiles.Columns.Add(IDPerfil);
            tablaPerfiles.Columns.Add(nombre);
            tablaPerfiles.Columns.Add(tipo);
            tablaPerfiles.Columns.Add(fechaActualizacion);
            tablaPerfiles.Columns.Add(IDFlujo);

            
            SqlDataReader datos;
            datos = this.consultaPerfil.getTodosPerfiles();
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaPerfiles.NewRow();
                    fila["IDPerfil"] = datos.GetValue(0).ToString(); ;
                    fila["nombre"] = datos.GetValue(1).ToString();
                    fila["tipo"] = datos.GetValue(2).ToString();
                    fila["fechaActualizacion"] = datos.GetValue(3).ToString();
                    fila["IDFlujo"] = datos.GetValue(4).ToString();
                    tablaPerfiles.Rows.Add(fila);
                }
            }
            return tablaPerfiles;
        }

        /// <summary>
        /// Devuleve una lista de todos los perfiles creados
        /// </summary>
        /// <returns></returns>
        public List<Perfil> getListTodosPerfiles()
        {

            List<Perfil> lista=new List<Perfil>();


            SqlDataReader datos;
            datos = this.consultaPerfil.getTodosPerfiles();
            if (datos != null)
            {
                while (datos.Read())
                {

                    int IDPerfil = Int32.Parse(datos.GetValue(0).ToString());
                    String nombre = datos.GetValue(1).ToString();
                    String tipo = datos.GetValue(2).ToString();
                    String fechaActualizacion = datos.GetValue(3).ToString();  
                    lista.Add(new Perfil(IDPerfil,nombre,tipo,fechaActualizacion));
                }
            }
            return lista;
        }

        /// <summary>
        /// Agrega un nuevo perfil
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipo"></param>
        /// <param name="IDFlujo"></param>
        public void addNuevoPerfil(String nombre, String tipo, int IDFlujo){
            this.consultaPerfil.insertPerfil(nombre, tipo);
        }

        /// <summary>
        /// Elimina un perfil
        /// </summary>
        /// <param name="IDPerfil"></param>
        public void deletePerfil(int IDPerfil) {
            this.consultaPerfil.deletePerfil(IDPerfil);
        
        }


        public void setDatosPorID(int IDPerfil){
            SqlDataReader datos;
            datos = this.consultaPerfil.selectPerfilPorID(IDPerfil);
            if (datos != null)
            {
                while (datos.Read())
                {                    
                    this.correlativo= int.Parse(datos.GetValue(0).ToString());
                    this.nombre= datos.GetValue(1).ToString();
                    this.tipo=datos.GetValue(2).ToString();
                    this.fechaActualizacion = datos.GetValue(3).ToString();
                }
            }
    
        }

        /// <summary>
        /// MOdifica el toString para que muestre el nombre
        /// </summary>
        /// <returns></returns>
        public override String ToString() {
            return this.nombre;
        }

        /// <summary>
        /// Devuelve el correlativo
        /// </summary>
        /// <returns></returns>
        public int getCorrelativo()
        {
            return correlativo;
        }

        /// <summary>
        /// Devuelve el tipo del perfil
        /// </summary>
        /// <returns></returns>
        public String getTipo()
        {
            return this.tipo;
        }

        /// <summary>
        /// Devuelve el nombre del perfil
        /// </summary>
        /// <returns></returns>
        public String getNombre()
        {
            return this.nombre;
        }

        /// <summary>
        /// Le asigna una coleccion al perfil
        /// </summary>
        /// <param name="IDColeccion"></param>
        public void asignarColeccion(int IDColeccion) {
            this.consultaPerfil.asignarColeccion(this.correlativo, IDColeccion);
        }

        /// <summary>
        /// Le desagina una coleccion al perfil
        /// </summary>
        /// <param name="IDColeccion"></param>
        public void desasignarColeccion(int IDColeccion)
        {
            this.consultaPerfil.desasignarColeccion(this.correlativo, IDColeccion);
        }

        /// <summary>
        /// Obtiene un listado de las colecciones
        /// </summary>
        /// <returns></returns>
        public List<Coleccion> obtenerColecciones() {
            List<Coleccion> lista = new List<Coleccion>();
            SqlDataReader datos = this.consultaPerfil.obtenerColecciones(this.correlativo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    int idColeccion = Int32.Parse(datos.GetValue(0).ToString());
                    Coleccion nueva = new Coleccion(idColeccion);
                    lista.Add(nueva);
                }
            }
            return lista;
        
        }

        /// <summary>
        /// Indica si la colección ya esta asignada al perfil
        /// </summary>
        /// <param name="IDExpediente"></param>
        /// <param name="IDActividad"></param>
        /// <returns></returns>
        public bool existeColeccionEnPerfil(int IDExpediente, int IDActividad)
        {
            bool respuesta = false;
            Expediente e = new Expediente(IDExpediente);
            int coleccion = e.getIDColeccion();
            SqlDataReader datos;
            datos = this.consultaPerfil.buscarColeccionEnPerfil(coleccion, correlativo, IDActividad);
            if (datos != null)
            {
                if(datos.Read()){
                    respuesta = true;
                }
            }
            return respuesta;
        }

    }
}
