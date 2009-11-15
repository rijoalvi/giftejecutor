using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    public class Coleccion
    {
        private String nombre;
   //     private String nombrePadre;
        private int Correlativo;
        private int CorrelativoPadre; // Correlativo del padre en cero indica que esta en la raíz
        private int correlativoFlujo;
        private ConsultaColeccion consultaColeccion;

        public List<Coleccion> coleccionesDeUnFlujo;

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

                    int correlativo = Int32.Parse(datos.GetValue(0).ToString());
                    String nombre = datos.GetValue(1).ToString();
                    int correlativoPadre = Int32.Parse(datos.GetValue(2).ToString());
                    int correlativoFlujo = Int32.Parse(datos.GetValue(3).ToString());

                    
                    //lista.Add(new Coleccion(correlativo, nombre, correlativoPadre, correlativoFlujo));


                }
            }
         //   return lista;        

        }

        public void setColeccionesDeUnFlujo(int IDFlujo,int IDPerfil){
            //this.coleccionesDeUnFlujo = this.getListTodasColeccionesDeUnFlujo(IDFlujo);
            this.coleccionesDeUnFlujo = this.getListTodasColeccionesNoAsignadasDeUnFlujo(IDFlujo, IDPerfil);
        }
   /*     public Coleccion(String nombre, String nombrePadre)
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.nombrePadre = nombrePadre;
        }
        */
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
        public void crearColeccion(){
            Correlativo = consultaColeccion.crearColeccion(nombre, CorrelativoPadre, correlativoFlujo);
        }

        public void modificarNombre() {
            consultaColeccion.modificarNombre(this.Correlativo, this.nombre);
        }

        public String[] coleccionesHijas() {
            return this.consultaColeccion.coleccionesHijas(nombre/*, nombrePadre*/);
        }

        public List<String[]> listarColecciones() {
            //List<String[]> lista = new List<string[]>();
            return this.consultaColeccion.listarColecciones();
        
        }
        public void setCorrelativoFlujo(int correlativo) {
            this.correlativoFlujo = correlativo;
        }
        public void setIDCorrelativoPadre(int IDPadre) {
            this.CorrelativoPadre = IDPadre;
        }

        public int getIDCorrelativoPadre()
        {
            return this.CorrelativoPadre;
        }
        public int getCorrelativoFlujo()
        {
            return this.correlativoFlujo;
        }
        public int getCorrelativo() {
            return this.Correlativo;
        }
        public String getNombre() {
            return this.nombre;
        }
        public String toString() {
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
        public override string ToString()
        {
            return this.nombre;
        }
    }
}
