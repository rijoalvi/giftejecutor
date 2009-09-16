using System;
using System.Collections.Generic;
using System.Text;
namespace GiftEjecutor
{
    class Expediente
    {
        private String nombre;
   //     private String nombrePadre;
        private int correlativo;
        private int correlativoColeccion; // Correlativo del la coleccion a la que pertenece
        private int IDFlujo;
        private ConsultaExpediente consultaExpediente;

        public Expediente(String nombre) {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.correlativo = -1;//IDCorrelativo;
        }

   /*     public Coleccion(String nombre, String nombrePadre)
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.nombrePadre = nombrePadre;
        }
        */
        public Expediente(String nombre, int correlativoPadre,int IDFlujo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.IDFlujo = IDFlujo;
            this.correlativoColeccion= correlativoPadre;
            Console.WriteLine("Correlativo Padre " + correlativoColeccion);
        }
        public void crearExpediente(){
            correlativo = consultaExpediente.crearExpediente(nombre, correlativoColeccion, IDFlujo);
        }

        public List<String[]> listarExpedientes() {
         
            return this.consultaExpediente.listarExpedientes();
            
        }

        public void setCorrelativoColeccion(int correlativoColeccion) {
            this.correlativoColeccion = correlativoColeccion;
        }

        public int getCorrelativoColeccion() {
            return this.correlativoColeccion;
        }

        public String getNombre() {
            return this.nombre;
        }
        public String toString() {
            return this.nombre;
        }

    }
}
