using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace GiftEjecutor
{
    class MaestroDetalle
    {
        public int getIDFormularioDetalle(int IDFormularioMaestro){
            ConsultaMaestroDetalle maestroDetalle = new ConsultaMaestroDetalle();

            SqlDataReader datos = null;
            datos=maestroDetalle.getFormularioDetallesPorFormularioMaestro(IDFormularioMaestro);




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
    }
}
