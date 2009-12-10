using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    /// <summary>
    /// Clase que mantiene los datos de un expediente
    /// </summary>
    public class Expediente
    {
        private String nombre;
        private int correlativo;
        private int IDColeccion; // Correlativo del la coleccion a la que pertenece
        private int IDFlujo;
        private int finalizado;
        private ConsultaExpediente consultaExpediente;

        public Expediente(String nombre) {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.correlativo = -1;//IDCorrelativo;
            finalizado = 0;
        }

        /// <summary>
        /// Crea un expediente a partir del correlativo, le inicializa todos sus datos de una vez
        /// </summary>
        /// <param name="correlativo"></param>
        public Expediente(int correlativo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.correlativo = correlativo;
            SqlDataReader datos;
            datos = consultaExpediente.obtenerDatosExpediente(this.correlativo);
            if(datos.Read()){
                this.IDFlujo = int.Parse(datos.GetValue(0).ToString());
                this.IDColeccion = int.Parse(datos.GetValue(1).ToString());
                this.nombre = datos.GetValue(2).ToString();
            }
        }

        public Expediente(String nombre, int correlativoPadre, int IDFlujo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.IDFlujo = IDFlujo;
            this.IDColeccion = correlativoPadre;
            this.correlativo = consultaExpediente.buscarCorrelativo(nombre, correlativoPadre);
            Actividad act = new Actividad();
            DataTable tabla = act.getDataTableActividadesEjecutablesPorIDFlujo(this.IDFlujo);
            if (tabla.Rows.Count == 0)
            {
                finalizado = 1;
            }
            else
            {
                finalizado = 0;
            }
            Console.WriteLine("Correlativo Padre " + IDColeccion);
        }

        public Expediente(int correlativo,String nombre, int correlativoPadre, int IDFlujo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.IDFlujo = IDFlujo;
            this.IDColeccion = correlativoPadre;
            this.correlativo = correlativo;// consultaExpediente.buscarCorrelativo(nombre, correlativoPadre);
            Actividad act = new Actividad();
            DataTable tabla = act.getDataTableActividadesEjecutablesPorIDFlujo(this.IDFlujo);
            if (tabla.Rows.Count == 0)
            {
                finalizado = 1;
            }
            else
            {
                finalizado = 0;
            }
        }

        public Expediente(String nombre, int correlativo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.correlativo = correlativo;
            this.finalizado = 0;
        }
               
        public void crearExpediente(){
            correlativo = consultaExpediente.crearExpediente(nombre, IDColeccion, IDFlujo);
        }

        /// <summary>
        /// Lista todos los expedientes creados
        /// </summary>
        /// <returns></returns>
        public List<String[]> listarExpedientes()
        {
            return this.consultaExpediente.listarExpedientes();
        }

        /// <summary>
        /// Devuelve todos los expedientes creados
        /// </summary>
        /// <returns></returns>
        public List<Expediente> getTodosLosExpedientes()
        {            
            SqlDataReader datos;
            datos = consultaExpediente.obtenerTodosLosExpedientes();
            List<Expediente> expedientes = new List<Expediente>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    int idExp = Int32.Parse(datos.GetValue(0).ToString());
                    String nombreExp = datos.GetValue(3).ToString();
                    Expediente expTemp = new Expediente(nombreExp, idExp);
                    expTemp.setIDFlujo(Int32.Parse(datos.GetValue(1).ToString())); 
                    expTemp.setIDColeccion(Int32.Parse(datos.GetValue(2).ToString()));                    
                    expedientes.Add(expTemp);
                }
            }
            return expedientes;
        }

        /// <summary>
        /// Devuelve una lista con todos los expedientes que pueden ser asignados al usuario
        /// </summary>
        /// <param name="idUsuario">El usuario al cual se le quieren ver los expedientes que le pueden ser asignados</param>
        /// <returns></returns>
        public List<Expediente> getTodosLosExpedientes(int idUsuario)
        {
            SqlDataReader datos;
            datos = consultaExpediente.obtenerTodosLosExpedientes(idUsuario);
            List<Expediente> expedientes = new List<Expediente>();
            if (datos != null)
            {
                while (datos.Read())
                {
                    int idExp = Int32.Parse(datos.GetValue(0).ToString());
                    String nombreExp = datos.GetValue(3).ToString();
                    Expediente expTemp = new Expediente(nombreExp, idExp);
                    expTemp.setIDFlujo(Int32.Parse(datos.GetValue(1).ToString()));
                    expTemp.setIDColeccion(Int32.Parse(datos.GetValue(2).ToString()));
                    expedientes.Add(expTemp);
                }
            }
            return expedientes;
        }

        /// <summary>
        /// Asigna al usuario recibido de parámetro el expediente
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idExpediente"></param>
        public void agregarAsignacion(int idUsuario, int idExpediente)
        {
            this.consultaExpediente.agregarAsignacion(idUsuario, idExpediente);
        }

        /// <summary>
        /// Modifica el nombre del expediente
        /// </summary>
        public void modificarNombre()
        {
            this.consultaExpediente.modificarNombre(this.correlativo, this.nombre);
        }

        /// <summary>
        /// Devuelve el ID del expediente
        /// </summary>
        /// <returns></returns>
        public int getIDExpediente()
        {
            return correlativo;
        }

        /// <summary>
        /// Devuelve el nombre del flujo
        /// </summary>
        /// <returns></returns>
        public String getNombreFlujo() {
            return consultaExpediente.getNombreFlujo(this.IDFlujo);
        }


        public int getIDFlujo()
        {
            return IDFlujo;
        }

        public void setIDFlujo(int elID)
        {
            this.IDFlujo = elID;
        }

        /// <summary>
        /// Asigna la coleccion a la cual pertenece el expediente
        /// </summary>
        /// <param name="elID"></param>
        public void setIDColeccion(int elID)
        {
            this.IDColeccion = elID;
        }

        /// <summary>
        /// Indica a que colección pertenece
        /// </summary>
        /// <returns></returns>
        public int getIDColeccion() {
            return this.IDColeccion;
        }

        /// <summary>
        /// Devuelve el nombre del expediente
        /// </summary>
        /// <returns></returns>
        public String getNombre() {
            return this.nombre;
        }

        /// <summary>
        /// Indica el ID del expediente
        /// </summary>
        /// <returns></returns>
        public int getCorrelativo() {
            return this.correlativo;
        }

        /// <summary>
        /// Elimina el expediente
        /// </summary>
        public void eliminar() {
            this.consultaExpediente.eliminarExpediente(this.correlativo, this.nombre);
        }

        /// <summary>
        /// Indica si el expediente ya fue finalizado
        /// </summary>
        /// <returns></returns>
        public int yaFinalizado() {
            if (this.finalizado == 0)
            {
                Actividad act = new Actividad();
                act.setIDExpediente(this.correlativo);
                DataTable tabla = act.getDataTableActividadesEjecutablesPorIDFlujo(this.IDFlujo);
                if(tabla.Rows.Count==0){
                    finalizado = 1;
                }
            }
            return finalizado;
        }

        public override String ToString()
        {
            return this.nombre;
        }

    }
}
