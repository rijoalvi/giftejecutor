using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace GiftEjecutor
{
    class Comando
    {
       // private ConfiguracionProyecto configuracion;
        ConsultaComando consultaComando;
        private int ID;
        private int IDFormularioATrabajar;
        private string nombre;
        private string descripcion;
        private int tipo;
        private string nombreTipo;
        private DateTime fechaActualizacion;

        private int IDExpediente;//falta cargarlo

        public Comando() {
            consultaComando = new ConsultaComando();
            //this.configuracion = new ConfiguracionProyecto();
            this.ID=-1;
            this.IDFormularioATrabajar = -1;
            this.nombre = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.descripcion = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.tipo = -1;
            this.nombreTipo = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.fechaActualizacion = new DateTime(1111, 1, 11);
        }
        public int getID() {
            return this.ID;
        }
        public void setIDExpediente(int IDExpediente) {
            this.IDExpediente = IDExpediente;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public string getDescripcion()
        {
            return this.descripcion;
        }
        public void setAtributosSegunID(int IDComando){
          SqlDataReader datosComando;

          datosComando = this.consultaComando.getDatosPorID(IDComando);
          if (datosComando != null)
          {
              while (datosComando.Read())//En tería solo ejecuta una vez
              {
                  this.ID = System.Int32.Parse(datosComando.GetValue(0).ToString());
                  this.nombre = datosComando.GetValue(1).ToString();
                  this.descripcion = datosComando.GetValue(2).ToString();
                  this.tipo = System.Int32.Parse(datosComando.GetValue(3).ToString());
                  this.nombreTipo = this.getTipo(this.tipo);

                  this.IDFormularioATrabajar = System.Int32.Parse(datosComando.GetValue(4).ToString());
                  //this.fechaActualizacion = datosComando.GetValue(5);
              }
          }       
        }
        public DataTable getDataTableComandosPorIDActividad(int IDActividad)
        {
            DataTable tablaComandos = new DataTable();
            DataRow fila;


            DataColumn IDComando = new DataColumn();
            DataColumn nombreComando = new DataColumn();
            DataColumn descripcionComando = new DataColumn();
            DataColumn tipoComando = new DataColumn();
            DataColumn formularioATrabajar = new DataColumn();


            IDComando.ColumnName = "IDComando";            
            nombreComando.ColumnName = "nombreComando";
            descripcionComando.ColumnName = "descripcionComando";
            tipoComando.ColumnName = "tipoComando";
            formularioATrabajar.ColumnName = "formularioATrabajar";

            IDComando.DataType = Type.GetType("System.String");            
            nombreComando.DataType = Type.GetType("System.String");
            descripcionComando.DataType = Type.GetType("System.String");
            tipoComando.DataType = Type.GetType("System.String");
            formularioATrabajar.DataType = Type.GetType("System.String");

            tablaComandos.Columns.Add(IDComando);            
            tablaComandos.Columns.Add(nombreComando);
            tablaComandos.Columns.Add(descripcionComando);
            tablaComandos.Columns.Add(tipoComando);
            tablaComandos.Columns.Add(formularioATrabajar);

            SqlDataReader datos;

            datos = consultaComando.getTodosComandosPorIDActividad(IDActividad);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaComandos.NewRow();
                    fila["IDComando"] = datos.GetValue(2);                    
                    fila["nombreComando"] = datos.GetValue(3);
                    fila["descripcionComando"] = datos.GetValue(4);
                    fila["tipoComando"] = this.getTipo(System.Int32.Parse(datos.GetValue(5).ToString()));
                    fila["formularioATrabajar"] = datos.GetValue(6);
                    tablaComandos.Rows.Add(fila);
                }
            }
            return tablaComandos;
        }
        /**
         * 
         * Este es el orden de los comandos a la hora de guardarlos en la base de datos:
         * 1 - Comando de Creación
         * 2 - Comando de Borrado
         * 3 - COmando de Actualización
         * 4 - Comando de Máscara    
         */
        private void setTipo(int tipo){
            switch (tipo)
            {
                case 1:
                    this.nombreTipo = "Creación";
                    break;
                case 2:
                    this.nombreTipo = "Borrado";
                    break;
                case 3:
                    this.nombreTipo = "Actualización";
                    break;
                case 4:
                    this.nombreTipo = "Máscara";
                    break;
                default:
                    this.nombreTipo = "[Mal especifícado]";
                    break;
            }
        }
        private string getTipo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "Creación";
                case 2:
                    return "Borrado";
                case 3:
                    return "Actualización";
                case 4:
                    return "Máscara";
                default:
                    return "[Mal especifícado]";
            }
        }


        public override string ToString()
        {
            return "Nombre: " + this.nombre + ""+'\n'+
                "Descripción: " + this.descripcion + "" + '\n' +
                "Tipo: " + this.tipo + "" + '\n' +                
                "NombreTipo: " + this.nombreTipo + "" + '\n' +
                "IDFormularioATrabajar: " + this.IDFormularioATrabajar + "" + '\n' +
                "IDExpediente: " + this.IDExpediente + "" + '\n' + 
                "Fecha Actualización: " + this.fechaActualizacion + ""// + '\n' + 
                ;
        }

    }
}
