using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace GiftEjecutor
{
    /// <summary>
    /// Clase que almacena una relaci�n maestro detalle entre dos formularios.
    /// </summary>
    class MaestroDetalle
    {
        public String nombreFormDetalle;
        public DataTable tablaCamposDetalle;
        ConsultaMaestroDetalle consultaMaestroDetalle;

        /// <summary>
        /// Constructor por omisi�n
        /// </summary>
        public MaestroDetalle()
        {
            consultaMaestroDetalle = new ConsultaMaestroDetalle();
        }

        /// <summary>
        /// Devuelve el id del formularo detalle para el maestro que recibe de par�metro
        /// </summary>
        /// <param name="IDFormularioMaestro"></param>
        /// <returns></returns>
        public int getIDFormularioDetalle(int IDFormularioMaestro){
          //  consultaMaestroDetalle = new ConsultaMaestroDetalle();

            SqlDataReader datos = null;
            datos=consultaMaestroDetalle.getFormularioDetallesPorFormularioMaestro(IDFormularioMaestro);




            /*DataTable tablaComandos = new DataTable();
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
            */
            int IDFormularioDetalle=-1;
            if (datos != null)
            {
                while (datos.Read())
                {
                    //fila = tablaComandos.NewRow();
                    IDFormularioDetalle= Int32.Parse(datos.GetValue(3).ToString());
                   // fila["Nombre"] = datos.GetValue(3);
                  //  fila["Descripcion"] = datos.GetValue(4);
                 //   fila["Tipo"] = this.getTipo(System.Int32.Parse(datos.GetValue(5).ToString()));
                 //   fila["Formulario"] = datos.GetValue(6);

                }
            }
            return IDFormularioDetalle;
        }

        public SqlDataReader getDatosFormularioPorID() {
            return null;
        }

        /// <summary>
        /// Devuelve el DataTable con todos los campos del detalle, para el maestro que recibe de parametro
        /// </summary>
        /// <param name="IDMaestroDetalle"></param>
        /// <returns></returns>
        public DataTable getDataTableCamposDetalle(int IDMaestroDetalle)
        {

            //DataTable tablaCamposDetalle = new DataTable();
            tablaCamposDetalle = new DataTable();
            DataRow fila;

            DataColumn IDTipoCampo = new DataColumn();
            DataColumn nombreCampo = new DataColumn();



            IDTipoCampo.ColumnName = "IDTipoCampo";
            nombreCampo.ColumnName = "nombreCampo";


            IDTipoCampo.DataType = Type.GetType("System.String");
            nombreCampo.DataType = Type.GetType("System.String");



            tablaCamposDetalle.Columns.Add(IDTipoCampo);
            tablaCamposDetalle.Columns.Add(nombreCampo);



            SqlDataReader datos;
            datos = consultaMaestroDetalle.getCamposDetalleSeleccionados(IDMaestroDetalle);
            
            //int IDFormularioDetalle=-1;
            if (datos != null)
            {
                while (datos.Read())
                {
                    //fila = tablaComandos.NewRow();
                    fila = tablaCamposDetalle.NewRow();
                    fila["IDTipoCampo"] = datos.GetValue(0);
                    fila["nombreCampo"] = datos.GetValue(1);
                    tablaCamposDetalle.Rows.Add(fila);
                  //  IDFormularioDetalle= Int32.Parse(datos.GetValue(3).ToString());
                }
            }
            return tablaCamposDetalle;
        }

        /// <summary>
        /// Devuelve los detalles del formulario din�mico
        /// </summary>
        /// <param name="IDMaestroDetalle"></param>
        /// <param name="nombreTabla"></param>
        /// <param name="IdDatos"></param>
        /// <returns></returns>
        public DataTable getDataTableDetallesDinamicos(int IDMaestroDetalle,String nombreTabla, int IdDatos)
        {

            DataTable tablaCamposDetalle = new DataTable();
            List<String> campos = null;
            campos = this.getArregloCamposDetalle(IDMaestroDetalle);

            String campoSolo = IDMaestroDetalle+" campos: ";
            foreach (String campoE in campos)
            {
                Console.WriteLine(campoE);
                campoSolo += " " + campoE;
            }
          //  System.Windows.Forms.MessageBox.Show(campoSolo);

            int cantidadCampos = campos.Count;
            tablaCamposDetalle = new DataTable();
            DataRow fila;
            //cantidadCampos++;
            DataColumn[] campo = new DataColumn[cantidadCampos];


            for (int i = 0; i < cantidadCampos; i++)
            {
                campo[i] = new DataColumn();
            }
         //   campo[cantidadCampos] = new DataColumn();
          //  DataColumn IDTipoCampo = new DataColumn();
          //  DataColumn nombreCampo = new DataColumn();


            for (int i = 0; i < cantidadCampos; i++ )
            {
                campo[i].ColumnName = campos[i];
            }
          //  campo[cantidadCampos ].ColumnName = "NombreTabla";
            //IDTipoCampo.ColumnName = "IDTipoCampo";
            //nombreCampo.ColumnName = "nombreCampo";


            for (int i = 0; i < cantidadCampos; i++)
            {
                campo[i].DataType = Type.GetType("System.String");
            }
            //campo[cantidadCampos].DataType = Type.GetType("System.String");
            //IDTipoCampo.DataType = Type.GetType("System.String");
            //nombreCampo.DataType = Type.GetType("System.String");


            DataColumn colNombreTabla = new DataColumn();
            colNombreTabla.ColumnName = "NombreTabla";
            colNombreTabla.DataType = Type.GetType("System.String");
            tablaCamposDetalle.Columns.Add(colNombreTabla);
            for (int i = 0; i < cantidadCampos; i++)
            {
                //campo[i].DataType = Type.GetType("System.String");
                tablaCamposDetalle.Columns.Add(campo[i]);
            }



            //tablaCamposDetalle.Columns.Add(IDTipoCampo);
            //tablaCamposDetalle.Columns.Add(nombreCampo);



            SqlDataReader datos=null;
            //datos = consultaMaestroDetalle.getCamposDetalleSeleccionados(IDMaestroDetalle);
            datos = consultaMaestroDetalle.getTodoTablaDinamica(nombreTabla, IdDatos);

            //int IDFormularioDetalle=-1;
            if (datos != null)
            {
                while (datos.Read())
                {
                    //fila = tablaComandos.NewRow();
                    fila = tablaCamposDetalle.NewRow();

                    for (int i = 0; i < cantidadCampos; i++)
                    {
                        //campo[i].DataType = Type.GetType("System.String");
                        fila[campos[i]] = datos.GetValue(i);
                    }
                    fila["NombreTabla"] = nombreTabla;
                    //fila[campos[0]] = datos.GetValue(1);

                   // fila[campos[1]] = datos.GetValue(2);

                    tablaCamposDetalle.Rows.Add(fila);
                    //  IDFormularioDetalle= Int32.Parse(datos.GetValue(3).ToString());
                }
            }
            return tablaCamposDetalle;
        }


        public List<String> getArregloCamposDetalle(int IDMaestroDetalle)
        {

            
            tablaCamposDetalle = new DataTable();
            DataRow fila;

            DataColumn IDTipoCampo = new DataColumn();
            DataColumn nombreCampo = new DataColumn();



            IDTipoCampo.ColumnName = "IDTipoCampo";
            nombreCampo.ColumnName = "nombreCampo";


            IDTipoCampo.DataType = Type.GetType("System.String");
            nombreCampo.DataType = Type.GetType("System.String");



            tablaCamposDetalle.Columns.Add(IDTipoCampo);
            tablaCamposDetalle.Columns.Add(nombreCampo);



            SqlDataReader datos;
            datos = consultaMaestroDetalle.getCamposDetalleSeleccionados(IDMaestroDetalle);

            //int IDFormularioDetalle=-1;
            List<String> campos = new List<String>();
            //String[] campos = new String[3];
           // campos.
            if (datos != null)
            {
                campos.Add("correlativo");
                while (datos.Read())
                {
                    //fila = tablaComandos.NewRow();
                    fila = tablaCamposDetalle.NewRow();
                    fila["IDTipoCampo"] = datos.GetValue(0).ToString();
                    fila["nombreCampo"] = datos.GetValue(1).ToString();
                    campos.Add(datos.GetValue(1).ToString());
                    tablaCamposDetalle.Rows.Add(fila);
                    //  IDFormularioDetalle= Int32.Parse(datos.GetValue(3).ToString());
                }

            }
            return campos;
        }

        /// <summary>
        /// Devuelve una lista de los IDs de los detalles para el maestro
        /// </summary>
        /// <param name="IDMaestroDetalle"></param>
        /// <returns></returns>
        public List<String> getDetallesIDs(int IDMaestroDetalle)
        {


            DataTable tablaMaestroDetalle = new DataTable();
            DataRow fila;

            DataColumn IDMaestroDetalleCol = new DataColumn();
            //DataColumn nombreCampo = new DataColumn();



            IDMaestroDetalleCol.ColumnName = "IDMaestroDetalleCol";
            //nombreCampo.ColumnName = "nombreCampo";


            IDMaestroDetalleCol.DataType = Type.GetType("System.String");
           // nombreCampo.DataType = Type.GetType("System.String");



            tablaMaestroDetalle.Columns.Add(IDMaestroDetalleCol);
         //   tablaCamposDetalle.Columns.Add(nombreCampo);



            SqlDataReader datos;//select * from MaestroDetalle where IDFormularioMaestro=13;
            datos = consultaMaestroDetalle.getMaestroDetallesPorFormularioMaestro(IDMaestroDetalle);

            //int IDFormularioDetalle=-1;
            List<String> IDMaestrosDetalles = new List<String>();
            //String[] campos = new String[3];
            // campos.
            if (datos != null)
            {
                while (datos.Read())
                {
                    //fila = tablaComandos.NewRow();
              //      fila = tablaCamposDetalle.NewRow();
              //      fila["IDMaestroDetalle"] = datos.GetValue(0).ToString();
                    IDMaestrosDetalles.Add(datos.GetValue(0).ToString());
                    IDMaestrosDetalles.Add(datos.GetValue(1).ToString());
                 //   fila["nombreCampo"] = datos.GetValue(1).ToString();
               //     campos.Add(datos.GetValue(1).ToString());
                //    tablaCamposDetalle.Rows.Add(fila);
                    //  IDFormularioDetalle= Int32.Parse(datos.GetValue(3).ToString());
                }
            }
            return IDMaestrosDetalles;
        }


    }
}
