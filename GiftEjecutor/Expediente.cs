using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace GiftEjecutor
{
    class Expediente
    {
        private String nombre;
   //     private String nombrePadre;
        private int correlativo;
        private int correlativoColeccion; // Correlativo del la coleccion a la que pertenece
        private int IDFlujo;
        private int finalizado;
        private ConsultaExpediente consultaExpediente;

        public Expediente(String nombre) {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.correlativo = -1;//IDCorrelativo;
            finalizado = 0;
        }

        public Expediente(String nombre, int correlativoPadre,int IDFlujo)
        {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.IDFlujo = IDFlujo;
            this.correlativoColeccion= correlativoPadre;
            this.correlativo = consultaExpediente.buscarCorrelativo(nombre, correlativoPadre);
            Actividad act = new Actividad();
            DataTable tabla = act.getDataTableActividadesEjecutablesPorIDFlujo(this.IDFlujo);
            if (tabla.Rows.Count == 0)
            {
                finalizado = 1;
            }
            else {
                finalizado = 0;
            }
            Console.WriteLine("Correlativo Padre " + correlativoColeccion);
        }

        public Expediente(String nombre, int correlativo) {
            consultaExpediente = new ConsultaExpediente();
            this.nombre = nombre;
            this.correlativo = correlativo;
            this.finalizado = 0;
        }
   /*     public Coleccion(String nombre, String nombrePadre)
        {
            consultaColeccion = new ConsultaColeccion();
            this.nombre = nombre;
            this.nombrePadre = nombrePadre;
        }
        */
        public int getIDExpediente() {
            return correlativo;
        }

        public void crearExpediente(){
            correlativo = consultaExpediente.crearExpediente(nombre, correlativoColeccion, IDFlujo);
        }

        public List<String[]> listarExpedientes() {         
            return this.consultaExpediente.listarExpedientes();
        }

        public void modificarNombre()
        {
            this.consultaExpediente.modificarNombre(this.correlativo, this.nombre);
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

        public int getCorrelativoFlujo() {
            return this.IDFlujo;
        }

        public String toString() {
            return this.nombre;
        }

        public int getCorrelativo() {
            return this.correlativo;
        }

        public void eliminar() {
            this.consultaExpediente.eliminarExpediente(this.correlativo, this.nombre);
        }

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

    }
}
