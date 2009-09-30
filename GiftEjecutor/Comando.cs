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
        public int IDFormularioATrabajar;
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
              while (datosComando.Read())//En teoría solo ejecuta una vez
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

        public DataTable getDataTableComandosPorIDActividadYaRealizado(int IDActividad)
        {
            DataTable tablaComandos = new DataTable();
            DataRow fila;


            DataColumn IDComando = new DataColumn();
            DataColumn nombreComando = new DataColumn();
            DataColumn descripcionComando = new DataColumn();
            DataColumn tipoComando = new DataColumn();
            DataColumn formularioATrabajar = new DataColumn();
            Controlador control;


            IDComando.ColumnName = "ID";
            nombreComando.ColumnName = "Nombre";
            descripcionComando.ColumnName = "Descripcion";
            tipoComando.ColumnName = "Tipo";
            formularioATrabajar.ColumnName = "Formulario";

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

            //Con esto escondo la columna "IDComando".      Ricardo
            //tablaComandos.Columns["IDComando"].ColumnMapping = MappingType.Hidden;

            control = new Controlador();
            SqlDataReader datos;
            datos = consultaComando.getTodosComandosPorIDActividad(IDActividad);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaComandos.NewRow();
                    fila["ID"] = datos.GetValue(2);
                    fila["Nombre"] = datos.GetValue(3);
                    fila["Descripcion"] = datos.GetValue(4);
                    fila["Tipo"] = this.getTipo(System.Int32.Parse(datos.GetValue(5).ToString()));
                    fila["Formulario"] = datos.GetValue(6);
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkComandoRealizado((int)datos.GetValue(2), IDExpediente, IDActividad);
                    if (yaSeEjecuto)
                    {
                        tablaComandos.Rows.Add(fila);
                    }
                }
            }
            return tablaComandos;
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
            Controlador control;


            IDComando.ColumnName = "ID";            
            nombreComando.ColumnName = "Nombre";
            descripcionComando.ColumnName = "Descripcion";
            tipoComando.ColumnName = "Tipo";
            formularioATrabajar.ColumnName = "Formulario";

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

            //Con esto escondo la columna "IDComando".      Ricardo
            //tablaComandos.Columns["IDComando"].ColumnMapping = MappingType.Hidden;

            control = new Controlador();
            SqlDataReader datos;
            int seAgregoComandoAEjecutar;
            seAgregoComandoAEjecutar = 0;

            datos = consultaComando.getTodosComandosPorIDActividad(IDActividad);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaComandos.NewRow();
                    fila["ID"] = datos.GetValue(2);                    
                    fila["Nombre"] = datos.GetValue(3);
                    fila["Descripcion"] = datos.GetValue(4);
                    fila["Tipo"] = this.getTipo(System.Int32.Parse(datos.GetValue(5).ToString()));
                    fila["Formulario"] = datos.GetValue(6);
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkComandoRealizado((int)datos.GetValue(2), IDExpediente, IDActividad);
                    if (!yaSeEjecuto && seAgregoComandoAEjecutar == 0)
                    {
                        tablaComandos.Rows.Add(fila);
                        seAgregoComandoAEjecutar = 1;
                    }
                }
                int resp = tablaComandos.Rows.Count;
                Console.Write("Numero filas: " +resp.ToString());

                if (tablaComandos.Rows.Count == 0) // si no hay nada en el dataset de actividades a ejecutar es xq se llego al final
                {
                    control.finalizarActividadBitacora(IDExpediente, IDActividad);
                }

            }
            return tablaComandos;
        }

        public DataTable getDataTableComandosPorIDActividadNoRealizados(int IDActividad)
        {
            DataTable tablaComandos = new DataTable();
            DataRow fila;


            DataColumn IDComando = new DataColumn();
            DataColumn nombreComando = new DataColumn();
            DataColumn descripcionComando = new DataColumn();
            DataColumn tipoComando = new DataColumn();
            DataColumn formularioATrabajar = new DataColumn();
            Controlador control;


            IDComando.ColumnName = "ID";
            nombreComando.ColumnName = "Nombre";
            descripcionComando.ColumnName = "Descripcion";
            tipoComando.ColumnName = "Tipo";
            formularioATrabajar.ColumnName = "Formulario";

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

            //Con esto escondo la columna "IDComando".      Ricardo
            //tablaComandos.Columns["IDComando"].ColumnMapping = MappingType.Hidden;

            control = new Controlador();
            SqlDataReader datos;
            int seAgregoComandoAEjecutar;
            seAgregoComandoAEjecutar = 0;

            datos = consultaComando.getTodosComandosPorIDActividad(IDActividad);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaComandos.NewRow();
                    fila["ID"] = datos.GetValue(2);
                    fila["Nombre"] = datos.GetValue(3);
                    fila["Descripcion"] = datos.GetValue(4);
                    fila["Tipo"] = this.getTipo(System.Int32.Parse(datos.GetValue(5).ToString()));
                    fila["Formulario"] = datos.GetValue(6);
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkComandoRealizado((int)datos.GetValue(2), IDExpediente, IDActividad);
                    if (!yaSeEjecuto)
                    {
                        if(seAgregoComandoAEjecutar == 1)
                        {
                            tablaComandos.Rows.Add(fila);
                        }
                        seAgregoComandoAEjecutar = 1;
                    }
                }
            }
            return tablaComandos;
        }

        /**
         * 
         * Este es el orden de los comandos a la hora de guardarlos en la base de datos:
            1 - Comando de Crear
            2 - Comando de Modificar
            3 - Comando de visualizar
            4 - Comando de borrar
            5 - Comando con Máscara
         */
        private void setTipo(int tipo){
            switch (tipo)
            {
                case 1:
                    this.nombreTipo = "Creación";
                    break;
                case 2:
                    this.nombreTipo = "Actualización";
                    break;
                case 3:
                    this.nombreTipo = "Visualización";
                    break;
                case 4:
                    this.nombreTipo = "Borrado";
                    break;
                case 5:
                    this.nombreTipo = "Máscara";
                    break;
                default:
                    this.nombreTipo = "[Mal especifícado]";
                    break;
            }
        }


        /// <summary>
        /// Devuelve el string segun el tipo del comando
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private string getTipo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "Creación";
                case 2:
                    return "Actualización";
                case 3:
                    return "Visualización";
                case 4:
                    return "Borrado";
                case 5:
                    return "Máscara";
                default:
                    return "[Mal especifícado]";
            }
        }

        /// <summary>
        /// Recibe un string de tipo comando, y le devuelve el int del tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public int getTipoComando(String tipo)
        {
            if( tipo.Equals("Creación"))
                return 1;
            if (tipo.Equals("Actualización"))
                return 2;
            if (tipo.Equals("Visualización"))
                return 3;
            if (tipo.Equals("Borrado"))
                return 4;
            if (tipo.Equals("Máscara"))
                return 5;
            return -1;            
        }

        public bool terminoActividad(int IDActividad, int IDExpediente)
        {
            bool respuesta = false;
            Controlador control;
            control = new Controlador();
            int ultimoComandoEjecut;
            int ultimoComandoReal;
            ultimoComandoEjecut = control.getUltimoComandoEjecutado(IDExpediente);
            ultimoComandoReal = control.getUltimoComandoReal(IDActividad);
            if (ultimoComandoReal == ultimoComandoEjecut)
            {
                respuesta = true;
            }
            return respuesta;
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
