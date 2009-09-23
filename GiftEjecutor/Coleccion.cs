using System;
using System.Collections.Generic;
using System.Text;
namespace GiftEjecutor
{
    class Coleccion
    {
        private String nombre;
   //     private String nombrePadre;
        private int IDCorrelativo;
        private int IDCorrelativoPadre; // Correlativo del padre en cero indica que esta en la raiz
        private int correlativoFlujo;
        private ConsultaColeccion consultaColeccion;


        public Coleccion(String nombre) {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.IDCorrelativo = -1;//IDCorrelativo;
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
        public void crearColeccion(){
            IDCorrelativo = consultaColeccion.crearColeccion(nombre, IDCorrelativoPadre, correlativoFlujo);
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

        public String getNombre() {
            return this.nombre;
        }
        public String toString() {
            return this.nombre;
        }

    }
}
