using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GiftEjecutor
{
    class Actividad
    {
        // private ConfiguracionProyecto configuracion;
        ConsultaActividad consultaActividad;
        private int ID;
        private string nombre;
        private string descripcion;
        private int tipo;
        private string nombreTipo;
        private DateTime fechaActualizacion;
        private int IDExpediente;//falta cargarlo



        public bool esParalela;
        public bool esExclusiva;

        public Actividad() {
            consultaActividad = new ConsultaActividad();
            //this.configuracion = new ConfiguracionProyecto();
            this.ID = -1;
            this.nombre = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.descripcion = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.tipo = -1;
            this.nombreTipo = ConfiguracionProyecto.VALOR_DEFECTO_TEXTO;
            this.fechaActualizacion = new DateTime(1111, 1, 11);

        }

        public int getID()
        {
            return this.ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDExpediente"></param>
        public void setIDExpediente(int IDExpediente)
        {
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
        public virtual void setAtributosSegunID(int IDActividad)
        {
            SqlDataReader datosActividad;

            datosActividad = this.consultaActividad.getDatosPorID(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                    this.ID = System.Int32.Parse(datosActividad.GetValue(0).ToString());
                    this.nombre = datosActividad.GetValue(1).ToString();
                    this.descripcion = datosActividad.GetValue(2).ToString();
                    //this.tipo = System.Int32.Parse(datosActividad.GetValue(3).ToString());
                    this.nombreTipo = this.getTipo(this.tipo.ToString());
                    //this.fechaActualizacion = datosActividad.GetValue(5);
                }
            }
        }

        /// <summary>
        /// Devuelve el dataTable con todas las actividades que cumplen con los requisitos para ejecutarse
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public DataTable getDataTableActividadesEjecutablesPorIDFlujo(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            SqlDataReader datos;

            //esto nos indica si ya se agrego una actividad a ejecutables x lo tanto las siguientes no tienen suficientes requisitos
            bool unaEjecutable = false;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();                
                    
                    //si es repetible y cumple con requisitos, nunca se bloquea
                    if (fila["repetible"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase) && !unaEjecutable)
                    {
                        tablaActividades.Rows.Add(fila);
                        //revisa si ya fue ejecutada, si no, cambia estado de "unaEjecutable"
                        if ( !control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente))
                            unaEjecutable = true;                        
                    }
                    //revisa si ya fue ejecutada
                    else
                    {
                        bool yaSeEjecuto;
                        yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente);
                        if (!yaSeEjecuto && !unaEjecutable)
                        {
                            tablaActividades.Rows.Add(fila);
                            unaEjecutable = true;
                        }
                    }                    
                }
            }
            return tablaActividades;
        }
        public DataTable getDataTableActividadesEjecutablesHijasPorIDPadre(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            //datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            SqlDataReader datos;
            ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            //esto nos indica si ya se agrego una actividad a ejecutables x lo tanto las siguientes no tienen suficientes requisitos
            bool unaEjecutable = false;
            //datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(2);
                    fila["nombreActividad"] = datos.GetValue(3);
                    fila["descripcionActividad"] = datos.GetValue(4);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(5).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();

                    bool yaSeEjecuto2 = false;
                    yaSeEjecuto2 = control.checkActividadRealizada((int)datos.GetValue(2), IDExpediente);
                        
                    if (this.esParalela && !yaSeEjecuto2)
                    {
                        tablaActividades.Rows.Add(fila);
                    }
                    else
                    {





                        //si es repetible y cumple con requisitos, nunca se bloquea
                        if (fila["repetible"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase) && !unaEjecutable)
                        {
                            tablaActividades.Rows.Add(fila);
                            //revisa si ya fue ejecutada, si no, cambia estado de "unaEjecutable"
                            if (!control.checkActividadRealizada((int)datos.GetValue(2), IDExpediente))
                                unaEjecutable = true;
                        }
                        //revisa si ya fue ejecutada
                        else
                        {
                            bool yaSeEjecuto;
                            yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(2), IDExpediente);
                            if (!yaSeEjecuto && !unaEjecutable)
                            {
                                tablaActividades.Rows.Add(fila);
                                unaEjecutable = true;
                            }
                        }
                    }
                }
            }
            return tablaActividades;
        }
        /// <summary>
        /// Devuelve el dataTable con las actividades que se ya fueron ejecutadas y no se pueden ejecutar más
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public DataTable getDataTableActividadesPorIDFlujoEjecutadas(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            SqlDataReader datos;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();

                    //si es repetible nunca se bloquea
                    if (fila["repetible"].ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                    {
                        //revisa si ya fue ejecutada
                        bool yaSeEjecuto;
                        yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente);
                        if (yaSeEjecuto)
                            tablaActividades.Rows.Add(fila);
                    }
                }
            }
            return tablaActividades;
        }
        public DataTable getDataTableActividadesEjecutadasHijaPorIDPadre(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            SqlDataReader datos;

            //datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(2);
                    fila["nombreActividad"] = datos.GetValue(3);
                    fila["descripcionActividad"] = datos.GetValue(4);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(5).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();

                    //si es repetible nunca se bloquea
                    if (fila["repetible"].ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                    {
                        //revisa si ya fue ejecutada
                        bool yaSeEjecuto;
                        yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(2), IDExpediente);
                        if (yaSeEjecuto)
                            tablaActividades.Rows.Add(fila);
                    }
                }
            }
            return tablaActividades;
        }
        /// <summary>
        /// Devuelve el dataTable con las actividades que todavia no cumplen con los requisitos
        /// </summary>
        /// <param name="IDFlujo"></param>
        /// <returns></returns>
        public DataTable getDataTableActividadesNOEjecutablesPorIDFlujo(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            bool unaEjecutable = false;
            SqlDataReader datos;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();                
                    
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente);
                    //Si ya se ejecuto no me sirve aqui
                    //Sirven desp de una ejecutable
                    if (!yaSeEjecuto && !unaEjecutable)
                    {
                        unaEjecutable = true;
                    }
                    else { 
                        //Si ya hubo una ejecutable, todas las que siguen no se pueden ejecutar
                        if(unaEjecutable)
                            //agrego
                            tablaActividades.Rows.Add(fila);
                    }                      
                }
            }
            return tablaActividades;
        }
        public DataTable getDataTableActividadesNOEjecutablesHijasPorIDPadre(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
            bool unaEjecutable = false;
            SqlDataReader datos;
            //datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(2);
                    fila["nombreActividad"] = datos.GetValue(3);
                    fila["descripcionActividad"] = datos.GetValue(4);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(5).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();

                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(2), IDExpediente);
                    //Si ya se ejecuto no me sirve aqui
                    //Sirven desp de una ejecutable
                    if (!yaSeEjecuto && !unaEjecutable)
                    {
                        unaEjecutable = true;
                    }
                    else
                    {
                        //Si ya hubo una ejecutable, todas las que siguen no se pueden ejecutar
                        if (unaEjecutable)
                            //agrego
                            tablaActividades.Rows.Add(fila);//COMENTE ESTOS PARA QUE TODAS SEAN PARALELAS, LUISK
                    }
                }
            }
            return tablaActividades;
        }                    
        /// <summary>
        /// nuevo metodo toString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Nombre: " + this.nombre + "" + '\n' +
                "Descripción: " + this.descripcion + "" + '\n' +
                "Tipo: " + this.tipo + "" + '\n' +
                "NombreTipo: " + this.nombreTipo + "" + '\n' +
                "IDExpediente: " + this.IDExpediente + "" + '\n' +
                "Fecha Actualización: " + this.fechaActualizacion + ""// + '\n' + 
                ;
        }

        private string getTipo(string tipo)
        {
            switch (tipo)
            {
                case "true":
                    return "Simple";
                case "false":
                    return "Compuesta";
                case "0":
                    return "Simple";
                case "1":
                    return "Compuesta";
                default:
                    return "[Mal especifícado]";
            }
        }

        /// <summary>
        /// Escribe en bitácora
        /// </summary>
        /// <param name="IDExp"></param>
        /// <param name="IDAct"></param>
        /// <param name="IDCom"></param>
        /// <param name="tipoCom"></param>
        /// <param name="IDInstForm"></param>
        /// <param name="IDFormConfig"></param>
        /// <param name="ejec"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public SqlDataReader insertarEnBitacora(int IDExp, int IDAct, int IDCom, int tipoCom, int IDInstForm, int IDFormConfig, bool ejec, String descripcion)
        {
            return consultaActividad.insertarEnBitacora(IDExp, IDAct, IDCom, tipoCom, IDInstForm, IDFormConfig, ejec, descripcion);
        }

        //devuelve true si la actividad es exclusiva
        //devuelve false si la actividad NO es exclusiva
        public bool getExclusiva(int IDActividad)
        {
            bool respuesta = false;
            SqlDataReader datos;
            datos = consultaActividad.getExclusiva(IDActividad);
            if (datos != null)
            {
                while (datos.Read())
                {
                    string exclusiva = datos.GetValue(0).ToString();
                    if (exclusiva == "true")
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }
        public DataTable getDataTableActividadesPorIDFlujo(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";

            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();
        
            SqlDataReader datos;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();
                    tablaActividades.Rows.Add(fila);
                }
            }
            return tablaActividades;
        }

        public DataTable getDataTableActividadesPorIDFlujoParaAsignaciones(int IDFlujo)
        {
            DataTable tablaActividades = new DataTable();
            DataRow fila;

            DataColumn asignar = new DataColumn();
            DataColumn IDActividad = new DataColumn();
            DataColumn nombreActividad = new DataColumn();
            DataColumn descripcionActividad = new DataColumn();
            DataColumn tipoActividad = new DataColumn();
            DataColumn repetible = new DataColumn();

            asignar.ColumnName = "Asignar";
            IDActividad.ColumnName = "IDActividad";
            nombreActividad.ColumnName = "nombreActividad";
            descripcionActividad.ColumnName = "descripcionActividad";
            tipoActividad.ColumnName = "tipoActividad";
            repetible.ColumnName = "repetible";


            asignar.DataType = Type.GetType("System.String");
            IDActividad.DataType = Type.GetType("System.String");
            nombreActividad.DataType = Type.GetType("System.String");
            descripcionActividad.DataType = Type.GetType("System.String");
            tipoActividad.DataType = Type.GetType("System.String");
            repetible.DataType = Type.GetType("System.String");

            tablaActividades.Columns.Add(asignar);
            tablaActividades.Columns.Add(IDActividad);
            tablaActividades.Columns.Add(nombreActividad);
            tablaActividades.Columns.Add(descripcionActividad);
            tablaActividades.Columns.Add(tipoActividad);
            tablaActividades.Columns.Add(repetible);

            Controlador control = new Controlador();

            SqlDataReader datos;
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaActividades.NewRow();
                    fila["Asignar"] = new CheckBox();
                    
                    fila["IDActividad"] = datos.GetValue(1);
                    fila["nombreActividad"] = datos.GetValue(2);
                    fila["descripcionActividad"] = datos.GetValue(3);
                    fila["tipoActividad"] = this.getTipo(datos.GetValue(4).ToString());
                    fila["repetible"] = datos.GetValue(6).ToString();
                    tablaActividades.Rows.Add(fila);
                }
            }
            return tablaActividades;
        }



        public String getSecuenciaActRealizadas(int IDExpediente, int IDFlujo)
        {
            String respuesta = null;


            Controlador control = new Controlador();
            bool unaEjecutable = false;
            SqlDataReader datos;
            //ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            //datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente);
                    if (yaSeEjecuto)
                    {
                        if (respuesta == null)
                        {
                            respuesta = datos.GetValue(2).ToString();
                        }
                        else
                        {
                            respuesta = respuesta + " --> "+datos.GetValue(2).ToString();
                        }
                    }
                }
            }
            if (respuesta == null)
            {
                respuesta = " - Ninguna - ";
            }
            return respuesta;
        }

        public String getActividadActual(int IDExpediente, int IDFlujo)
        {
            String respuesta = null;

            Controlador control = new Controlador();
            bool unaEjecutable = false;
            SqlDataReader datos;
            //ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            //datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    bool SeEjecuta;
                    SeEjecuta = control.checkActividadIniciada((int)datos.GetValue(1), IDExpediente);
                    if (SeEjecuta)
                    {
                        if (respuesta == null)
                        {
                            respuesta = datos.GetValue(2).ToString();
                        }
                        else
                        {
                            respuesta = respuesta + " --> " + datos.GetValue(2).ToString();
                        }
                    }
                }
            }
            if (respuesta == null)
            {
                respuesta = " - Ninguna - ";
            }
            return respuesta;
        }

        public String getSecuenciaActPorRealizar(int IDExpediente, int IDFlujo)
        {
            String respuesta = null;

            Controlador control = new Controlador();
            bool unaEjecutable = false;
            SqlDataReader datos;
            //ConsultaActividaCompuesta consultaActividadCompuesta = new ConsultaActividaCompuesta();
            //datos = consultaActividadCompuesta.getTodasActividadesHija(IDFlujo);
            datos = consultaActividad.getTodasActividadesPorIDFlujo(IDFlujo);
            if (datos != null)
            {
                while (datos.Read())
                {
                    bool yaSeEjecuto;
                    yaSeEjecuto = control.checkActividadRealizada((int)datos.GetValue(1), IDExpediente);
                    if (!yaSeEjecuto && !control.checkActividadIniciada((int)datos.GetValue(1), IDExpediente))
                    {
                        if (respuesta == null)
                        {
                            respuesta = datos.GetValue(2).ToString();
                        }
                        else
                        {
                            respuesta = respuesta + " --> " + datos.GetValue(2).ToString();
                        }
                    }
                }
            }
            if (respuesta == null)
            {
                respuesta = " - Ninguna - ";
            }
            return respuesta;
        }

        public String getNombreActividadPorID(int IDActividad)
        {
            String respuesta= null;
            SqlDataReader datosActividad = this.consultaActividad.getNombreAct(IDActividad);
            if (datosActividad != null)
            {
                while (datosActividad.Read())//En tería solo ejecuta una vez
                {
                    respuesta = datosActividad.GetValue(0).ToString();
                }
            }
            return respuesta;
        }
    }
}
