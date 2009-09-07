using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GiftEjecutor
{
    class Actividad
    {
        Comando comandoPrueba;
        public Actividad() { 
            this.comandoPrueba = new Comando();        
        }

        public Comando getComandoPrueba() {
            return comandoPrueba;
            //ConsultaComando c = new ConsultaComando();
            //c.
        }
        public DataTable  getDataTableConComandosDeLaActividad(){
            
            DataTable tablaComandos = new DataTable();
            DataRow fila;
            DataColumn IDComando = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn descripcion = new DataColumn();

            IDComando.ColumnName = "IDComando";
            IDComando.DataType = Type.GetType("System.String");

            nombre.ColumnName = "nombre";
            nombre.DataType = Type.GetType("System.String");

            descripcion.ColumnName = "descripcion";
            descripcion.DataType = Type.GetType("System.String");

            tablaComandos.Columns.Add(IDComando);
            tablaComandos.Columns.Add(nombre);
            tablaComandos.Columns.Add(descripcion);

            //if (ControladorBD.SQLSERVER == ControladorBD.conexionSelecciona)
            //{

            fila = tablaComandos.NewRow();
            fila["IDComando"] = this.getComandoPrueba().getID();
            fila["nombre"] = this.getComandoPrueba().getNombre();
            fila["descripcion"] = this.getComandoPrueba().getDescripcion();
            tablaComandos.Rows.Add(fila);
            //}
            return tablaComandos;
        }
    }
}
