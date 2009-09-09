using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class Coleccion
    {
        private String nombre;
        private String nombrePadre;
        private int IDCorrelativo;
        private int IDCorrelativoPadre; // Correlativo del padre en cero indica que esta en la raiz
        private ConsultaColeccion consultaColeccion;

        public Coleccion(String nombre) {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.IDCorrelativo = -1;//IDCorrelativo;
        }

        public Coleccion(String nombre, String nombrePadre)
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.nombrePadre = nombrePadre;
        }

        public void crearColeccion(){
            IDCorrelativo = consultaColeccion.crearColeccion(nombre, IDCorrelativoPadre);
        }

        public String[] coleccionesHijas() {
            return this.consultaColeccion.coleccionesHijas(nombre/*, nombrePadre*/);
        } 

        public void setIDCorrelativoPadre(int IDPadre) {
            this.IDCorrelativoPadre = IDPadre;
        }

        public int getIDCorrelativoPadre() {
            return this.IDCorrelativoPadre;
        }

        public String getNombre() {
            return this.nombre;
        }

    }
}
