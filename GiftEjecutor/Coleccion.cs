using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class Coleccion
    {
        private String nombre;
   //     private String nombrePadre;
        private int IDCorrelativo;
        private int IDCorrelativoPadre; // Correlativo del padre en cero indica que esta en la raíz
        private int correlativoFlujo;
        private ConsultaColeccion consultaColeccion;

        public List<Coleccion> coleccionesDeUnFlujo;

        public Coleccion()
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = "-1";
            this.IDCorrelativoPadre = -1;
            this.IDCorrelativo = -1;
        }
        public Coleccion(String nombre) {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.IDCorrelativo = -1;//IDCorrelativo;
        }

        public void setColeccionesDeUnFlujo(int IDFlujo){
            this.coleccionesDeUnFlujo = this.getListTodasColeccionesDeUnFlujo(IDFlujo);
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
            this.IDCorrelativoPadre = correlativoPadre;
            this.correlativoFlujo = correlativoFlujo;
            Console.WriteLine("Correlativo Padre " + IDCorrelativoPadre);
        }
        public Coleccion(int correlativo, String nombre, int correlativoPadre, int correlativoFlujo)
        {
            consultaColeccion = new ConsultaColeccion();
            this.IDCorrelativo = correlativo;
            this.nombre = nombre;
            this.IDCorrelativoPadre = correlativoPadre;
            this.correlativoFlujo = correlativoFlujo;
            Console.WriteLine("Correlativo Padre " + IDCorrelativoPadre);

        }
        public void crearColeccion(){
            IDCorrelativo = consultaColeccion.crearColeccion(nombre, IDCorrelativoPadre, correlativoFlujo);
        }

        public void modificarNombre() {
            consultaColeccion.modificarNombre(this.IDCorrelativo, this.nombre);
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
            this.IDCorrelativoPadre = IDPadre;
        }

        public int getIDCorrelativoPadre()
        {
            return this.IDCorrelativoPadre;
        }
        public int getCorrelativoFlujo()
        {
            return this.correlativoFlujo;
        }
        public int getCorrelativo() {
            return this.IDCorrelativo;
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
        public override string ToString()
        {
            return this.nombre;
        }
    }
}
