using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    /// <summary>
    /// Clase que maneja las colecciones de los flujos, sobre las cuales se acomodan los expedientes.
    /// </summary>
    public class Coleccion
    {
        private String nombre;
   //     private String nombrePadre;
        private int Correlativo;
        private int CorrelativoPadre; // Correlativo del padre en cero indica que esta en la raíz
        private int correlativoFlujo;
        private ConsultaColeccion consultaColeccion;

        public List<Coleccion> coleccionesDeUnFlujo;

        /// <summary>
        /// Constructor por omisión
        /// </summary>
        public Coleccion()
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = "-1";
            this.CorrelativoPadre = -1;
            this.Correlativo = -1;
        }
        public Coleccion(String nombre) {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.Correlativo = -1;//IDCorrelativo;
        }

        /// <summary>
        /// Constructor que recibe el ID de la colección que se desea abrir
        /// </summary>
        /// <param name="IDColeccion"></param>
        public Coleccion(int IDColeccion)
        {
            consultaColeccion = new ConsultaColeccion();
            this.setColeccion(IDColeccion);
        }
                
        public void setColeccion(int IDColeccion){

         //   List<Coleccion> lista = new List<Coleccion>();


            SqlDataReader datos;
            datos = this.consultaColeccion.selectUnFlujo(IDColeccion);
            if (datos != null)
            {
                while (datos.Read())
                {

                    this.Correlativo= Int32.Parse(datos.GetValue(0).ToString());
                    this.nombre= datos.GetValue(1).ToString();
                    this.CorrelativoPadre = Int32.Parse(datos.GetValue(2).ToString());
                    this.correlativoFlujo = Int32.Parse(datos.GetValue(3).ToString());

                    
                    //lista.Add(new Coleccion(correlativo, nombre, correlativoPadre, correlativoFlujo));
                }
            }    
        }

        public void setColeccionesDeUnFlujo(int IDFlujo,int IDPerfil){
            //this.coleccionesDeUnFlujo = this.getListTodasColeccionesDeUnFlujo(IDFlujo);
            this.coleccionesDeUnFlujo = this.getListTodasColeccionesNoAsignadasDeUnFlujo(IDFlujo, IDPerfil);
        }

        public Coleccion(String nombre, int correlativoPadre,int correlativoFlujo)
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.CorrelativoPadre = correlativoPadre;
            this.correlativoFlujo = correlativoFlujo;
            Console.WriteLine("Correlativo Padre " + CorrelativoPadre);
        }
        public Coleccion(int correlativo, String nombre, int correlativoPadre, int correlativoFlujo)
        {
            consultaColeccion = new ConsultaColeccion();
            this.Correlativo = correlativo;
            this.nombre = nombre;
            this.CorrelativoPadre = correlativoPadre;
            this.correlativoFlujo = correlativoFlujo;
            Console.WriteLine("Correlativo Padre " + CorrelativoPadre);

        }

        /// <summary>
        /// Crea una nueva colección en BD
        /// </summary>
        public void crearColeccion(){
            Correlativo = consultaColeccion.crearColeccion(nombre, CorrelativoPadre, correlativoFlujo);
        }

        /// <summary>
        /// Cambia el nombre de la colección
        /// </summary>
        public void modificarNombre() {
            consultaColeccion.modificarNombre(this.Correlativo, this.nombre);
        }

        /// <summary>
        /// Indica cuales son las colecciones hijas
        /// </summary>
        /// <returns></returns>
        public String[] coleccionesHijas() {
            return this.consultaColeccion.coleccionesHijas(nombre/*, nombrePadre*/);
        }

        /// <summary>
        /// Lista todas las colecciones almacenadas
        /// </summary>
        /// <returns></returns>
        public List<String[]> listarColecciones() {
            //List<String[]> lista = new List<string[]>();
            return this.consultaColeccion.listarColecciones();
        
        }

        /// <summary>
        /// Indica el correlativo del flujo a la cual pertenece la coleccion
        /// </summary>
        /// <param name="correlativo"></param>
        public void setCorrelativoFlujo(int correlativo) {
            this.correlativoFlujo = correlativo;
        }

        /// <summary>
        /// Indica el correlativo de la colección padre
        /// </summary>
        /// <param name="IDPadre"></param>
        public void setIDCorrelativoPadre(int IDPadre) {
            this.CorrelativoPadre = IDPadre;
        }

        /// <summary>
        /// Devuelve el ID de la colección padre
        /// </summary>
        /// <returns></returns>
        public int getIDCorrelativoPadre()
        {
            return this.CorrelativoPadre;
        }

        /// <summary>
        /// Devuelve el ID del flujo al cual pertenece
        /// </summary>
        /// <returns></returns>
        public int getCorrelativoFlujo()
        {
            return this.correlativoFlujo;
        }

        /// <summary>
        /// Devuelve el correlativo de la colección
        /// </summary>
        /// <returns></returns>
        public int getCorrelativo() {
            return this.Correlativo;
        }

        /// <summary>
        /// Obtiene el nombre
        /// </summary>
        /// <returns></returns>
        public String getNombre() {
            return this.nombre;
        }

        public List<Coleccion> getListTodasColeccionesDeUnFlujo(int IDFlujo)
        {

            List<Coleccion> lista = new List<Coleccion>();


            SqlDataReader datos;
            datos = this.consultaColeccion.getlistaColeccionesDeUnFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {

                    int correlativo = Int32.Parse(datos.GetValue(0).ToString());
                    String nombre = datos.GetValue(1).ToString();
                    int correlativoPadre = Int32.Parse(datos.GetValue(2).ToString());
                    int correlativoFlujo = Int32.Parse(datos.GetValue(3).ToString());
                    lista.Add(new Coleccion(correlativo, nombre, correlativoPadre, correlativoFlujo));


                }
            }
            return lista;
        }

        public List<Coleccion> getListTodasColeccionesNoAsignadasDeUnFlujo(int IDFlujo, int IDPerfil)
        {

            List<Coleccion> lista = new List<Coleccion>();


            SqlDataReader datos;
            datos = this.consultaColeccion.getlistaColeccionesNoAsignadasDeUnFlujo(IDFlujo, IDPerfil);
            if (datos != null)
            {
                while (datos.Read())
                {

                    int correlativo = Int32.Parse(datos.GetValue(0).ToString());
                    String nombre = datos.GetValue(1).ToString();
               //     int correlativoPadre = Int32.Parse(datos.GetValue(2).ToString());
                //    int correlativoFlujo = Int32.Parse(datos.GetValue(3).ToString());*/
                   lista.Add(new Coleccion(correlativo,nombre,-1,-1));


                }
            }
            return lista;
        }

        public List<Coleccion> getListTodasColeccionesAsignadasDeUnFlujoDeUnPerfil(int IDFlujo, int IDPerfil)
        {

            List<Coleccion> lista = new List<Coleccion>();


            SqlDataReader datos;
            datos = this.consultaColeccion.getlistaColeccionesAsignadasDeUnFlujoAUnPerfil(IDFlujo, IDPerfil);
            if (datos != null)
            {
                while (datos.Read())
                {

                    int correlativo = Int32.Parse(datos.GetValue(0).ToString());
                    String nombre = datos.GetValue(1).ToString();
                    //     int correlativoPadre = Int32.Parse(datos.GetValue(2).ToString());
                    //    int correlativoFlujo = Int32.Parse(datos.GetValue(3).ToString());*/
                    lista.Add(new Coleccion(correlativo, nombre, -1, -1));


                }
            }
            return lista;
        }

        /// <summary>
        /// Modifica el toString para que se observe el nombre
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.nombre;
        }
    }
}
