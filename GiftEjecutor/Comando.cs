using System;
using System.Collections.Generic;
using System.Text;

namespace GiftEjecutor
{
    class Comando
    {
        private ConfiguracionProyecto configuracion;

        private int ID;
        private int IDFormulario;
        private string nombre;
        private string descripcion;
        private int tipo;
        private string nombreTipo;
        private DateTime fechaActualizacion;

        public Comando() {
            //this.configuracion = new ConfiguracionProyecto();
            this.ID=-1;
            this.IDFormulario = -1;
            this.nombre = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.descripcion = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.tipo = -1;
            this.nombreTipo = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.fechaActualizacion = new DateTime(1111, 1, 11);
        }
        public int getID() {
            return this.ID;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public string getDescripcion()
        {
            return this.descripcion;
        }

        /**
         * 
         * Este es el orden de los comandos a la hora de guardarlos en la base de datos:
         * 1 - Comando de Creaci�n
         * 2 - Comando de Borrado
         * 3 - COmando de Actualizaci�n
         * 4 - Comando de M�scara    
         */
        private void setTipo(int tipo){
            switch (tipo)
            {
                case 1:
                    this.nombreTipo = "Creaci�n";
                    break;
                case 2:
                    this.nombreTipo = "Borrado";
                    break;
                case 3:
                    this.nombreTipo = "Actualizaci�n";
                    break;
                case 4:
                    this.nombreTipo = "M�scara";
                    break;
                default:
                    this.nombreTipo = "[Mal especif�cado]";
                    break;
            }
            
        }
        public override string ToString()
        {
            return "[Nombre: " + this.nombre + "] [Tipo: " + this.nombreTipo + "]";
                ;
        }

    }
}
