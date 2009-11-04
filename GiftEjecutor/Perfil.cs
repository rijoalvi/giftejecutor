using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GiftEjecutor
{
    class Perfil
    {
        ConsultaPerfil consultaPerfil;

        public Perfil() {
            consultaPerfil = new ConsultaPerfil();
        }
        /// <summary>
        /// Devuelve un DataTable para un DataGridView con todos los perfiles registrados en la BD
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable getDataTableTodosPerfiles() {

            DataTable tablaPerfiles = new DataTable();
            DataRow fila;

            DataColumn IDPerfil = new DataColumn();
            DataColumn nombre = new DataColumn();
            DataColumn tipo = new DataColumn();
            DataColumn fechaActualizacion = new DataColumn();
            DataColumn IDFlujo = new DataColumn();

            IDPerfil.ColumnName = "IDPerfil";
            nombre.ColumnName = "nombre";
            tipo.ColumnName = "tipo";
            fechaActualizacion.ColumnName = "fechaActualizacion";
            IDFlujo.ColumnName = "IDFlujo";

            IDPerfil.DataType = Type.GetType("System.String");
            nombre.DataType = Type.GetType("System.String");
            tipo.DataType = Type.GetType("System.String");
            fechaActualizacion.DataType = Type.GetType("System.String");
            IDFlujo.DataType = Type.GetType("System.String");

            tablaPerfiles.Columns.Add(IDPerfil);
            tablaPerfiles.Columns.Add(nombre);
            tablaPerfiles.Columns.Add(tipo);
            tablaPerfiles.Columns.Add(fechaActualizacion);
            tablaPerfiles.Columns.Add(IDFlujo);

            
            SqlDataReader datos;
            datos = this.consultaPerfil.getTodosPerfiles();
            if (datos != null)
            {
                while (datos.Read())
                {
                    fila = tablaPerfiles.NewRow();
                    fila["IDPerfil"] = datos.GetValue(0).ToString(); ;
                    fila["nombre"] = datos.GetValue(1).ToString();
                    fila["tipo"] = datos.GetValue(2).ToString();
                    fila["fechaActualizacion"] = datos.GetValue(3).ToString();
                    fila["IDFlujo"] = datos.GetValue(4).ToString();
                    tablaPerfiles.Rows.Add(fila);
                }
            }
            return tablaPerfiles;
        }
        public void addNuevoPerfil(String nombre, String tipo, int IDFlujo){
            this.consultaPerfil.insertPerfil(nombre, tipo);
        }
        public void deletePerfil(int IDPerfil) {
            this.consultaPerfil.deletePerfil(IDPerfil);
        
        }
    }
}
